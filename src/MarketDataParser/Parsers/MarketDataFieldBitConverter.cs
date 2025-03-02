using System.Text;
using MarketDataParser.Abstractions;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用 BitConverter  方式实现 MapFrom
/// </summary>
public sealed class MarketDataFieldBitConverter : IMarketDataFieldParser
{
    /// <summary>
    /// 字节序列是否是小端
    /// </summary>
    private const bool IsLittleEndian = true;

    /// <summary>
    /// 基于 BitConverter方式实现 MapFrom ,默认按照小端序列处理
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < 312)
        {
            throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
        }

        // 检查当前系统的字节序
        bool systemIsLittleEndian = BitConverter.IsLittleEndian;

        // 计算是否需要反转字节：当数据源字节序与系统字节序不一致时反转
        bool needReverse = IsLittleEndian != systemIsLittleEndian;

        var field = new MarketDataField();
        int offset = 0;

        // 解析数值字段
        field.CheckFlag = (uint)ReadUInt64(bytes, offset, needReverse);
        offset += 8;
        field.LastPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.Volume = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.UpperLimitPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.LowerLimitPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.PreSettlementPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.TimeStamp = ReadUInt64(bytes, offset, needReverse);
        offset += 8;
        field.OpenPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.ClosePice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.HighestPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.LowestPrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.Turnover = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.OpenInterest = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.PreClosePrice = ReadDouble(bytes, offset, needReverse);
        offset += 8;

        field.BidPrice1 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.BidVolume1 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.AskPrice1 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.AskVolume1 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.BidPrice2 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.BidVolume2 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.AskPrice2 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.AskVolume2 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.BidPrice3 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.BidVolume3 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.AskPrice3 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.AskVolume3 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.BidPrice4 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.BidVolume4 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.AskPrice4 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.AskVolume4 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.BidPrice5 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.BidVolume5 = ReadInt64(bytes, offset, needReverse);
        offset += 8;
        field.AskPrice5 = ReadDouble(bytes, offset, needReverse);
        offset += 8;
        field.AskVolume5 = ReadInt64(bytes, offset, needReverse);
        offset += 8;

        field.MillSec = ReadInt16(bytes, offset, needReverse);
        offset += 2;
        
        field.InstrumentID = GetNullTerminatedString(bytes.Slice(offset, 24));
        offset += 24;
        
        field.UpdateTime = GetNullTerminatedString(bytes.Slice(offset, 11));
        offset += 11;
        
        field.TradingPhase = (char)bytes[offset];
        offset += 1;
        field.MdType = (char)bytes[offset];
        offset += 1;

        return field;
    }

    // 辅助方法：读取 double
    private static double ReadDouble(ReadOnlySpan<byte> bytes, int offset, bool reverse)
    {
        var span = bytes.Slice(offset, 8);
        if (reverse)
        {
            span = ReverseSpan(span);
        }

        return BitConverter.ToDouble(span);
    }
    /// <summary>
    /// 添加读取字符串辅助方法
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private static string GetNullTerminatedString(ReadOnlySpan<byte> bytes)
    {
        // 找到第一个 null 字符的位置
        int length = 0;
        while (length < bytes.Length && bytes[length] != 0)
        {
            length++;
        }
            
        // 只解码到 null 字符之前的部分
        return Encoding.UTF8.GetString(bytes.Slice(0, length));
    }

    // 辅助方法：读取 long
    private static long ReadInt64(ReadOnlySpan<byte> bytes, int offset, bool reverse)
    {
        var span = bytes.Slice(offset, 8);
        if (reverse)
        {
            span = ReverseSpan(span);
        }

        return BitConverter.ToInt64(span);
    }

    // 辅助方法：读取 ulong
    private static ulong ReadUInt64(ReadOnlySpan<byte> bytes, int offset, bool reverse)
    {
        var span = bytes.Slice(offset, 8);
        if (reverse)
        {
            span = ReverseSpan(span);
        }

        return BitConverter.ToUInt64(span);
    }

    // 辅助方法：读取 short
    private static short ReadInt16(ReadOnlySpan<byte> bytes, int offset, bool reverse)
    {
        var span = bytes.Slice(offset, 2);
        if (reverse)
        {
            span = ReverseSpan(span);
        }

        return BitConverter.ToInt16(span);
    }

    // 辅助方法：反转字节顺序
    private static ReadOnlySpan<byte> ReverseSpan(ReadOnlySpan<byte> span)
    {
        byte[] reversed = new byte[span.Length];
        span.CopyTo(reversed);
        Array.Reverse(reversed);
        return reversed;
    }
}