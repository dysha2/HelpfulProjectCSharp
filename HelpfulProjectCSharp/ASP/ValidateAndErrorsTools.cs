using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpfulProjectCSharp.ASP
{
    public class ValidateAndErrorsTools
    {
        public static string GetInfo(Exception ex)
        {
            if (ex.InnerException is not null)
                return ex.Message + "\r\n" + ex.InnerException.Message;
            else
                return ex.Message;
        }
    }
}
