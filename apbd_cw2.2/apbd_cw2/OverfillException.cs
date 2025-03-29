using System;

namespace apbd_cw2
{
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message)
        {
        }
    }
}