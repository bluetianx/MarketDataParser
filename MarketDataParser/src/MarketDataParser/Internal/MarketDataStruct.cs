using System.Runtime.InteropServices;
using System.Text;

namespace MarketDataParser.Internal;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal unsafe struct MarketDataStruct
{
    public ulong CheckFlag;
    public double LastPrice;
    public long Volume;
    public double UpperLimitPrice;
    public double LowerLimitPrice;
    public double PreSettlementPrice;
    public ulong TimeStamp;
    public double OpenPrice;
    public double ClosePice;
    public double HighestPrice;
    public double LowestPrice;
    public double Turnover;
    public double OpenInterest;
    public double PreClosePrice;
    public double BidPrice1;
    public long BidVolume1;
    public double AskPrice1;
    public long AskVolume1;
    public double BidPrice2;
    public long BidVolume2;
    public double AskPrice2;
    public long AskVolume2;
    public double BidPrice3;
    public long BidVolume3;
    public double AskPrice3;
    public long AskVolume3;
    public double BidPrice4;
    public long BidVolume4;
    public double AskPrice4;
    public long AskVolume4;
    public double BidPrice5;
    public long BidVolume5;
    public double AskPrice5;
    public long AskVolume5;
    public short MillSec;
    
    public fixed byte InstrumentID[24];
    public fixed byte UpdateTime[11];
    
    public byte TradingPhase;
    public byte MdType;
    
}