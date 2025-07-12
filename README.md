# ByteBufferReaderWriter - Unity字节缓冲区读写库

![Unity](https://img.shields.io/badge/Unity-2021.3+-black?logo=unity) ![License](https://img.shields.io/badge/License-MIT-green)

ByteBufferReaderWriter是一个高效的字节缓冲区读写库，专为Unity游戏引擎设计，支持基本数据类型、字符串以及多维数组的序列化与反序列化，自动处理大端序/小端序跨平台兼容性问题。

## 功能特性

- 🧩 **类型全面支持**：bool、byte、sbyte、short、ushort、int、uint、long、ulong、float、double、string
- 🚀 **高效数组处理**：支持一维和二维数组（包括交错数组）
- 🌐 **跨平台字节序**：自动处理大小端序转换（支持PS3/Wii/WiiU等大端序平台）
- ⚡ **高性能**：使用指针操作和内存复制优化性能
- 📦 **动态缓冲区**：写入时自动扩展缓冲区大小
- 🔒 **安全边界检查**：防止缓冲区溢出

## 安装方法

1. 将以下文件添加到Unity项目的`Assets/Plugins/`目录：
   - `ByteBufferReader.cs`
   - `ByteBufferWriter.cs`
2. 在代码中添加命名空间引用：
   ```csharp
   using ByteBuffer;
   ```

## 基本用法

### 数据写入示例
```csharp
// 创建写入器（初始容量1024字节）
var writer = new ByteBufferWriter();

// 写入基本类型
writer.WriteBool(true);
writer.WriteInt32(42);
writer.WriteSingle(3.14f);
writer.WriteString("Hello World");

// 写入一维数组
int[] intArray = { 1, 2, 3, 4 };
writer.WriteInt32Array(intArray);

// 写入二维数组
string[][] strArrayArray = {
    new[] { "A", "B" },
    new[] { "C", "D", "E" }
};
writer.WriteStringArrayArray(strArrayArray);

// 获取最终字节数据
byte[] finalBuffer = writer.ToArray();\
```

### 数据读取示例
```csharp
// 从字节数组创建读取器
var reader = new ByteBufferReader(finalBuffer);

// 读取基本类型
bool b = reader.ReadBool();
int num = reader.ReadInt32();
float pi = reader.ReadSingle();
string text = reader.ReadString();

// 读取一维数组
int[] restoredArray = reader.ReadInt32Array();

// 读取二维数组
string[][] restoredStrArrayArray = reader.ReadStringArrayArray();
```

## 支持的数组类型

| 方法名                     | 返回类型       | 对应写入方法               |
|---------------------------|---------------|--------------------------|
| `ReadByteArray()`         | `byte[]`      | `WriteByteArray()`       |
| `ReadSByteArray()`        | `sbyte[]`     | `WriteSByteArray()`      |
| `ReadInt16Array()`        | `short[]`     | `WriteInt16Array()`      |
| `ReadUInt16Array()`       | `ushort[]`    | `WriteUInt16Array()`     |
| `ReadInt32Array()`        | `int[]`       | `WriteInt32Array()`      |
| `ReadUInt32Array()`       | `uint[]`      | `WriteUInt32Array()`     |
| `ReadInt64Array()`        | `long[]`      | `WriteInt64Array()`      |
| `ReadUInt64Array()`       | `ulong[]`     | `WriteUInt64Array()`     |
| `ReadSingleArray()`       | `float[]`     | `WriteSingleArray()`     |
| `ReadDoubleArray()`       | `double[]`    | `WriteDoubleArray()`     |
| `ReadBoolArray()`         | `bool[]`      | `WriteBoolArray()`       |
| `ReadStringArray()`       | `string[]`    | `WriteStringArray()`     |
| `ReadByteArrayArray()`    | `byte[][]`    | `WriteByteArrayArray()`  |
| `ReadSByteArrayArray()`   | `sbyte[][]`   | `WriteSByteArrayArray()` |
| `ReadInt16ArrayArray()`   | `short[][]`   | `WriteInt16ArrayArray()` |
| `ReadUInt16ArrayArray()`  | `ushort[][]`  | `WriteUInt16ArrayArray()`|
| `ReadInt32ArrayArray()`   | `int[][]`     | `WriteInt32ArrayArray()` |
| `ReadUInt32ArrayArray()`  | `uint[][]`    | `WriteUInt32ArrayArray()`|
| `ReadInt64ArrayArray()`   | `long[][]`    | `WriteInt64ArrayArray()` |
| `ReadUInt64ArrayArray()`  | `ulong[][]`   | `WriteUInt64ArrayArray()`|
| `ReadSingleArrayArray()`  | `float[][]`   | `WriteSingleArrayArray()`|
| `ReadDoubleArrayArray()`  | `double[][]`  | `WriteDoubleArrayArray()`|
| `ReadBoolArrayArray()`    | `bool[][]`    | `WriteBoolArrayArray()`  |
| `ReadStringArrayArray()`  | `string[][]`  | `WriteStringArrayArray()`|

## 性能提示

1. **预分配缓冲区**：已知数据大小时，初始化时指定容量：
   ```csharp
   // 预分配4KB缓冲区
   var writer = new ByteBufferWriter(4096);
   ```
2. **复用读取器**：避免重复创建读取器实例
   ```csharp
   var reader = new ByteBufferReader();
   // ...
   reader.ResetWriter(); // 重置读取位置
   ```
3. **批量操作**：优先使用数组方法而非单个元素操作

## 平台兼容性

- **自动检测并处理大端序平台**：
  - PlayStation 3
  - Wii
  - Wii U
- **支持所有Unity兼容平台**：
  - Windows/Mac/Linux
  - iOS/Android
  - 主流游戏主机（PS4/PS5, Xbox One/Xbox Series X|S, Nintendo Switch）
  - WebGL（通过Unity WebGL导出）
- **字节序透明处理**：
  - 小端序平台（x86/x64/ARM）使用原生内存访问
  - 大端序平台自动进行字节序转换
  - 统一使用小端序格式存储数据
 
  ## 技术实现

  ### 字节序处理
  ```csharp
  #if BIG_ENDIAN
  // 大端序平台特殊处理
  byte* p = ptr + pointer;
  p[0] = (byte)data;
  p[1] = (byte)(data >> 8);
  // ...
  #else
  // 小端序平台直接内存访问
  *(int*)(ptr + pointer) = data;
  #endif
  ```

  ### 安全内存访问
  ```csharp
  fixed (byte* ptr = _buffer)
  {
      // 安全的指针操作
  }
  ```

  ### 动态缓冲区拓展
  ```csharp
  if (_writePointer + advance > _length)
  {
      // 自动扩容逻辑（双倍增长）
      var newLength = Mathf.Max(4, _length * 2);
      var newBuffer = new byte[newLength];
      System.Buffer.BlockCopy(_buffer, 0, newBuffer, 0, _writePointer);
      _buffer = newBuffer;
  }
  ```

  ## 作者信息

- **创建者**: movin
- **创建日期**: 2025/05/07
- **维护说明**: 
  欢迎提交Issue报告问题或提出改进建议  
  接受Pull Request贡献代码  
  联系方式: movin@example.com

## 使用许可

本项目采用 **[MIT License](LICENSE)** 授权协议：

```text
MIT License

Copyright (c) 2025 movin

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

### 许可说明：
- ✅ **允许**商业用途  
- ✅ **允许**修改和分发  
- ✅ **允许**私有使用  
- ✅ **无责任**条款  
- ❌ **保留**版权声明  
- ❌ **不提供**质量担保
