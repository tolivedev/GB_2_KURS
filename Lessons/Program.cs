using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lessons._02_Lesson;
using Lessons._03_Lesson;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            new Lesson02();
        }
    }
}
