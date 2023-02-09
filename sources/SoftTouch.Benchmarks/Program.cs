// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using SoftTouch.Benchmarks;

Console.WriteLine("Hello, World!");


BenchmarkRunner.Run<ReflectionBench>();