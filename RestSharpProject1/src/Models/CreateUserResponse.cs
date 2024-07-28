using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AUTOMATION.src.Models
{

        public class CreateUserResponse
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public UserData Data { get; set; }

            public class UserData
            {
                public int? Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string OauthId { get; set; }
                public string OauthProvider { get; set; }
                public bool? Active { get; set; }
                public string Avatar { get; set; }
                public string Role { get; set; }
                public string VerificationReminder { get; set; }
                public string LastLogin { get; set; }
                public string Bundle { get; set; }
                public string NotificationEmailSetting { get; set; }
                public string CreatedAt { get; set; }
                public string UpdatedAt { get; set; }
                public Contract _Contract { get; set; }

                public class Contract
                {
                    public int Id { get; set; }
                    public string Ownership { get; set; }
                    public string Status { get; set; }
                    public List<string> Permissions { get; set; }
                }
            }
        }
    }

