using BCH.Domain.Exceptions;
using BCH.Domain.Primitives;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ValueOf;

namespace BCH.Domain.ValueObjects
{
    public class Info: ValueObject
    {
        private static readonly IList<String> _jsonKeys = new ReadOnlyCollection<string>(new List<String> 
        {
            "Name",
            "Height",
            "Hash",
            "CallTime",
            "LatestUrl",
            "PreviousHash",
            "PreviousUrl",
            "PeerCount",
            "UnconfirmedCount",
            "HighFeePerKb",
            "MediumFeePerKb",
            "LowFeePerKb",
            "LastForkHeight",
            "LastForkHash"
        });

        public string Value { get; private set; }

        private Info(string value)
        {
            Value = value;
        }

        public static Info Create(string jsonValue)
        {
            JObject result;
            try
            {
                result = JObject.Parse(jsonValue);
            }
            catch (Exception ex)
            {
                throw new InfoIsNotInJsonFormatException(jsonValue, ex);
            }

            foreach (var key in _jsonKeys)
            {
                if (!result.ContainsKey(key))
                {
                    throw new InvalidJsonContentException(key);
                }
            }

            return new Info(jsonValue);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
