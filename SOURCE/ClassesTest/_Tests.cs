using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class _Tests
    {
        [TestMethod]
        public void AllRecordsImplemented()
        {
            IEnumerable<Type> recordTypes = Database.Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record)));
            IEnumerable<string> recordNames = recordTypes.Select(x => x.Name);
            IEnumerable<string> definedTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Select(x => x.Name.Replace("Test", ""));
            IEnumerable<string> notDefinedTypes = recordNames.Where(x => !definedTypes.Contains(x));
            Assert.AreEqual(0, notDefinedTypes.Count(), "\nNOT DEFINED IN TESTING\n" + string.Join("\n", notDefinedTypes));
        }

        [TestMethod]
        public void AllImplementationsAreUnitTest()
        {
            IEnumerable<Type> recordTypes = Database.Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record)));
            IEnumerable<string> recordNames = recordTypes.Select(x => x.Name);
            IEnumerable<Type> definedTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => recordNames.Contains(x.Name.Replace("Test", "")));
            IEnumerable<string> notDefinedTypes = definedTypes.Where(x => !x.IsSubclassOf(typeof(RecordTest))).Select(x => x.Name);
            Assert.AreEqual(0, notDefinedTypes.Count(), "\nNOT INHERITING UNIT TEST\n" + string.Join("\n", notDefinedTypes));
        }

        [TestMethod]
        public void AllImplemented()
        {
            IEnumerable<string> typeNames = requiredTypesStr;
            IEnumerable<string> notDefinedTypes = typeNames.Where(x => !definedTypesStr.Contains(x));
            notDefinedTypes = notDefinedTypes.Where(x =>!x.Contains("Util"));
            notDefinedTypes = notDefinedTypes.Where(x => !x.Contains("BuildResult"));
            Assert.AreEqual(0, notDefinedTypes.Count(), "\nNOT DEFINED IN TESTING\n" + string.Join("\n", notDefinedTypes));
        }

        [TestMethod]
        public void AllAreUnitTest()
        {
            IEnumerable<string> notInheriting = definedTypes.Where(x => !x.IsSubclassOf(typeof(UnitTest))).Select(x => x.Name.Replace("Test", ""));
            notInheriting = notInheriting.Where(x => !x.Contains("_"));
            notInheriting = notInheriting.Where(x => x != typeof(UnitTest).Name.Replace("Test",""));
            Assert.AreEqual(0, notInheriting.Count(), "\nNOT INHERITING UNIT TEST\n" + string.Join("\n", notInheriting));
        }

        static IEnumerable<string> definedTypesStr { get { return definedTypes.Select(x => x.Name.Replace("Test","")); } }
        static IEnumerable<Type> definedTypes
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            }
        }

        static IEnumerable<string> requiredTypesStr { get { return requiredTypes.Select(x => x.Name.Replace("Test", "")); } }
        static IEnumerable<Type> requiredTypes
        {
            get
            {
                return Database.Assembly.GetTypes().Where(x => !x.IsEnum).
                Where(x => !x.IsSubclassOf(typeof(Exception))).
                Where(x => !x.IsSubclassOf(typeof(Attribute))).
                Where(x => !x.Name.StartsWith("<>c__"));
            }
        }
    }
}