using System.Net;

namespace Reservio.Core
{
    public class APIException : Exception
    {

        public int StatusCode { get; set; }
        public APIException() : base() { }

        public APIException(HttpStatusCode StatusCode, string message = null)
              : base(message ?? new APIException().GetDefaultMessageForStatusCode((int)StatusCode))
        {
            this.StatusCode = (int)StatusCode;
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to a career change",
                _ => "Unknown status code" // Add a default case that returns a non-null value
            };
        }
    }
}