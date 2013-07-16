using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using SeleniumFramework.BuisnessLogic.TestCase;

namespace SeleniumFramework
{
        class TestLauncher
        {
            public static void runByName(string className)
            {
                Type t = Type.GetType("SeleniumFramework.Testcases." + className);
                if (t == null)
                {
                    Console.WriteLine("Testcase with class name \"" + className + "\" not found!");
                }
                Object tcb = Activator.CreateInstance(t);
                TestCaseBase testcase = (TestCaseBase)tcb;
                if (testcase.run())
                    Console.WriteLine("Test \""+ className + "\" finished: PASS");
                else
                    Console.WriteLine("Test \"" + className + "\" finished: FAIL");
                
            }
        }

}


