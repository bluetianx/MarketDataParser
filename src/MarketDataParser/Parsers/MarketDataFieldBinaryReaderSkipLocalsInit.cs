using System.Runtime.CompilerServices;
using MarketDataParser.Abstractions;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用 BinaryReader 方式实现 ,并用 SkipLocalsInit 进行了优化
/// </summary>
public sealed class MarketDataFieldBinaryReaderSkipLocalsInit : IMarketDataFieldParser
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

        using (var stream = new MemoryStream(bytes.ToArray()))
        using (var reader = new BinaryReader(stream))
        {
            var field = new MarketDataField();
            field.CheckFlag = (uint)reader.ReadUInt64();
            field.LastPrice = reader.ReadDouble();
            field.Volume = reader.ReadInt64();
            field.UpperLimitPrice = reader.ReadDouble();
            field.LowerLimitPrice = reader.ReadDouble();
            field.PreSettlementPrice = reader.ReadDouble();
            field.TimeStamp = reader.ReadUInt64();
            field.OpenPrice = reader.ReadDouble();
            field.ClosePice = reader.ReadDouble();
            field.HighestPrice = reader.ReadDouble();
            field.LowestPrice = reader.ReadDouble();
            field.Turnover = reader.ReadDouble();
            field.OpenInterest = reader.ReadDouble();
            field.PreClosePrice = reader.ReadDouble();
            field.BidPrice1 = reader.ReadDouble();
            field.BidVolume1 = reader.ReadInt64();
            field.AskPrice1 = reader.ReadDouble();
            field.AskVolume1 = reader.ReadInt64();
            field.BidPrice2 = reader.ReadDouble();
            field.BidVolume2 = reader.ReadInt64();
            field.AskPrice2 = reader.ReadDouble();
            field.AskVolume2 = reader.ReadInt64();
            field.BidPrice3 = reader.ReadDouble();
            field.BidVolume3 = reader.ReadInt64();
            field.AskPrice3 = reader.ReadDouble();
            field.AskVolume3 = reader.ReadInt64();
            field.BidPrice4 = reader.ReadDouble();
            field.BidVolume4 = reader.ReadInt64();
            field.AskPrice4 = reader.ReadDouble();
            field.AskVolume4 = reader.ReadInt64();
            field.BidPrice5 = reader.ReadDouble();
            field.BidVolume5 = reader.ReadInt64();
            field.AskPrice5 = reader.ReadDouble();
            field.AskVolume5 = reader.ReadInt64();
            field.MillSec = reader.ReadInt16();

            var instrumentBytes = reader.ReadBytes(24);
            field.InstrumentID = System.Text.Encoding.ASCII.GetString(instrumentBytes).TrimEnd('\0');

            var updateTimeBytes = reader.ReadBytes(11);
            field.UpdateTime = System.Text.Encoding.ASCII.GetString(updateTimeBytes).TrimEnd('\0');

            //读取字符字段 
            field.TradingPhase = (char)reader.ReadByte();
            field.MdType = (char)reader.ReadByte();
            return field;
        }
    }
}