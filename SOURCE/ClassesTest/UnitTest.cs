using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public abstract class UnitTest
    {
        public virtual void OnInitialize() { Database.testing = true; }
        public virtual void OnCleanup() { }

        [TestInitialize()]
        public void Initialize()
        {
            OnInitialize();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            OnCleanup();
        }

        [TestMethod]
        public void AllInheritedMethodsHaveTestAttribute() // needs a little optimization if necessary
        {
            System.Reflection.MethodInfo[] methods = this.GetType().GetMethods();

            List<string> notImplemented = new List<string>();

            foreach (System.Reflection.MethodInfo method in methods)
            {
                Type testMethodAttribute = typeof(TestMethodAttribute);
                Type baseType = this.GetType().BaseType;
                while (baseType != typeof(object))
                {
                    var baseMethod = baseType.GetMethod(method.Name);
                    if (baseMethod != null)
                    {
                        if (baseMethod.CustomAttributes.Where(x => x.AttributeType == testMethodAttribute).Count() != method.CustomAttributes.Where(x => x.AttributeType == testMethodAttribute).Count())
                            if (!notImplemented.Contains(method.Name))
                                notImplemented.Add(method.Name);
                    }
                    baseType = baseType.BaseType;
                }
            }

            if (notImplemented.Count > 0)
                Assert.Fail("Missing test method attributes for " + notImplemented.Count + " methods :\n" + String.Join("\n", notImplemented));
        }
    }
}
