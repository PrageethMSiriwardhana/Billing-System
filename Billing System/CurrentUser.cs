using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static int? Role { get; set; }

        public static byte[] ProfileImage { get; set; }
    }


}
