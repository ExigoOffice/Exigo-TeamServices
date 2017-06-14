using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using Exigo.TeamServices.Data.Core.Extensions;
using Exigo.TeamServices.Data.Dto;

namespace Exigo.TeamServices.Data.Authentication
{
    public class Encryption
    {
        public static byte[] CreateTokenAuthenticationHash(DateTime now, DateTime expire, AuthenticationData data)
        {
            var nowBytes = BitConverter.GetBytes(now.Ticks);
            var expireBytes = BitConverter.GetBytes(expire.Ticks);
            var dataBytes = ObjectToByteArray(data);
            return Encoding.UTF8.GetBytes(
                Cryptography.CreateHash(
                    $"{nowBytes.ToBase64String()}:{expireBytes.ToBase64String()}:{dataBytes.ToBase64String()}"));
        }

        public static byte[] ObjectToByteArray<T>(T dataObject)
        {
            if (dataObject == null) return null;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, dataObject);
                return stream.ToArray();
            }
        }
    }
}