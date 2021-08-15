﻿using System;

namespace FxTest.Exceptions
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message)
            : base(message)
        {
        }

        public InvalidInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
