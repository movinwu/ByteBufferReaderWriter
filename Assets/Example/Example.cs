using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using ByteBuffer;
using Debug = UnityEngine.Debug;

public class Example : MonoBehaviour
{
    void Start()
    {
        // 测试ByteBuffer读取和写入
        var writer = new ByteBufferWriter(1024 << 10);
        
        // 写入性能测试
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 10000; i++)
        {
            writer.ResetWriter();
            
            writer.WriteStringArrayArray(new string[][]
                { new string[] { "1", "2" }, new string[] { "3", "你好，世界！" }, new string[] { "你好！世界2！！！" } });
            writer.WriteDoubleArrayArray(new double[][] { new double[] { 1.7, 1.6, 2.560 }, new double[] { -0.358, 3.14159265 } });
            writer.WriteSingleArrayArray(new float[][] { new float[] { 1.7f, 2.560f }, new float[] { -0.358f, 3.14159265f } });
            writer.WriteUInt64ArrayArray(new ulong[][] { new ulong[] { 1, 2 }, new ulong[] { 3, 4 } });
            writer.WriteInt64ArrayArray(new long[][] { new long[] { 1, 2 }, new long[] { 3, -4 } });
            writer.WriteUInt32ArrayArray(new uint[][] { new uint[] { 1, 2 }, new uint[] { 3, 4 } });
            writer.WriteInt32ArrayArray(new int[][] { new int[] { 1, 2 }, new int[] { 3, -4 } });
            writer.WriteUInt16ArrayArray(new ushort[][] { new ushort[] { 1, 2 }, new ushort[] { 3, 4 } });
            writer.WriteInt16ArrayArray(new short[][] { new short[] { 1, 2 }, new short[] { 3, -4 } });
            writer.WriteByteArrayArray(new byte[][] { new byte[] { 1, 2 }, new byte[] { 3, 4 } });
            writer.WriteSByteArrayArray(new sbyte[][] { new sbyte[] { 1, 2 }, new sbyte[] { 3, -4 } });
            writer.WriteBoolArrayArray(new bool[][] { new bool[] { true, false }, new bool[] { true, false } });
        }
        sw.Stop();
        Debug.LogError($"写入用时：{sw.ElapsedMilliseconds}-ms");
        
        
        var bytes = writer.ToArray();
        
        // 读取并打印
        StringBuilder sb = new StringBuilder();
        var reader = new ByteBufferReader(bytes);
        string[][] stringArrayArray = reader.ReadStringArrayArray();
        double[][] doubleArrayArray = reader.ReadDoubleArrayArray();
        float[][] floatArrayArray = reader.ReadSingleArrayArray();
        ulong[][] ulongArrayArray = reader.ReadUInt64ArrayArray();
        long[][] longArrayArray = reader.ReadInt64ArrayArray();
        uint[][] uintArrayArray = reader.ReadUInt32ArrayArray();
        int[][] intArrayArray = reader.ReadInt32ArrayArray();
        ushort[][] ushortArrayArray = reader.ReadUInt16ArrayArray();
        short[][] shortArrayArray = reader.ReadInt16ArrayArray();
        byte[][] byteArrayArray = reader.ReadByteArrayArray();
        sbyte[][] sbyteArrayArray = reader.ReadSByteArrayArray();
        bool[][] boolArrayArray = reader.ReadBoolArrayArray();
        
        // 读取性能测试
        sw.Restart();
        for (int i = 0; i < 10000; i++)
        {
            reader.Reset();
            stringArrayArray = reader.ReadStringArrayArray();
            doubleArrayArray = reader.ReadDoubleArrayArray();
            floatArrayArray = reader.ReadSingleArrayArray();
            ulongArrayArray = reader.ReadUInt64ArrayArray();
            longArrayArray = reader.ReadInt64ArrayArray();
            uintArrayArray = reader.ReadUInt32ArrayArray();
            intArrayArray = reader.ReadInt32ArrayArray();
            ushortArrayArray = reader.ReadUInt16ArrayArray();
            shortArrayArray = reader.ReadInt16ArrayArray();
            byteArrayArray = reader.ReadByteArrayArray();
            sbyteArrayArray = reader.ReadSByteArrayArray();
            boolArrayArray = reader.ReadBoolArrayArray();
        }
        sw.Stop();
        Debug.LogError($"读取耗时：{sw.ElapsedMilliseconds}-ms");
        
        for (int i = 0; i < stringArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < stringArrayArray[i].Length; j++)
            {
                sb.Append(stringArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < doubleArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < doubleArrayArray[i].Length; j++)
            {
                sb.Append(doubleArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < floatArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < floatArrayArray[i].Length; j++)
            {
                sb.Append(floatArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < ulongArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < ulongArrayArray[i].Length; j++)
            {
                sb.Append(ulongArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < longArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < longArrayArray[i].Length; j++)
            {
                sb.Append(longArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }
        
        sb.AppendLine();
        for (int i = 0; i < uintArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < uintArrayArray[i].Length; j++)
            {
                sb.Append(uintArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }
        
        sb.AppendLine();
        for (int i = 0; i < intArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < intArrayArray[i].Length; j++)
            {
                sb.Append(intArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }
        
        sb.AppendLine();
        for (int i = 0; i < ushortArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < ushortArrayArray[i].Length; j++)
            {
                sb.Append(ushortArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < shortArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < shortArrayArray[i].Length; j++)
            {
                sb.Append(shortArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < byteArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < byteArrayArray[i].Length; j++)
            {
                sb.Append(byteArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }
        
        sb.AppendLine();
        for (int i = 0; i < sbyteArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < sbyteArrayArray[i].Length; j++)
            {
                sb.Append(sbyteArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }

        sb.AppendLine();
        for (int i = 0; i < boolArrayArray.Length; i++)
        {
            sb.Append("[");
            for (int j = 0; j < boolArrayArray[i].Length; j++)
            {
                sb.Append(boolArrayArray[i][j]);
                sb.Append(",");
            }
            sb.Append("],");
        }
        
        sb.AppendLine();
        
        Debug.LogError(sb.ToString());
    }
}
