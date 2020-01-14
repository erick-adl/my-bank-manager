using System.Collections.Generic;
using System.Linq;

namespace MyBankManager.Api.Responses
{
    public class Response
    {
        public Response() => Errors = new List<string>();
        public Response(object message, params string[] errors)
        {
            Errors = errors.ToList();
            Message = message;
        }
        public List<string> Errors { get; set; }
        public object Message { get; set; }
    }
    public class OkResult : Response
    {
        public OkResult(object result) : base(result) { }
    }
    public class NotFoundResult : Response
    {
        public NotFoundResult() : base() => Errors = new List<string>();
        public NotFoundResult(params string[] errors) : base(null, errors){ }
    }
}