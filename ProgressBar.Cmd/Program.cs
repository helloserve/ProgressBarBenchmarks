﻿// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;

namespace ProgressBar.Cmd;

public static class Program {

    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<ProgressBarBenchmarks>();
    }
}
