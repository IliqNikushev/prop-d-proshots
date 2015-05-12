using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    using Reader = MySql.Data.MySqlClient.MySqlDataReader;
    using Connection = MySql.Data.MySqlClient.MySqlConnection;
    using Command = MySql.Data.MySqlClient.MySqlCommand;
    public static partial class Database
    {
        private static Dictionary<Type, Func<Reader, object>> recordBuildDefinitions = new Dictionary<Type, Func<Reader, object>>()
        {
            {typeof(Visitor), (reader) => CreateVisitor(reader)},
            {typeof(AdminUser), (reader) => CreateAdmin(reader)},
            {typeof(User), (reader) => {
                string type = reader.GetStr("Type");
                if(type == "visitor")
                    return recordBuildDefinitions[typeof(Visitor)](reader);
                else if(type == "admin")
                    return recordBuildDefinitions[typeof(AdminUser)](reader);
                throw new NotImplementedException("User type unknown " + type);
            }
            }
        };

        private static Visitor CreateVisitor(Reader reader)
        {
            int id = -1;
            string firstName, lastName, userName, email, picture;
            GetUser(reader, out id, out firstName, out lastName, out userName, out email, out picture);

            decimal amount = reader.Get<decimal>("Amount");
            string rfid = reader.GetStr("RFID");

            return new Visitor(id, firstName, lastName, userName, email, picture, amount, rfid);
        }

        private static AdminUser CreateAdmin(Reader reader)
        {
            int id = -1;
            string firstName, lastName, userName, email, picture;
            GetUser(reader, out id, out firstName, out lastName, out userName, out email, out picture);

            return new AdminUser(id, firstName, lastName, userName, email, picture);
        }
    }
}
