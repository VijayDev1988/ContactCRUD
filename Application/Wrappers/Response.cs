using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T> where T : class
    {
        public Response()
        {

        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }
        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
