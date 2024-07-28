using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject1.src.Models
{
    internal class LoginResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public LoginData Data { get; set; }
    }
}
