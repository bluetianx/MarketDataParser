## MarketDataParser 项目介绍
### 一、简介
MarketDataParser 基于 Net9.0版本 探索演示了多种从字节数组转换成record结构体的方式,核心代码位于src/MarketDataParser/Parsers文件夹下面。
这些方式包括：
1. MarketDataFieldBinaryPrimitives 用 BinaryPrimitives 实现 parser
2. MarketDataFieldBinaryReader 用 BinaryReader 方式实现
3. MarketDataFieldBinaryReaderSkipLocalsInit 用 BinaryReader 方式实现 ,并用 SkipLocalsInit 进行了优化
4. MarketDataFieldBitConverter 用 BitConverter  方式实现 MapFrom
5. MarketDataFieldBitConverterPerf 用 BitConverter  方式实现 MapFrom，并优化了性能，减少大小端检查 和变量初始化
6. MarketDataFieldBitConverterSourceGen BitConverter对应的 source generate 版本，可以根据MarketDataField 的字段 自动实现 MapFrom 逻辑 ，用于 MarketDataField 字段变更频繁的场景
7. MarketDataFieldMarshalPtrToStructure 用 Marshal.PtrToStructure 实现
8. MarketDataFieldMemoryMarshalCast      MemoryMarshal.Cast实现
9. MarketDataFieldMemoryMarshalRead    用 MemoryMarshal.Read 实现
10. MarketDataFieldUnsafeCodePtr      用unsafe代码直接操作指针，将字节数组的内存地址强制转换为结构体指针

### 二、项目结构

```
├── benchmarks
│   └── MarketDataParser.Benchmarks  # 运行 BenchmarkDotNet 的性能基准测试项目
├── src
│   ├── MarketDataParser             # Parser核心逻辑
│   └── SourceGenerators
│       └── SourceGen                # SourceGenerator 实现
└── tests
    └── MarketDataParser.Tests       # 单元测试，验证每种解析方式结果正确性
```

### 三、Benchmark 结果

使用 BenchmarkDotNet 对比十种解析方式的性能表现。测试环境与配置见项目内 benchmarks 目录。

```
BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.1 (24D70) [Darwin 24.3.0]
Apple M4 Pro, 1 CPU, 12 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

```
| Method                                    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------ |----------:|---------:|---------:|-------:|----------:|
| MarketDataFieldBitConverter               |  45.13 ns | 0.151 ns | 0.134 ns | 0.0468 |     392 B |
| MarketDataFieldBinaryPrimitives           |  58.66 ns | 0.714 ns | 0.667 ns | 0.0612 |     512 B |
| MarketDataFieldMemoryMarshalRead          |  57.21 ns | 0.688 ns | 0.643 ns | 0.0612 |     512 B |
| MarketDataFieldMemoryMarshalCast          |  58.37 ns | 0.174 ns | 0.146 ns | 0.0612 |     512 B |
| MarketDataFieldBinaryReader               | 156.74 ns | 0.513 ns | 0.455 ns | 0.1261 |    1056 B |
| MarketDataFieldBinaryReaderSkipLocalsInit | 155.36 ns | 0.496 ns | 0.464 ns | 0.1261 |    1056 B |
| MarketDataFieldUnsafeCodePtr              |  58.65 ns | 0.226 ns | 0.211 ns | 0.0612 |     512 B |
| MarketDataFieldMarshalPtrToStructure      | 116.30 ns | 0.440 ns | 0.367 ns | 0.1405 |    1176 B |
| MarketDataFieldBitConverterPerf           |  39.57 ns | 0.089 ns | 0.078 ns | 0.0468 |     392 B |
| MarketDataFieldBitConverterSourceGen      |  39.95 ns | 0.083 ns | 0.074 ns | 0.0468 |     392 B |

性能分析
 * MarketDataFieldBitConverterPerf 与 MarketDataFieldBitConverterSourceGen最快，39 ns左右
 * MarketDataFieldBinaryPrimitives、MarketDataFieldMemoryMarshalRead 、MarketDataFieldMemoryMarshalCast 基本上性能相当
 * MarketDataFieldBinaryReader 与 MarketDataFieldBinaryReaderSkipLocalsInit 比较慢，并且占用内存比较大，因为 会创建额外的BinaryReader与MemoryStream对象
   BinaryReader 的每个读取方法（如 ReadDouble()、ReadInt64()）都是虚方法调用，比直接使用 BitConverter 或 MemoryMarshal 有更高的调用开销，使用 MemoryStream 时会有数组复制
 * MarketDataFieldMarshalPtrToStructure 性能较差 且占用内存最高，该方法存在反射 和 内存复制操作

### 四、总结与建议
推荐使用 BitConverter方式实现解析，性能最佳，且代码简洁；
建议注意大小端 (Endianness) 是否符合预期，如果不符合就要进行翻转处理
如果字段变更频繁，可以考虑使用 SourceGenerator 自动生成解析代码