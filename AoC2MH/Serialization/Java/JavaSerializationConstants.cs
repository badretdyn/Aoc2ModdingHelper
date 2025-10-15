namespace Aoc2mh.Serialization.Java;

public static class JavaSerializationConstants
{
    public const byte TYPE_BYTE = (byte)'B';        // 0x42
    public const byte TYPE_CHAR = (byte)'C';        // 0x43
    public const byte TYPE_DOUBLE = (byte)'D';      // 0x44
    public const byte TYPE_FLOAT = (byte)'F';       // 0x46
    public const byte TYPE_INT = (byte)'I';         // 0x49
    public const byte TYPE_LONG = (byte)'J';        // 0x4A
    public const byte TYPE_CLASS = (byte)'L';       // 0x4C
    public const byte TYPE_SHORT = (byte)'S';       // 0x53
    public const byte TYPE_BOOLEAN = (byte)'Z';     // 0x5A
    public const byte TYPE_ARRAY = (byte)'[';       // 0x5B

    public const byte TC_NULL = (byte)'p';          // 0x70
    public const byte TC_REFERENCE = (byte)'q';     // 0x71
    public const byte TC_CLASSDESC = (byte)'r';     // 0x72
    public const byte TC_OBJECT = (byte)'s';        // 0x73
    public const byte TC_STRING = (byte)'t';        // 0x74
    public const byte TC_ARRAY = (byte)'u';         // 0x75
    public const byte TC_CLASS = (byte)'v';         // 0x76
    public const byte TC_BLOCKDATA = (byte)'w';     // 0x77
    public const byte TC_ENDBLOCKDATA = (byte)'x';  // 0x78
    public const byte TC_RESET = (byte)'y';         // 0x79
    public const byte TC_BLOCKDATALONG = (byte)'z'; // 0x7A
    public const byte TC_EXCEPTION = (byte)'{';     // 0x7B
    public const byte TC_LONGSTRING = (byte)'|';    // 0x7C
    public const byte TC_PROXYCLASSDESC = (byte)'}';// 0x7D
    public const byte TC_ENUM = (byte)'~';          // 0x7E
}

public enum JavaSerializationConstantsEnum : Byte
{
    Byte = (byte)'B',        // 0x42
    Char = (byte)'C',        // 0x43
    Double = (byte)'D',      // 0x44
    Float = (byte)'F',       // 0x46
    Int = (byte)'I',         // 0x49
    Long = (byte)'J',        // 0x4A
    Class = (byte)'L',       // 0x4C
    Short = (byte)'S',       // 0x53
    Boolean = (byte)'Z',     // 0x5A
    Array = (byte)'[',       // 0x5B

    Null = (byte)'p',        // 0x70
    Reference = (byte)'q',   // 0x71
    ClassDesc = (byte)'r',   // 0x72
    Object = (byte)'s',      // 0x73
    String = (byte)'t',      // 0x74
    ArrayObject = (byte)'u', // 0x75
    ClassObject = (byte)'v', // 0x76
    BlockData = (byte)'w',   // 0x77
    EndBlockData = (byte)'x',// 0x78
    Reset = (byte)'y',       // 0x79
    BlockDataLong = (byte)'z', // 0x7A
    Exception = (byte)'{',   // 0x7B
    LongString = (byte)'|',  // 0x7C
    ProxyClassDesc = (byte)'}', // 0x7D
    Enum = (byte)'~',        // 0x7E
}