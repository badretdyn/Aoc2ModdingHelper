namespace ConsoleApp
{
    public static class GlobalData
    {
        public static string? CurDir { get; set; } = Directory.GetCurrentDirectory();

        public static string? GeneratedDir { get; set; } = CurDir + @"\Generated";

        public static string Help { get; set; } = $"current directory: {GlobalData.CurDir}" + "\n" +
            "commands:\n" +
            "* help\n" +
            "* clear/cl\n" +
            "* getcitiesinfo/gci -askpath/--a\n" +
            "* createaoc2file/caf\n" +
            "* getcontinentsinfo/gcni\n" +
            "* getcontinentpackgeinfo/gcpi\n" +
            "* managepackge/mp\n" +
            "* getprovinceinfo/gpi %modifier% %prov_path\n" +
            "* tomapeditor/tme %modifier% %provs_path%\n" +
            "* !convertcities/cc -del/--d\n" +
            "* exit/close/quit/q/[Ctrl]+[C]\n" +
            "common modifiers:\n" +
            "* -help/--? -- prints information about command";

        public static bool CommandCycle { get; set; } = true;

        public static Config? Config { get; set; }
    }
}
