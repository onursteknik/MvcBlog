using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcBlog
{
    public class Helpers
    {
        public static string MD5Hex(string Expression)
        {
            MD5 m = MD5.Create();
            string result = string.Empty;
            byte[] _hash = m.ComputeHash(Encoding.Default.GetBytes(Expression));
            foreach (byte _byte in _hash)
                result += _byte.ToString("X2");
            return result;
        }
    }
}