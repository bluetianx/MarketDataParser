using System.Runtime.InteropServices;
using MarketDataParser.Abstractions;
using MarketDataParser.Internal;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用 Marshal.PtrToStructure 实现
/// </summary>
public sealed class MarketDataFieldMarshalPtrToStructure : IMarketDataFieldParser
{
    /// <summary>
    /// bytes 字节数据转换为MarketDataField
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < 312)
        {
            throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
        }

        // 固定字节数组并获取指针
        GCHandle handle = GCHandle.Alloc(bytes.ToArray(), GCHandleType.Pinned);
        try
        {
            // 将指针转换为结构体
            var marketDataStruct = Marshal.PtrToStructure<MarketDataStruct>(handle.AddrOfPinnedObject());
            var marketDataField = MarketDataStructConverter.ConvertToMarketDataField(marketDataStruct);
            return marketDataField;
        }
        finally
        {
            // 释放固定内存
            handle.Free();
        }
    }
}