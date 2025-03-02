using System.Buffers.Binary;
using System.Text;
using MarketDataParser.Abstractions;

namespace MarketDataParser.Parsers;

/// <summary>
/// 用 BinaryPrimitives 实现 parser
/// </summary>
public sealed class MarketDataFieldBinaryPrimitives : IMarketDataFieldParser
{
    /// <summary>
    /// 字节序列是否是小端
    /// </summary>
    private const bool IsLittleEndian = true;

    public MarketDataField MapFrom(in ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < 312)
        {
            throw new ArgumentException("字节数组长度不正确，至少需要 312 字节。");
        }

        var field = new MarketDataField();
        int offset = 0;

       
        field.CheckFlag = (uint)(IsLittleEndian
            ? BinaryPrimitives.ReadUInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadUInt64BigEndian(bytes.Slice(offset, 8)));
        offset += 8;

        
        field.LastPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;

        
        field.Volume = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;

        
        field.UpperLimitPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;

        
        field.LowerLimitPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.PreSettlementPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.TimeStamp = IsLittleEndian
            ? BinaryPrimitives.ReadUInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadUInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.OpenPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.ClosePice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.HighestPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.LowestPrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.Turnover = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.OpenInterest = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.PreClosePrice = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidPrice1 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidVolume1 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskPrice1 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskVolume1 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidPrice2 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidVolume2 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskPrice2 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskVolume2 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidPrice3 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidVolume3 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskPrice3 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskVolume3 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidPrice4 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidVolume4 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskPrice4 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskVolume4 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidPrice5 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.BidVolume5 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskPrice5 = IsLittleEndian
            ? BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.AskVolume5 = IsLittleEndian
            ? BinaryPrimitives.ReadInt64LittleEndian(bytes.Slice(offset, 8))
            : BinaryPrimitives.ReadInt64BigEndian(bytes.Slice(offset, 8));
        offset += 8;
        
        field.MillSec = IsLittleEndian
            ? BinaryPrimitives.ReadInt16LittleEndian(bytes.Slice(offset, 2))
            : BinaryPrimitives.ReadInt16BigEndian(bytes.Slice(offset, 2));
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