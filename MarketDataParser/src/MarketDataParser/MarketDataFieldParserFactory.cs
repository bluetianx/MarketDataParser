using MarketDataParser.Abstractions;
using MarketDataParser.Enums;
using MarketDataParser.Parsers;

namespace MarketDataParser;

/// <summary>
/// MarketDataFieldParser工厂，创建不同的 Parser
/// </summary>
public sealed class MarketDataFieldParserFactory
{
    /// <summary>
    /// MarketDataFieldParserType 与 parser 具体实现类的 map
    /// </summary>
    private static Dictionary<MarketDataFieldParserType, IMarketDataFieldParser> _parsers = new()
    {
        { MarketDataFieldParserType.BitConverter, new MarketDataFieldBitConverter() },
        { MarketDataFieldParserType.BinaryPrimitives, new MarketDataFieldBinaryPrimitives() },
        { MarketDataFieldParserType.MemoryMarshalRead, new MarketDataFieldMemoryMarshalRead() },
        { MarketDataFieldParserType.MemoryMarshalCast, new MarketDataFieldMemoryMarshalCast() },
        { MarketDataFieldParserType.BinaryReader, new MarketDataFieldBinaryReader() },
        { MarketDataFieldParserType.BinaryReaderSkipLocalsInit, new MarketDataFieldBinaryReaderSkipLocalsInit() },
        { MarketDataFieldParserType.UnsafeCodePtr, new MarketDataFieldUnsafeCodePtr() },
        { MarketDataFieldParserType.MarshalPtrToStructure, new MarketDataFieldMarshalPtrToStructure() },
        { MarketDataFieldParserType.BitConverterPerf, new MarketDataFieldBitConverterPerf() },
        { MarketDataFieldParserType.BitConverterSourceGen, new MarketDataFieldBitConverterSourceGen() },
    };

    /// <summary>
    /// 创建 IMarketDataFieldParser
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public IMarketDataFieldParser Create(MarketDataFieldParserType type)
    {
        var parser = _parsers[type];

        return parser;
    }
}