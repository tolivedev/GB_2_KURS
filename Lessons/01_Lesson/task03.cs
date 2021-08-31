using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._01_Lesson
{
    public class TestCase
    {
        public int X { get; set; }
        public int Expected { get; set; }
        public Exception ExpectedException { get; set; }
    }



    class task03
    {
        public task03()
        {
            Start();
        }
        static Stopwatch timer = new Stopwatch();
        static int FibonachiRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else if (n < 0) { throw new ArgumentException(); }
            else
            {
                return FibonachiRec(n - 1) + FibonachiRec(n - 2);
            }
        }

        static int Fibon(int end)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < end; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            if (a < 0)
            {
                throw new Exception();
            }
            return a;
        }
        static void TestFib(TestCase testCase)
        {
            try
            {
                timer.Start();
                var actual = Fibon(testCase.X);
                timer.Stop();
                Console.WriteLine($"\nФибоначчи цикл за: {timer.Elapsed.Milliseconds} мс");
                timer.Reset();
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        static void TestFibRec(TestCase testCase)
        {
            try
            {
                timer.Start();
                var actual = FibonachiRec(testCase.X);
                timer.Stop();
                Console.WriteLine($"\nФибоначчи рекурсия за: {timer.Elapsed.Milliseconds} мс");
                timer.Reset();

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("VALID TEST");
            }
            catch (Exception)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        public void Start()
        {
            var testCase1 = new TestCase()
            {
                X = 45,
                Expected = 1134903170,
                ExpectedException = null
            };

            TestFib(testCase1);
            TestFibRec(testCase1);
            Console.ReadKey();
        }
    }
}
