using System;

namespace DDev.Tools
{
    public class DDevToolsException : Exception
    {
        public DDevToolsException(string msg) : base(msg) { }
        public DDevToolsException(string msg, Exception cause) : base(msg, cause) { }
    }
}