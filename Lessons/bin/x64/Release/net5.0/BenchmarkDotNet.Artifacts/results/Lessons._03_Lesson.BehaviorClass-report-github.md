``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|                                Method |     Mean |    Error |   StdDev |   Median |
|-------------------------------------- |---------:|---------:|---------:|---------:|
|               &#39;Класс с данными float&#39; | 67.19 ns | 1.260 ns | 1.117 ns | 67.29 ns |
|           &#39;Структура с данными float&#39; | 97.05 ns | 2.852 ns | 8.136 ns | 93.62 ns |
|          &#39;Структура с данными double&#39; | 73.56 ns | 1.332 ns | 1.481 ns | 73.37 ns |
| &#39;Структура с данными float без корня&#39; | 65.15 ns | 0.938 ns | 0.878 ns | 65.52 ns |
