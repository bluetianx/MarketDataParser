using MarketDataParser.Abstractions;

namespace MarketDataParser.Parsers;


/// <summary>
/// BitConverter 对应的 source generate 版本，
/// 可以根据MarketDataField 的字段 自动实现 MapFrom 逻辑 ，用于 MarketDataField 字段变更频繁的场景
/// </summary>
public partial class MarketDataFieldBitConverterSourceGen : IMarketDataFieldParser
{
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        
        var field = MapFromBytes(bytes);
        
        return field;
    }
}