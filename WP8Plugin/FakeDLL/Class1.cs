using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WP8Plugin
{
    public delegate void callback(string token);
    public class Plugin
    {
        public static string GetDeviceName
        {
            get
            {
                return "FAKE";
            }
        }

        public static void Init(string env, string clientid, string policySignIn, string policySignUp) { }
        public static void Login(callback _callback) { }
        public static void Logout()
        {
        }
        public static void GetToken(callback _callback)
        {
            if (_callback != null)
                _callback("Ok");
        }

    }
}
