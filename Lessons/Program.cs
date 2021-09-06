using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lessons._03_Lesson;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lessons
{
    /// <summary>
    ///
    ///BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
    ///Intel Core i5-8265U CPU 1.60GHz(Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
    ///.NET SDK= 5.0.400

    ///[Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT[AttachedDebugger]
    /// DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
    ///
    ///|                                Method |     Mean |    Error |   StdDev |   Median |
    ///|-------------------------------------- |---------:|---------:|---------:|---------:|
    ///|               'Класс с данными float' | 67.19 ns | 1.260 ns | 1.117 ns | 67.29 ns |
    ///|           'Структура с данными float' | 97.05 ns | 2.852 ns | 8.136 ns | 93.62 ns |
    ///|          'Структура с данными double' | 73.56 ns | 1.332 ns | 1.481 ns | 73.37 ns |
    ///| 'Структура с данными float без корня' | 65.15 ns | 0.938 ns | 0.878 ns | 65.52 ns |
    /// 1. Второй по скорости, т.к. обратиться к данным по ссылке будет быстрее, чем перенести всю структуру
    /// 2. Последний по скорости, т.к. перенос большого количества объемных структур становится затруднительным. 
    ///     Здесь нужны подробные разъяснения по работе объектов на куче и в стеке, т.к. стек выделяется всего лишь 1Мб, а структуры такого размера явно не могут в нем уместиться. Вероятно здесь подключается куча, и постоянно изменяется ее размер(перераспределяется выделенная область)
    /// 3. Третий по скорости, т.к. дабл весит больше в два раза чем флоат, но класс Math не приводит данные к флоат.
    /// 4. Первый по скорости. Корень не высчитывается.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
