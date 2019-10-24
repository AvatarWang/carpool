using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginModel
    {
        public User user { get; set; }
        public UserInfo userInfo { get; set; }
        public DriverInfo driveInfo { get; set; }
    }
}
