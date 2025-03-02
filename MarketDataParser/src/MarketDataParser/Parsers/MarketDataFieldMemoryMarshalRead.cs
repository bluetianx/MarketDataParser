using System.Runtime.InteropServices;
using System.Text;
using MarketDataParser.Abstractions;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用 MemoryMarshal.Read 实现
/// </summary>
public sealed class MarketDataFieldMemoryMarshalRead : IMarketDataFieldParser
{
    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < 312)
        {
            throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
        }

        var field = new MarketDataField();
        int offset = 0;


        field.CheckFlag = MemoryMarshal.Read<uint>(bytes.Slice(offset, 8));
        offset += 8;

        field.LastPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.Volume = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.UpperLimitPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.LowerLimitPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.PreSettlementPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.TimeStamp = MemoryMarshal.Read<ulong>(bytes.Slice(offset, 8));
        offset += 8;

        field.OpenPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.ClosePice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.HighestPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.LowestPrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.Turnover = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.OpenInterest = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.PreClosePrice = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidPrice1 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidVolume1 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskPrice1 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskVolume1 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidPrice2 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidVolume2 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskPrice2 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskVolume2 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidPrice3 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidVolume3 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskPrice3 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskVolume3 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidPrice4 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidVolume4 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskPrice4 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskVolume4 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidPrice5 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.BidVolume5 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskPrice5 = MemoryMarshal.Read<double>(bytes.Slice(offset, 8));
        offset += 8;

        field.AskVolume5 = MemoryMarshal.Read<long>(bytes.Slice(offset, 8));
        offset += 8;

        field.MillSec = MemoryMarshal.Read<short>(bytes.Slice(offset, 2));
        offset += 2;

        field.InstrumentID = Encoding.UTF8.GetString(bytes.Slice(offset, 24)).TrimEnd('\0');
        offset += 24;

        field.UpdateTime = Encoding.UTF8.GetString(bytes.Slice(offset, 11)).TrimEnd('\0');
        offset += 11;

        field.TradingPhase = (char)bytes[offset];
        offset += 1;

        field.MdType = (char)bytes[offset];

        return field;
    }
}