using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AUTOMATION.src.Models
{
    internal class CreateUserRequest
    {
        public string Ownership { get; set; }
        public List<string> Permissions { get; set; }
        public string Email { get; set; }
    }
}
