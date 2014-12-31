﻿using NBitcoin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBase.JsonConverters
{
    public class NetworkJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Network).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var network = (string)reader.Value;
            if (network == "MainNet")
                return Network.Main;
            if (network == "TestNet")
                return Network.TestNet;
            if (network == "RegNet")
                return Network.RegTest;
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var net = (Network)value;
            String str = null;
            if (net == Network.Main)
                str = "MainNet";
            if (net == Network.TestNet)
                str = "TestNet";
            if (net == Network.RegTest)
                str = "RegNet";
            if (str != null)
                writer.WriteValue(str);
        }
    }
}