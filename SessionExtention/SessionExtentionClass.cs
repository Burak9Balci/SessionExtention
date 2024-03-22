using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SessionExtention
{
    public static class SessionExtentionClass
    {
        public static T GetObject<T>(this ISession session,string key) where T : class
        {
            string jsonObject = session.GetString(key);
            if (jsonObject != null)
            {
                T deseObject = JsonConvert.DeserializeObject<T>(jsonObject);
                return deseObject;
            }
            return null;
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonObject = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonObject);
           
        }
    }
}
