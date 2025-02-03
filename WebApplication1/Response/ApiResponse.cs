using System.Net;

namespace WebApplication1.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool success { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiResponse()
        {
            success = true;
            StatusCode = HttpStatusCode.OK;
            ErrorMessage = "";
        }

        public void SetError(string ErrorMessage, HttpStatusCode statusCode)
        {
            success = false;
            this.ErrorMessage = ErrorMessage;
            this.StatusCode = statusCode;
        }

    }
}
