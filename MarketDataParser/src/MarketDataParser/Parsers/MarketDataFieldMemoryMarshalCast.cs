using System.Runtime.InteropServices;
using MarketDataParser.Abstractions;
using MarketDataParser.Internal;

namespace MarketDataParser.Parsers;

/// <summary>
/// MemoryMarshal.Cast实现
/// </summary>
public sealed class MarketDataFieldMemoryMarshalCast : IMarketDataFieldParser
{
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < 312)
        {
            throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
        }

        // 使用 MemoryMarshal.Cast 将字节数据转换为结构体
        var structSpan = MemoryMarshal.Cast<byte, MarketDataStruct>(bytes);
        var dataStruct = structSpan[0];
        MarketDataField marketDataField = MarketDataStructConverter.ConvertToMarketDataField(dataStruct);

        return marketDataField;
    }
}