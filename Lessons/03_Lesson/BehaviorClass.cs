using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using System.Threading;
using BenchmarkDotNet.Running;

namespace Lessons._03_Lesson
{
    public class BehaviorClass
    {
        public BehaviorClass()
        {
            InitArr();
        }
        static int size = 100;
        public PointClass[] pC = new PointClass[size];
        public PointStruct[] pS = new PointStruct[size];
        public PointStructDouble[] psD = new PointStructDouble[size];


        public void InitArr()
        {
            for (int i = 0; i < size; i++)
            {
                pC[i] = new PointClass() { X = new Random().Next(100, 500), Y = new Random().Next(100, 500) };
                pS[i] = new PointStruct() { X = new Random().Next(100, 500), Y = new Random().Next(100, 500) };
                psD[i] = new PointStructDouble() { X = new Random().Next(100, 500), Y = new Random().Next(100, 500) };
            }

            Thread.Sleep(2000);
        }

        public float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }


        public float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDistanceDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }


        public float PointDistanceWithoutSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return ((x * x) + (y * y));
        }


        [Benchmark(Description ="Класс с данными float")]
        public void TestPointDFloatClass()
        {
            for (int i = 0; i < pC.Length; i++)
            {
                PointDistance(pC[i], pC[i]);
            }
        }
        [Benchmark(Description = "Структура с данными float")]
        public void TestPointDFLoatStruct()
        {
            for (int i = 0; i < pS.Length; i++)
            {
                PointDistance(pS[i], pS[i]);
            }
        }
        [Benchmark(Description = "Структура с данными double")]
        public void TestPointDDoubleStruct()
        {
            for (int i = 0; i < psD.Length; i++)
            {
                PointDistanceDouble(psD[i], psD[i]);
            }
        }
        [Benchmark(Description = "Структура с данными float без корня")]
        public void TestPointDFloatStructWhithoutSQRT()
        {
            for (int i = 0; i < pS.Length; i++)
            {
                PointDistanceWithoutSqrt(pS[i], pS[i]);
            }
        }

    }
}
