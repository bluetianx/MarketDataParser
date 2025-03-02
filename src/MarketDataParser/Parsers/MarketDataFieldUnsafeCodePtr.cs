using MarketDataParser.Abstractions;
using MarketDataParser.Internal;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用unsafe代码直接操作指针，将字节数组的内存地址强制转换为结构体指针
/// </summary>
public sealed class MarketDataFieldUnsafeCodePtr : IMarketDataFieldParser
{
    /// <summary>
    /// bytes 字节数据转换为MarketDataField
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        unsafe
        {
            if (bytes.Length < 312)
            {
                throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
            }

            // 使用 fixed 固定字节数组，获取指针，并强制转换为结构体指针
            fixed (byte* ptr = bytes)
            {
                var marketDataStructPrt = *(MarketDataStruct*)ptr;

                MarketDataField marketDataField = MarketDataStructConverter.ConvertToMarketDataField(marketDataStructPrt);

                return marketDataField;
            }
        }
    }
}