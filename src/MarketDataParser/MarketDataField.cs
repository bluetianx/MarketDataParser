using SouceGen;

namespace MarketDataParser;

public record MarketDataField
{
    /// <summary>
    /// 检验完成后，用来区分是内部产生行情还是市场行情.
    /// </summary>
    [MarketDataBitConverter(0, 8, MarketDataType.UInt64)]
    public uint CheckFlag { get; set; }

    [MarketDataBitConverter(8, 8)]
    public double LastPrice { get; set; }

    [MarketDataBitConverter(16, 8)]
    public long Volume { get; set; }

    [MarketDataBitConverter(24, 8)]
    public double UpperLimitPrice { get; set; }

    [MarketDataBitConverter(32, 8)]
    public double LowerLimitPrice { get; set; }

    [MarketDataBitConverter(40, 8)]
    public double PreSettlementPrice { get; set; }

    [MarketDataBitConverter(48, 8)]
    public ulong TimeStamp { get; set; }

    [MarketDataBitConverter(56, 8)]
    public double OpenPrice { get; set; }

    [MarketDataBitConverter(64, 8)]
    public double ClosePice { get; set; }

    [MarketDataBitConverter(72, 8)]
    public double HighestPrice { get; set; }

    [MarketDataBitConverter(80, 8)]
    public double LowestPrice { get; set; }

    [MarketDataBitConverter(88, 8)]
    public double Turnover { get; set; }

    [MarketDataBitConverter(96, 8)]
    public double OpenInterest { get; set; }

    [MarketDataBitConverter(104, 8)]
    public double PreClosePrice { get; set; }

    [MarketDataBitConverter(112, 8)]
    public double BidPrice1 { get; set; }

    [MarketDataBitConverter(120, 8)]
    public long BidVolume1 { get; set; }

    [MarketDataBitConverter(128, 8)]
    public double AskPrice1 { get; set; }

    [MarketDataBitConverter(136, 8)]
    public long AskVolume1 { get; set; }

    [MarketDataBitConverter(144, 8)]
    public double BidPrice2 { get; set; }

    [MarketDataBitConverter(152, 8)]
    public long BidVolume2 { get; set; }

    [MarketDataBitConverter(160, 8)]
    public double AskPrice2 { get; set; }

    [MarketDataBitConverter(168, 8)]
    public long AskVolume2 { get; set; }

    [MarketDataBitConverter(176, 8)]
    public double BidPrice3 { get; set; }

    [MarketDataBitConverter(184, 8)]
    public long BidVolume3 { get; set; }

    [MarketDataBitConverter(192, 8)]
    public double AskPrice3 { get; set; }

    [MarketDataBitConverter(200, 8)]
    public long AskVolume3 { get; set; }

    [MarketDataBitConverter(208, 8)]
    public double BidPrice4 { get; set; }

    [MarketDataBitConverter(216, 8)]
    public long BidVolume4 { get; set; }

    [MarketDataBitConverter(224, 8)]
    public double AskPrice4 { get; set; }

    [MarketDataBitConverter(232, 8)]
    public long AskVolume4 { get; set; }

    [MarketDataBitConverter(240, 8)]
    public double BidPrice5 { get; set; }

    [MarketDataBitConverter(248, 8)]
    public long BidVolume5 { get; set; }

    [MarketDataBitConverter(256, 8)]
    public double AskPrice5 { get; set; }

    [MarketDataBitConverter(264, 8)]
    public long AskVolume5 { get; set; }

    [MarketDataBitConverter(272, 2)]
    public short MillSec { get; set; }

    //24byte u8
    [MarketDataBitConverter(274, 24)]
    public string InstrumentID { get; set; }

    //11byte u8
    [MarketDataBitConverter(298, 11)]
    public string UpdateTime { get; set; }

    //1byte
    [MarketDataBitConverter(309, 1, MarketDataType.Char)]
    public char TradingPhase { get; set; }

    //1byte
    [MarketDataBitConverter(310, 1, MarketDataType.Char)]
    public char MdType { get; set; }
}