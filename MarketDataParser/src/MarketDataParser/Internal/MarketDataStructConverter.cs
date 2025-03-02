using System.Runtime.CompilerServices;
using System.Text;

namespace MarketDataParser.Internal;

/// <summary>
/// MarketDataStruct -> MarketDataField 转换
/// </summary>
internal static class MarketDataStructConverter
{
    /// <summary>
    /// 转换成 MarketDataField类型
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MarketDataField ConvertToMarketDataField(MarketDataStruct marketDataStruct)
    {
        unsafe
        {
            var marketDataField = new MarketDataField
            {
                CheckFlag     = (uint)marketDataStruct.CheckFlag,
                LastPrice     = marketDataStruct.LastPrice,
                Volume        = marketDataStruct.Volume,
                UpperLimitPrice = marketDataStruct.UpperLimitPrice,
                LowerLimitPrice = marketDataStruct.LowerLimitPrice,
                PreSettlementPrice = marketDataStruct.PreSettlementPrice,
                TimeStamp     = marketDataStruct.TimeStamp,
                OpenPrice     = marketDataStruct.OpenPrice,
                ClosePice     = marketDataStruct.ClosePice,
                HighestPrice  = marketDataStruct.HighestPrice,
                LowestPrice   = marketDataStruct.LowestPrice,
                Turnover      = marketDataStruct.Turnover,
                OpenInterest  = marketDataStruct.OpenInterest,
                PreClosePrice = marketDataStruct.PreClosePrice,
                BidPrice1     = marketDataStruct.BidPrice1,
                BidVolume1    = marketDataStruct.BidVolume1,
                AskPrice1     = marketDataStruct.AskPrice1,
                AskVolume1    = marketDataStruct.AskVolume1,
                BidPrice2     = marketDataStruct.BidPrice2,
                BidVolume2    = marketDataStruct.BidVolume2,
                AskPrice2     = marketDataStruct.AskPrice2,
                AskVolume2    = marketDataStruct.AskVolume2,
                BidPrice3     = marketDataStruct.BidPrice3,
                BidVolume3    = marketDataStruct.BidVolume3,
                AskPrice3     = marketDataStruct.AskPrice3,
                AskVolume3    = marketDataStruct.AskVolume3,
                BidPrice4     = marketDataStruct.BidPrice4,
                BidVolume4    = marketDataStruct.BidVolume4,
                AskPrice4     = marketDataStruct.AskPrice4,
                AskVolume4    = marketDataStruct.AskVolume4,
                BidPrice5     = marketDataStruct.BidPrice5,
                BidVolume5    = marketDataStruct.BidVolume5,
                AskPrice5     = marketDataStruct.AskPrice5,
                AskVolume5    = marketDataStruct.AskVolume5,
                MillSec       = marketDataStruct.MillSec,
                InstrumentID  = Encoding.UTF8.GetString(marketDataStruct.InstrumentID,24).TrimEnd('\0'),
                UpdateTime    = Encoding.UTF8.GetString(marketDataStruct.UpdateTime,11).TrimEnd('\0'),
                TradingPhase  = (char)marketDataStruct.TradingPhase,
                MdType        = (char)marketDataStruct.MdType
            };
            return marketDataField;
        }
    }
}