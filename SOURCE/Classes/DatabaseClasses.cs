using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public partial class Database
    {
        public class Table
        {
            public class JoinTable
            {
                public Table Table { get { return tables[TableType]; } }
                public Type TableType;
                public string Prefix;
                public string on;
                public string On
                {
                    get
                    {
                        if (this.Alias == null || this.Alias == "") return this.on;
                        return this.on.Replace(this.Table.Name + ".", this.Alias + ".");
                    }
                    set { this.on = value; }
                }
                public string Alias;
                public string Name { get { if (this.Alias == null) return Table.Name; return Table.Name + " " + Alias; } }
                public string Type;
                public bool AddInherited;

                public JoinTable(Type tableType, string type, string prefix, string on, string alias = null, bool addInherited = true)
                {
                    this.TableType = tableType;
                    this.Type = type;
                    this.Prefix = prefix;
                    if (this.Prefix != "" && this.Prefix.Last() != '_') this.Prefix += "_";
                    this.on = on;
                    this.Alias = alias;
                    this.AddInherited = addInherited;
                }

                public IEnumerable<string> Fields
                {
                    get
                    {
                        if (this.Alias == null || this.Alias == "")
                            return Table.Fields.Select(x => x + " " + Prefix + x.Split('.').Last());
                        return Table.Fields.Select(x => x.Replace(Table.Name + ".", Alias + ".") + " " + Prefix + x.Split('.').Last());
                    }
                }

                public string FieldsStr
                {
                    get
                    {
                        return string.Join(", ", this.Fields);
                    }
                }

                public override string ToString()
                {
                    return this.Type + " " + this.Name;
                }

                public JoinTable DeepCopy()
                {
                    return new JoinTable(this.TableType, this.Type, this.Prefix, this.on, this.Alias, this.AddInherited);
                }
            }

            public string Name;
            public string Extra = "";
            private List<string> fields = null;
            public List<string> Fields
            {
                get
                {
                    if (this.fields.Count == 0)
                        ApplyCopy();
                    return this.fields;
                }
                private set { this.fields = value; }
            }
            public List<JoinTable> Joins = new List<JoinTable>();
            List<Type> CopyFrom = new List<Type>();
            public Table(string name, params string[] fields)
            {
                this.Name = name.Trim();
                if (this.Name.IndexOf(" ") != -1)
                {
                    this.Extra = this.Name.Substring(this.Name.IndexOf(" "));
                    int idx = this.Extra.ToLower().IndexOf("where");
                    if (idx != -1) idx += "where".Length;
                    this.Extra = this.Extra.Substring(idx);
                    this.Name = this.Name.Substring(0, this.Name.IndexOf(" "));
                }
                this.Fields = new List<string>(fields.Select(x => this.Name + "." + x));
            }

            public Table(Table t)
            {
                t.ApplyCopy();
                this.Fields = new List<string>(t.Fields);
                this.Joins = new List<JoinTable>(t.Joins.Select(x=>x.DeepCopy()));
                this.Name = t.Name;
                this.Extra = t.Extra;
            }

            public Table Join<T>(string type, string on, string prefix, string alias = null, bool addInherited = true) where T : Record
            {
                this.Joins.Add(new JoinTable(typeof(T), type, prefix, on, alias, addInherited));
                return this;
            }

            public Table Copy<T>()
            {
                this.CopyFrom.Add(typeof(T));
                return this;
            }

            private void ApplyCopy()
            {
                if (this.CopyFrom.Count != 0)
                {
                    IEnumerable<string> current = this.fields.Select(x => x.ToLower()); ;
                    foreach (Type copy in this.CopyFrom)
                        this.fields.AddRange(tables[copy].Fields.Select(x => x.Replace(tables[copy].Name + ".", this.Name + ".")).Where(x => !current.Contains(x.ToLower())));
                    this.CopyFrom.Clear();
                }
            }

            public override string ToString()
            {
                string name = this.Name;
                string extra = this.Extra;
                ApplyCopy();
                string fields = string.Join(", ", this.Fields.Select(x => x + " " + x.Split('.').Last()));
                if (this.Joins.Count != 0)
                {
                    HashSet<string> usedJoins = new HashSet<string>();
                    foreach (var join in this.Joins)
                        ProcessJoin(join, ref name, ref fields, usedJoins, join, new List<JoinTable>());

                    foreach (var join in this.Joins)
                        if (join.Table.Extra != null && join.Table.Extra != "")
                            if (extra.Trim().Length == 0)
                                extra = join.Table.Extra;
                            else
                                extra += " and\r\n(" + join.Table.Extra + ")";
                }
                if (extra.Trim() != "")
                    extra = "\r\nWhere\r\n(" + extra+")";
                return fields + "\r\nfrom\r\n" + name + extra;
            }

            private void ProcessJoin(JoinTable join, ref string name, ref string fields, HashSet<string> usedJoins, JoinTable main, List<JoinTable> parents)
            {
                string oldAlias = join.Alias;

                int i = 0;
                if (usedJoins.Contains(join.Name))
                {
                    string alias = oldAlias;
                    if (alias == null)
                        alias = join.Table.Name;

                    if (join.Prefix != null && join.Prefix != "")
                        alias = join.Table.Name + "_" + join.Prefix.Replace("_", "");
                    else
                        if (main.Prefix != null && main.Prefix != "")
                            alias = join.Table.Name + "_" + main.Prefix.Replace("_", "");
                    join.Alias = alias;
                    while (usedJoins.Contains(join.Name))
                        join.Alias = alias + "_" + (i++);
                }
                string oldPrefix = join.Prefix;

                string oldOn = join.on;
                foreach (var item in parents)
                    if (item.Alias != null && item.Alias != "")
                        if (join.On.Contains(item.Table.Name + "."))
                            join.On = join.On.Replace(item.Table.Name + ".", item.Alias + ".");

                usedJoins.Add(join.Name);
                IEnumerable<JoinTable> prevDifType = parents.Where(x=>x.Type != join.Type);
                if(prevDifType.Any())
                    name += "\r\n" + prevDifType.Last().Type + " " + join.Name + " On " + join.On;
                else
                    name += "\r\n" + join.Type + " " + join.Name + " On " + join.On;
                {
                    string fs = fields;
                    if (parents.Count > 0)
                    {
                        JoinTable x = parents.Last();
                        join.Prefix = x.Prefix == null ? x.Alias == null ? x.Table.Name : x.Alias : x.Prefix;
                        if (join.Prefix.Last() != '_')
                            join.Prefix += "_";

                        join.Prefix += oldPrefix;
                        join.Prefix = join.Prefix.Replace("__", "_");
                    }
                    string f = join.FieldsStr;
                    fields += f.Trim().Length > 0 ? "\r\n, " + f : "";
                }

                parents.Add(join);

                if (join.Table.Joins.Count > 0 && join.AddInherited)
                    foreach (var item in join.Table.Joins)
                        ProcessJoin(item, ref name, ref fields, usedJoins, main, new List<JoinTable>(parents));
                join.Prefix = oldPrefix;
                join.Alias = oldAlias;
                join.On = oldOn;
            }
        }
    }
}
