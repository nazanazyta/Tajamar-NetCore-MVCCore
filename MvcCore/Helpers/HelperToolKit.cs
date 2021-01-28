using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Helpers
{
    public class HelperToolKit
    {
        public static bool CompararArrayBytes(byte[] a, byte[] b)
        {
            bool iguales = true;
            if (a.Length != b.Length)
            {
                return false;
                //iguales = false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(b[i]) == false)
                {
                    iguales = false;
                    break;
                }
            }
            return iguales;
        }
    }
}
