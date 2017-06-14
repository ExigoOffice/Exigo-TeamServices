using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

using Exigo.TeamServices.Data.Repository.Base;

using NPoco.fastJSON;

namespace Exigo.TeamServices.Data.Core.Extensions
{
    public static class StringExtensions
    {
        public static TReturn SerializeObject<TReturn>(this string json) where TReturn : IDto
        {
            return JSON.ToObject<TReturn>(json);
        }

        public static IEnumerable<TReturn> SerializeObjectCollection<TReturn>(this string json) where TReturn : IDto
        {
            return (IEnumerable<TReturn>) JSON.ToObject<TReturn>(json);
        }

        public static string Deserialize<TParam>(this TParam parameter) where TParam : IDto
        {
            return JSON.ToJSON(parameter);
        }

        public static string ToBase64Encoded(this string value) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);

        [DebuggerHidden]
        public static SecureString ConvertToSecureString(this string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            unsafe
            {
                fixed (char* passwordChars = password)
                {
                    var securePassword = new SecureString(passwordChars, password.Length);
                    securePassword.MakeReadOnly();
                    return securePassword;
                }
            }
        }

        [DebuggerHidden]
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null) throw new ArgumentNullException(nameof(securePassword));

            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally { Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString); }
        }
    }
}