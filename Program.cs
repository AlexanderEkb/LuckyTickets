using System;

namespace LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
          ITask lucky = new Lucky();
          Tester tester = new Tester(lucky, @"D:\Work\Study\tests\");
          // tester.RunAllTests();
          tester.RunTest(1);
        }
    }
}
