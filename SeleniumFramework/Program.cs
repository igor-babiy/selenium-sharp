using System;
using System.Collections.Generic;
using System.Text;



namespace SeleniumFramework
{
    
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
                foreach (string test in args)
                    TestLauncher.runByName(test);
            else
               Console.WriteLine("Please, set test class name as parameter!");
            Environment.Exit(0);
        }
    }
}
