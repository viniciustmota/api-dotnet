using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class LoginResultDto
    {
        public bool authenticated { get; set; }
        public string message { get; set; }
        public string accessToken { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
    }
}