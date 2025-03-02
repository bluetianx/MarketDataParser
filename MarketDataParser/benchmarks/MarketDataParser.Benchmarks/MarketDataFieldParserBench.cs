using BenchmarkDotNet.Attributes;
using MarketDataParser.Enums;
using MarketDataParser.Parsers;

namespace MarketDataParser.Benchmarks;

[MemoryDiagnoser]
public class MarketDataFieldParserBench
{
    
    private static MarketDataFieldBitConverter _bitConverter = new();
    private static MarketDataFieldBinaryPrimitives _binaryPrimitives = new();
    private static MarketDataFieldMemoryMarshalRead _memoryRead = new();
    private static MarketDataFieldMemoryMarshalCast _marshalCast = new();
    private static MarketDataFieldBinaryReader _binaryReader = new();
    private static MarketDataFieldBinaryReaderSkipLocalsInit _memoryReaderSkipLocals = new();
    private static MarketDataFieldUnsafeCodePtr _memoryReaderUnsafeCodePtr = new();
    private static MarketDataFieldMarshalPtrToStructure _marshalPtrToStructure = new();
    private static MarketDataFieldBitConverterPerf _bitConverterPerf = new();
    private static MarketDataFieldBitConverterSourceGen _bitConverterSourceGen = new();
    
    [Benchmark]
    public MarketDataField MarketDataFieldBitConverter()
    {
        var marketData = _bitConverter.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldBinaryPrimitives()
    {
        var marketData = _binaryPrimitives.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldMemoryMarshalRead()
    {
        var marketData = _memoryRead.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldMemoryMarshalCast()
    {
        var marketData = _marshalCast.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldBinaryReader()
    {
        var marketData = _binaryReader.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldBinaryReaderSkipLocalsInit()
    {
        var marketData = _memoryReaderSkipLocals.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldUnsafeCodePtr()
    {
        var marketData = _memoryReaderUnsafeCodePtr.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldMarshalPtrToStructure()
    {
        var marketData = _marshalPtrToStructure.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldBitConverterPerf()
    {
        var marketData = _bitConverterPerf.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    [Benchmark]
    public MarketDataField MarketDataFieldBitConverterSourceGen()
    {
        var marketData = _bitConverterSourceGen.MapFrom(_testMarketDataBytes);

        return marketData;
    }
    
    #region 测试数据

    private readonly byte[] _testMarketDataBytes = Convert.FromHexString(
        "AAAAAAAA000000006666666666263C407A390A0000000000D7A3703D0A573F40A4703D0AD7A3394000000000000000008A311BD89BD42F00AE47E17A142E3C406666666666263C403D0AD7A3707D3C403333333333F33B4000000050D505724100000000000000003D0AD7A3707D3C406666666666263C406C07000000000000EC51B81E852B3C40C800000000000000A4703D0AD7233C409001000000000000F6285C8FC2353C402C010000000000001F85EB51B81E3C409001000000000000B81E85EB51383C40CC100000000000009A99999999193C40840300000000000085EB51B81E453C40640000000000000014AE47E17A143C40DC0500000000000048E17A14AE473C4024130000000000008C013630333035312E534800000000000000000000000000000030393A35343A3137000000320000");

    #endregion
}