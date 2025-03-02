using System.Runtime.CompilerServices;
using System.Text;
using MarketDataParser.Abstractions;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用 BitConverter  方式实现 MapFrom，并优化了性能，减少大小端检查 和变量初始化
/// </summary>
public sealed class MarketDataFieldBitConverterPerf : IMarketDataFieldParser
{
    /// <summary>
    /// bytes 字节数据转换为MarketDataField
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    [SkipLocalsInit]
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < 312)
        {
            throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
        }

        var field = new MarketDataField();
        int offset = 0;

        // 读取 CheckFlag 
        field.CheckFlag = (uint)BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 LastPrice 
        field.LastPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 Volume 
        field.Volume = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 UpperLimitPrice 
        field.UpperLimitPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 LowerLimitPrice 
        field.LowerLimitPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 PreSettlementPrice 
        field.PreSettlementPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 TimeStamp 
        field.TimeStamp = BitConverter.ToUInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 OpenPrice 
        field.OpenPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 ClosePice 
        field.ClosePice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 HighestPrice 
        field.HighestPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 LowestPrice 
        field.LowestPrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 Turnover 
        field.Turnover = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 OpenInterest 
        field.OpenInterest = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 PreClosePrice 
        field.PreClosePrice = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidPrice1 
        field.BidPrice1 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidVolume1 
        field.BidVolume1 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskPrice1 
        field.AskPrice1 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskVolume1 
        field.AskVolume1 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidPrice2 
        field.BidPrice2 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidVolume2 
        field.BidVolume2 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskPrice2 
        field.AskPrice2 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskVolume2 
        field.AskVolume2 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidPrice3 
        field.BidPrice3 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidVolume3 
        field.BidVolume3 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskPrice3 
        field.AskPrice3 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskVolume3 
        field.AskVolume3 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidPrice4 
        field.BidPrice4 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidVolume4 
        field.BidVolume4 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskPrice4 
        field.AskPrice4 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskVolume4 
        field.AskVolume4 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidPrice5 
        field.BidPrice5 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 BidVolume5 
        field.BidVolume5 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskPrice5 
        field.AskPrice5 = BitConverter.ToDouble(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 AskVolume5 
        field.AskVolume5 = BitConverter.ToInt64(bytes.Slice(offset, 8));
        offset += 8;

        // 读取 MillSec 
        field.MillSec = BitConverter.ToInt16(bytes.Slice(offset, 2));
        offset += 2;

        // 读取 InstrumentID 
        field.InstrumentID = GetNullTerminatedString(bytes.Slice(offset, 24));
        offset += 24;
        
        //
        field.UpdateTime = GetNullTerminatedString(bytes.Slice(offset, 11));
        offset += 11;

        // 读取 TradingPhase 
        field.TradingPhase = (char)bytes[offset];
        offset += 1;

        // 读取 MdType 
        field.MdType = (char)bytes[offset];

        return field;
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
}