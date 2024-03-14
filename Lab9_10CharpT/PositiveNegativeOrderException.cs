using System;

public class PositiveNegativeOrderException : Exception
{
    public PositiveNegativeOrderException(string message) : base(message)
    {
    }
}