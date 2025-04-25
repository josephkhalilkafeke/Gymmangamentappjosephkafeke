using System;
namespace finalprojectjosephkafekecprg211.Data
{
    public class DuplicateClassException : Exception
    {
        public DuplicateClassException(string message) : base(message) { }
    }
}