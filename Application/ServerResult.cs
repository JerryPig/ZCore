using System;
using System.Collections.Generic;
using System.Text;

namespace ZDomain.Application
{
   public class ServerResult<T>
    {
        public ServerResult()
        {
            ErrorCode = 0;
            ErrrorMsg = "ok";
            Error = false;
        }
        public bool Error { get; set; }

        public int Count { get; set; }

        public T Data { get; set; }

        public string ErrrorMsg { get; set; }

        public int ErrorCode { get; set; }
    }
}
