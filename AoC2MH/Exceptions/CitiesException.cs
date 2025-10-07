namespace AoC2mh.Exceptions
{
    public class ArgumentCitiesException : ArgumentException
    {
        public ArgumentCitiesException() { }

        public ArgumentCitiesException(string paramName) : base($"Ivalid argument {paramName}.", paramName) { }

        public ArgumentCitiesException(string message, string paramName) : base(message, paramName) { }
    }
}
