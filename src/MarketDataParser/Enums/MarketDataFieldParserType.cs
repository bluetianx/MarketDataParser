namespace MarketDataParser.Enums;

/// <summary>
/// Parser 枚举类型，用于创建不同的parser
/// </summary>
public enum MarketDataFieldParserType
{
    /// <summary>
    /// MarketDataFieldBitConverter
    /// </summary>
    BitConverter = 0,
    
    /// <summary>
    /// MarketDataFieldBinaryPrimitives
    /// </summary>
    BinaryPrimitives = 1,
    
    /// <summary>
    /// MarketDataFieldMemoryMarshalRead
    /// </summary>
    MemoryMarshalRead = 2,
    
    
    /// <summary>
    /// MarketDataFieldMemoryMarshalCast
    /// </summary>
    MemoryMarshalCast = 3,
    
    /// <summary>
    /// MarketDataFieldBinaryReader
    /// </summary>
    BinaryReader = 4,
    
    /// <summary>
    /// MarketDataFieldBinaryReaderSkipLocalsInit
    /// </summary>
    BinaryReaderSkipLocalsInit = 5,
    
    /// <summary>
    /// MarketDataFieldUnsafeCodePtr
    /// </summary>
    UnsafeCodePtr = 6,
    
    /// <summary>
    /// MarketDataFieldMarshalPtrToStructure
    /// </summary>
    MarshalPtrToStructure = 7,
    
    /// <summary>
    /// MarketDataFieldBitConverterPerf
    /// </summary>
    BitConverterPerf = 8,
    
    /// <summary>
    /// MarketDataFieldBitConverterSourceGen
    /// </summary>
    BitConverterSourceGen = 9,
}