﻿using System.Net;

namespace Reservio.Core
{
    public class ErrorResponse
    {
        public ErrorResponse(string message = null)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}