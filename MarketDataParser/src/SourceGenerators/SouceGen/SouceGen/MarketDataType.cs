namespace SouceGen;

// 数据类型枚举
internal enum MarketDataType
{
    None,
    Int8, // 8 位有符号整数
    UInt8, // 8 位无符号整数
    Int16, // 16 位有符号整数
    UInt16, // 16 位无符号整数
    Int32, // 32 位有符号整数
    UInt32, // 32 位无符号整数
    Int64, // 64 位有符号整数
    UInt64, // 64 位无符号整数
    Float, // 单精度浮点数
    Double, // 双精度浮点数
    String, // 字符串（固定长度）
    Char, // 单个字符
    Bool, // 布尔值
}