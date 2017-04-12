using System;

namespace Calculator.Models
{
    public class Response
    {
        public bool HasError { get; set; }
        public string Data { get; set; }

        public Response(object data, bool hasError = false)
        {
            this.HasError = hasError;
            this.Data = Convert.ToString(data);
        }
    }
}
