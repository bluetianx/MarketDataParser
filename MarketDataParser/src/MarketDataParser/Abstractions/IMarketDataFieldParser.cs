namespace MarketDataParser.Abstractions;

/// <summary>
/// MarketDataField 类型解析器
/// </summary>
public interface IMarketDataFieldParser
{ 
    /// <summary>
    /// bytes 字节数据转换为MarketDataField
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    MarketDataField MapFrom(in ReadOnlySpan<byte> bytes);
}