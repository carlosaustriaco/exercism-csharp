using System;

enum TypeByByte
{
    tbbLong,
    tbbUInt,
    tbbInt,
    tbbUShort,
    tbbShort
}

public static class TelemetryBuffer
{
    private static TypeByByte GetCorrectType(long value)
    {
        if ((value > uint.MaxValue) && (value <= long.MaxValue))
        {
            return TypeByByte.tbbLong;
        }
        else if ((value > int.MaxValue) && (value <= uint.MaxValue))
        {
            return TypeByByte.tbbUInt;
        }
        else if ((value > ushort.MaxValue) && (value <= int.MaxValue))
        {
            return TypeByByte.tbbInt;
        }
        else if ((value >= 0) && (value <= ushort.MaxValue))
        {
            return TypeByByte.tbbUShort;
        }
        else if ((value >= short.MinValue) && (value <= -1))
        {
            return TypeByByte.tbbShort;
        }
        else if ((value >= int.MinValue) && (value < short.MinValue))
        {
            return TypeByByte.tbbInt;
        }
        else
        {
            return TypeByByte.tbbLong;
        }
    }

    private static bool IsPrefixValid(byte prefix)
    {
        return ((prefix > 0) && (prefix <= 4)) || ((prefix >= 248) && (prefix < 256));       
    }

    private static TypeByByte GetTypeByPrefix(byte prefix)
    {
        switch(prefix)
        {
            case 2: return TypeByByte.tbbUShort;
            case 4: return TypeByByte.tbbUInt;
            case 248: return TypeByByte.tbbLong;
            case 252: return TypeByByte.tbbInt;
            case 254: return TypeByByte.tbbShort;
        }

        return TypeByByte.tbbLong; 
    }

    private static byte[] AdjustBufferArray(byte size, byte[] content)
    {
        byte[] output = new byte[9];
        output[0] = size;

        for(int i = 0; i < content.Length; i++)
        {
            output[i + 1] = content[i];
        }

        return output;
    }
    
    public static byte[] ToBuffer(long reading)
    {
        TypeByByte typeOfValue = TelemetryBuffer.GetCorrectType(reading);
        byte[] output = new byte[9];
        byte[] content;
        
        switch(typeOfValue)
        {
            case TypeByByte.tbbLong:
                content = BitConverter.GetBytes(reading);
                output = TelemetryBuffer.AdjustBufferArray(256 - 8, content);
                break;

            case TypeByByte.tbbUInt:
                content = BitConverter.GetBytes((uint)reading);
                output = TelemetryBuffer.AdjustBufferArray(4, content);
                break;

            case TypeByByte.tbbInt:
                content = BitConverter.GetBytes((int)reading);
                output = TelemetryBuffer.AdjustBufferArray(256 - 4, content);
                break;

            case TypeByByte.tbbUShort:
                content = BitConverter.GetBytes((ushort)reading);
                output = TelemetryBuffer.AdjustBufferArray(2, content);
                break;

            case TypeByByte.tbbShort:
                content = BitConverter.GetBytes((short)reading);
                output = TelemetryBuffer.AdjustBufferArray(256 - 2, content);
                break;                   
        }

        return output;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];

        if (TelemetryBuffer.IsPrefixValid(prefix))
        {
            TypeByByte typeOfValue = GetTypeByPrefix(prefix);
            byte[] output;

            switch(typeOfValue)
            {
                case TypeByByte.tbbLong: return BitConverter.ToInt64(buffer, 1);
                case TypeByByte.tbbInt: return BitConverter.ToInt32(buffer, 1);
                case TypeByByte.tbbShort: return BitConverter.ToInt16(buffer, 1);
                case TypeByByte.tbbUShort: return BitConverter.ToUInt16(buffer, 1);
                case TypeByByte.tbbUInt: return BitConverter.ToUInt32(buffer, 1);
            }

            return 0;
        }
        else
        {
            return 0;
        }
    }
}
