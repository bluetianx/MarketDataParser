using MarketDataParser.Enums;
using MarketDataParser.Parsers;

namespace MarketDataParser.Test;

public class MarketDataFieldParserUnitTest
{
    private readonly MarketDataFieldParserFactory _factory = new();

    [Fact]
    public void Test_MarketDataFieldBitConverter()
    {
        var parser = _factory.Create(MarketDataFieldParserType.BitConverter);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }

    [Fact]
    public void Test_MarketDataFieldBinaryPrimitives()
    {
        var parser = _factory.Create(MarketDataFieldParserType.BinaryPrimitives);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldMemoryMarshalRead()
    {
        var parser = _factory.Create(MarketDataFieldParserType.MemoryMarshalRead);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldMemoryMarshalCast()
    {
        var parser = _factory.Create(MarketDataFieldParserType.MemoryMarshalCast);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldBinaryReader()
    {
        var parser = _factory.Create(MarketDataFieldParserType.BinaryReader);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldBinaryReaderSkipLocalsInit()
    {
        var parser = _factory.Create(MarketDataFieldParserType.BinaryReaderSkipLocalsInit);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldUnsafeCodePtr()
    {
        var parser = _factory.Create(MarketDataFieldParserType.UnsafeCodePtr);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldMarshalPtrToStructure()
    {
        var parser = _factory.Create(MarketDataFieldParserType.MarshalPtrToStructure);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldBitConverterPerf()
    {
        var parser = _factory.Create(MarketDataFieldParserType.BitConverterPerf);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }
    
    [Fact]
    public void Test_MarketDataFieldBitConverterSourceGen()
    {
        var parser = _factory.Create(MarketDataFieldParserType.BitConverterSourceGen);
        var marketData = parser.MapFrom(_testMarketDataBytes);

        Assert.True(ValidData(marketData));
    }

    /// <summary>
    /// 校验 parser 的结果 
    /// </summary>
    /// <param name="marketDataField"></param>
    /// <returns></returns>
    private bool ValidData(MarketDataField marketDataField)
    {
        Assert.NotNull(marketDataField);

        Assert.Equal(_testMarketData.CheckFlag, marketDataField.CheckFlag);

        Assert.Equal(_testMarketData.LastPrice, marketDataField.LastPrice);

        Assert.Equal(_testMarketData.Volume, marketDataField.Volume);

        Assert.Equal(_testMarketData.UpperLimitPrice, marketDataField.UpperLimitPrice);

        Assert.Equal(_testMarketData.LowerLimitPrice, marketDataField.LowerLimitPrice);

        Assert.Equal(_testMarketData.PreSettlementPrice, marketDataField.PreSettlementPrice);

        Assert.Equal(_testMarketData.TimeStamp, marketDataField.TimeStamp);

        Assert.Equal(_testMarketData.OpenPrice, marketDataField.OpenPrice);

        Assert.Equal(_testMarketData.ClosePice, marketDataField.ClosePice);

        Assert.Equal(_testMarketData.HighestPrice, marketDataField.HighestPrice);

        Assert.Equal(_testMarketData.LowestPrice, marketDataField.LowestPrice);

        Assert.Equal(_testMarketData.Turnover, marketDataField.Turnover);

        Assert.Equal(_testMarketData.OpenInterest, marketDataField.OpenInterest);

        Assert.Equal(_testMarketData.PreClosePrice, marketDataField.PreClosePrice);

        Assert.Equal(_testMarketData.BidPrice1, marketDataField.BidPrice1);

        Assert.Equal(_testMarketData.BidVolume1, marketDataField.BidVolume1);

        Assert.Equal(_testMarketData.AskPrice1, marketDataField.AskPrice1);

        Assert.Equal(_testMarketData.AskVolume1, marketDataField.AskVolume1);

        Assert.Equal(_testMarketData.BidPrice2, marketDataField.BidPrice2);

        Assert.Equal(_testMarketData.BidVolume2, marketDataField.BidVolume2);

        Assert.Equal(_testMarketData.AskPrice2, marketDataField.AskPrice2);

        Assert.Equal(_testMarketData.AskVolume2, marketDataField.AskVolume2);

        Assert.Equal(_testMarketData.BidPrice3, marketDataField.BidPrice3);

        Assert.Equal(_testMarketData.BidVolume3, marketDataField.BidVolume3);

        Assert.Equal(_testMarketData.AskPrice3, marketDataField.AskPrice3);

        Assert.Equal(_testMarketData.AskVolume3, marketDataField.AskVolume3);

        Assert.Equal(_testMarketData.BidPrice4, marketDataField.BidPrice4);

        Assert.Equal(_testMarketData.BidVolume4, marketDataField.BidVolume4);

        Assert.Equal(_testMarketData.AskPrice4, marketDataField.AskPrice4);

        Assert.Equal(_testMarketData.AskVolume4, marketDataField.AskVolume4);

        Assert.Equal(_testMarketData.BidPrice5, marketDataField.BidPrice5);

        Assert.Equal(_testMarketData.BidVolume5, marketDataField.BidVolume5);

        Assert.Equal(_testMarketData.AskPrice5, marketDataField.AskPrice5);

        Assert.Equal(_testMarketData.AskVolume5, marketDataField.AskVolume5);

        Assert.Equal(_testMarketData.MillSec, marketDataField.MillSec);

        Assert.Equal(_testMarketData.InstrumentID, marketDataField.InstrumentID);

        Assert.Equal(_testMarketData.UpdateTime, marketDataField.UpdateTime);

        Assert.Equal(_testMarketData.TradingPhase, marketDataField.TradingPhase);

        Assert.Equal(_testMarketData.MdType, marketDataField.MdType);

        return true;
    }

    
    #region 测试数据

    private readonly byte[] _testMarketDataBytes = Convert.FromHexString(
        "AAAAAAAA000000006666666666263C407A390A0000000000D7A3703D0A573F40A4703D0AD7A3394000000000000000008A311BD89BD42F00AE47E17A142E3C406666666666263C403D0AD7A3707D3C403333333333F33B4000000050D505724100000000000000003D0AD7A3707D3C406666666666263C406C07000000000000EC51B81E852B3C40C800000000000000A4703D0AD7233C409001000000000000F6285C8FC2353C402C010000000000001F85EB51B81E3C409001000000000000B81E85EB51383C40CC100000000000009A99999999193C40840300000000000085EB51B81E453C40640000000000000014AE47E17A143C40DC0500000000000048E17A14AE473C4024130000000000008C013630333035312E534800000000000000000000000000000030393A35343A3137000000320000");

    private readonly MarketDataField _testMarketData = new()
    {
        CheckFlag = 2863311530,
        LastPrice = 28.15,
        Volume = 670074,
        UpperLimitPrice = 31.34,
        LowerLimitPrice = 25.64,
        PreSettlementPrice = 0,
        TimeStamp = 13463089716081034,
        OpenPrice = 28.18,
        ClosePice = 28.15,
        HighestPrice = 28.49,
        LowestPrice = 27.95,
        Turnover = 18898261,
        OpenInterest = 0,
        PreClosePrice = 28.49,
        BidPrice1 = 28.15,
        BidVolume1 = 1900,
        AskPrice1 = 28.17,
        AskVolume1 = 200,
        BidPrice2 = 28.14,
        BidVolume2 = 400,
        AskPrice2 = 28.21,
        AskVolume2 = 300,
        BidPrice3 = 28.12,
        BidVolume3 = 400,
        AskPrice3 = 28.22,
        AskVolume3 = 4300,
        BidPrice4 = 28.1,
        BidVolume4 = 900,
        AskPrice4 = 28.27,
        AskVolume4 = 100,
        BidPrice5 = 28.08,
        BidVolume5 = 1500,
        AskPrice5 = 28.28,
        AskVolume5 = 4900,
        MillSec = 396,
        InstrumentID = "603051.SH",
        UpdateTime = "09:54:17",
        TradingPhase = '2',
    };

    #endregion
}