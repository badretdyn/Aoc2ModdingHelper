namespace AoC2mh.Serialization.Java;

public static class JavaSerializationConstants
{
    public const byte TC_NULL = 0x70; // p
    public const byte TC_REFERENCE = 0x71; // q; then following 4 bytes int32
    public const byte TC_CLASSDESC = 0x72; // r; name, serialVersionUID
    public const byte TC_OBJECT = 0x73; // s; not string or array
    public const byte TC_STRING = 0x74; // t; utf8
    public const byte TC_ARRAY = 0x75; // u
    public const byte TC_CLASS = 0x76; // v; class link
    public const byte TC_BLOCKDATA = 0x77; // w; primitive data max 255 bytes
    public const byte TC_ENDBLOCKDATA = 0x78; // x; this following after describing class fields
}
