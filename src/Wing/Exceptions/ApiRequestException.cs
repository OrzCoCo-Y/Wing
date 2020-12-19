﻿using System.Net;
using System.Net.Http;

namespace Wing.Exceptions
{
    public class ApiRequestException : HttpRequestException
    {
        public ApiRequestException(string uri, HttpStatusCode statusCode)
            : base($"request uri:{uri},statusCode:{statusCode.ToString()}")
        {
        }

        public ApiRequestException(string uri, HttpStatusCode statusCode, string requestData, string responseData)
            : base($"request uri:{uri},request data:{requestData},response data:{responseData},statusCode:{statusCode.ToString()}")
        {
        }
    }
}
