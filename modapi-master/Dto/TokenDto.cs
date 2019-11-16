using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorOnDemand.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string message { get; set; }
        public UserInfoDto userInfo { get; set; }
    }
}
