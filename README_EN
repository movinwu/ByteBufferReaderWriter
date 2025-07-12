# ByteBufferReaderWriter - Unity Byte Buffer Read/Write Library

![Unity](https://img.shields.io/badge/Unity-2021.3+-black?logo=unity) ![License](https://img.shields.io/badge/License-MIT-green)

ByteBufferReaderWriter is a high-performance byte buffer read/write library designed for Unity game engine. It supports serialization and deserialization of primitive data types, strings, and multi-dimensional arrays, with automatic handling of big-endian/little-endian cross-platform compatibility.

## Features

- 🧩 **Comprehensive Type Support**：bool、byte、sbyte、short、ushort、int、uint、long、ulong、float、double、string
- 🚀 **Efficient Array Handling**：Supports 1D and 2D arrays (including jagged arrays)
- 🌐 **Cross-platform Endianness**：Automatic handling of endian conversion (supports big-endian platforms like PS3/Wii/WiiU)
- ⚡ **High Performance**：Optimized with pointer operations and memory copying
- 📦 **Dynamic Buffer**：Automatically expands buffer size during writing
- 🔒 **Safe Boundary Checks**：Prevents buffer overflow

## Installation

1. Add the following files to your project:
   - `ByteBufferReader.cs`
   - `ByteBufferWriter.cs`
2. Add namespace reference in your code:
   ```csharp
   using ByteBuffer;
   ```

## Basic Usage

### Writing Example
```csharp
// Create writer (initial capacity 1024 bytes)
var writer = new ByteBufferWriter();

// Write primitive types
writer.WriteBool(true);
writer.WriteInt32(42);
writer.WriteSingle(3.14f);
writer.WriteString("Hello World");

// Write 1D array
int[] intArray = { 1, 2, 3, 4 };
writer.WriteInt32Array(intArray);

// Write 2D array
string[][] strArrayArray = {
    new[] { "A", "B" },
    new[] { "C", "D", "E" }
};
writer.WriteStringArrayArray(strArrayArray);

// Get final byte data
byte[] finalBuffer = writer.ToArray();\
```

### Reading Example
```csharp
// Create reader from byte array
var reader = new ByteBufferReader(finalBuffer);

// Read primitive types
bool b = reader.ReadBool();
int num = reader.ReadInt32();
float pi = reader.ReadSingle();
string text = reader.ReadString();

// Read 1D array
int[] restoredArray = reader.ReadInt32Array();

// Read 2D array
string[][] restoredStrArrayArray = reader.ReadStringArrayArray();
```

## Supported Array Types

| Method Name               | Return Type   | Corresponding Write Method |
|---------------------------|---------------|----------------------------|
| `ReadByteArray()`         | `byte[]`      | `WriteByteArray()`         |
| `ReadSByteArray()`        | `sbyte[]`     | `WriteSByteArray()`        |
| `ReadInt16Array()`        | `short[]`     | `WriteInt16Array()`        |
| `ReadUInt16Array()`       | `ushort[]`    | `WriteUInt16Array()`       |
| `ReadInt32Array()`        | `int[]`       | `WriteInt32Array()`        |
| `ReadUInt32Array()`       | `uint[]`      | `WriteUInt32Array()`       |
| `ReadInt64Array()`        | `long[]`      | `WriteInt64Array()`        |
| `ReadUInt64Array()`       | `ulong[]`     | `WriteUInt64Array()`       |
| `ReadSingleArray()`       | `float[]`     | `WriteSingleArray()`       |
| `ReadDoubleArray()`       | `double[]`    | `WriteDoubleArray()`       |
| `ReadBoolArray()`         | `bool[]`      | `WriteBoolArray()`         |
| `ReadStringArray()`       | `string[]`    | `WriteStringArray()`       |
| `ReadByteArrayArray()`    | `byte[][]`    | `WriteByteArrayArray()`    |
| `ReadSByteArrayArray()`   | `sbyte[][]`   | `WriteSByteArrayArray()`   |
| `ReadInt16ArrayArray()`   | `short[][]`   | `WriteInt16ArrayArray()`   |
| `ReadUInt16ArrayArray()`  | `ushort[][]`  | `WriteUInt16ArrayArray()`  |
| `ReadInt32ArrayArray()`   | `int[][]`     | `WriteInt32ArrayArray()`   |
| `ReadUInt32ArrayArray()`  | `uint[][]`    | `WriteUInt32ArrayArray()`  |
| `ReadInt64ArrayArray()`   | `long[][]`    | `WriteInt64ArrayArray()`   |
| `ReadUInt64ArrayArray()`  | `ulong[][]`   | `WriteUInt64ArrayArray()`  |
| `ReadSingleArrayArray()`  | `float[][]`   | `WriteSingleArrayArray()`  |
| `ReadDoubleArrayArray()`  | `double[][]`  | `WriteDoubleArrayArray()`  |
| `ReadBoolArrayArray()`    | `bool[][]`    | `WriteBoolArrayArray()`    |
| `ReadStringArrayArray()`  | `string[][]`  | `WriteStringArrayArray()`  |

## Performance Tips

1. **Pre-allocate Buffer**：Specify capacity when known:
   ```csharp
   // Pre-allocate 4KB buffer
   var writer = new ByteBufferWriter(4096);
   ```
2. **Reuse Reader**：Avoid repeated reader creation:
   ```csharp
   var reader = new ByteBufferReader();
   // ...
   reader.ResetWriter(); // Reset read position
   ```
3. **Batch Operations**： Prefer array methods over single element operations

## Platform Compatibility

- **Automatic Big-Endian Detection:**：
  - PlayStation 3
  - Wii
  - Wii U
- **Supports All Unity Platforms:**：
  - Windows/Mac/Linux
  - iOS/Android
  - Major consoles (PS4/PS5, Xbox One/Xbox Series X|S, Nintendo Switch)
  - WebGL (via Unity WebGL export)
- **Endianness Transparency:**：
  - Little-endian platforms (x86/x64/ARM) use native memory access
  - Big-endian platforms automatically convert byte order
  - Data stored in consistent little-endian format
 
  ## Technical Implementation

  ### Endian Handling
  ```csharp
  #if BIG_ENDIAN
  // Big-endian platform handling
  byte* p = ptr + pointer;
  p[0] = (byte)data;
  p[1] = (byte)(data >> 8);
  // ...
  #else
  // Little-endian direct memory access
  *(int*)(ptr + pointer) = data;
  #endif
  ```

  ### Safe Memory Access
  ```csharp
  fixed (byte* ptr = _buffer)
  {
      // Safe pointer operations
  }
  ```

  ### Dynamic Buffer Expansion
  ```csharp
  if (_writePointer + advance > _length)
  {
      // Auto-expand logic (double growth)
      var newLength = Mathf.Max(4, _length * 2);
      var newBuffer = new byte[newLength];
      System.Buffer.BlockCopy(_buffer, 0, newBuffer, 0, _writePointer);
      _buffer = newBuffer;
  }
  ```

  ## Author Information

- **Creator**: movin
- **Creation Date**: 2025/05/07
- **Maintenance**: 
  Welcome to submit issues and pull requests  

## License

This project is licensed under the **[MIT License](LICENSE)** :

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

### License Summary:
- ✅ **Permits**commercial use  
- ✅ **Permits**modification and distribution  
- ✅ **Permits**private use  
- ✅ **No liability**clause  
- ❌ **Requires**copyright notice preservation  
- ❌ **No warranty**provided
