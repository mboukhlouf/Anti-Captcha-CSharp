using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AntiCaptcha.Helpers
{
    public static class JsonHelper
    {
        public static T ParseFromJson<T>(String Json)
        {
            T o;
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                o = (T)serializer.ReadObject(stream);
            }
            return o;
        }

        public static String ToJson<T>(T o)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
            {
                EmitTypeInformation = EmitTypeInformation.Never
            };

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), settings);
            serializer.WriteObject(stream, o);
            stream.Position = 0;

            String json;
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
    }
}
