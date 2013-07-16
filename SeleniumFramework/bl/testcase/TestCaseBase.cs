using System;
using System.Collections.Generic;
using System.Text;
using SeleniumFramework.Core.Exceptions;

namespace SeleniumFramework.BuisnessLogic.TestCase
{
    abstract class TestCaseBase
    {
        protected string testName;
        protected string testId;

        public TestCaseBase()
        {
            testName = this.GetType().Name;
        }

        public bool run()
        {
            bool result = true;
            Console.WriteLine("Starting testcase " + testName + "; " + testId);

            try
            {
                init();
                test();

            }
            catch (InitializationException e)
            {
                Console.WriteLine("InitializationException: " + e.Message);
                result = false;
            }
            catch (TestException e)
            {
                Console.WriteLine("TestException: " + e.Message);
                result = false;
            }
            finally
            {
                try { finalize(); }
                catch (Exception e) { Console.WriteLine("FinalizationException: " + e.Message); result = false; }
                
            }
            return true;
        }

        protected abstract void init();

        protected abstract void test();

        protected abstract void finalize();

        protected bool assertTrue(bool expression, string message)
        {
            if(!expression)
                Console.WriteLine("Assersion Error! " + message);
            return expression; 
        }

        protected bool assertFalse(bool expression, string message)
        {
            if (expression)
                Console.WriteLine("Assersion Error! " + message);
            return !expression; 
        }

    }
}
