using BenchmarkDotNet.Running;

namespace MarketDataParser.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MarketDataFieldParserBench>();
    }
}