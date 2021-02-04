using Microsoft.AspNetCore.Http;
using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Extensions
{
    public static class TempDataExtension
    {
        public static void SetObjectTempData
            (this ISession session, String key, object value)
        {
            String data = HelperToolKit.SerializeJsonObject(value);
            session.SetString(key, data);
        }

        public static T GetObjectTempData<T>(this ISession session, String key)
        {
            String data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return HelperToolKit.DeserializeJsonObject<T>(data);
        }
    }
}
