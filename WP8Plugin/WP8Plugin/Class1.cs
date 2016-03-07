using System;
using Microsoft.Mdp.SDK;
using Windows.UI.Core;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;


/* Necesito añadir esto a: protected override void OnActivated(IActivatedEventArgs args)

#if UNITY_WP_8_1
                case ActivationKind.WebAuthenticationBrokerContinuation:

                    WP8Plugin.Plugin.AllWasOk(args);
                    break;
#endif
*/

namespace WP8Plugin
{
    public delegate void callback(string token);
    public class Plugin
    {
        public static string GetDeviceName
        {
            get
            {
                return "WP8.1";
            }
        }

        public static void Init(string env, string clientid, string policySignIn, string policySignUp)
        {
            DigitalPlatformClient.Instance.Init(env, clientid, Guid.NewGuid().ToString(), policySignUp, policySignIn);
        }

        public static callback LoginCallback;
        public static async void Login(callback _callback) {
            LoginCallback = _callback;
            /*
            var dispatcher =  CoreWindow.GetForCurrentThread().currentThread.Dispatcher;
            */
await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.SignIn();
                if( await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.IsLoggedUser() )
                    if (WP8Plugin.Plugin.LoginCallback != null) WP8Plugin.Plugin.LoginCallback("ok");
            });
        }

        public static async void GetToken(callback _callback ) {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => {
                string token = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.GetAccessToken();
                if (_callback != null) _callback(token);
            });
        }

        public static async void Logout()
        {
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.SignIn();
        }

        public static void AllWasOk(IActivatedEventArgs args)
        {
            var res = (args as WebAuthenticationBrokerContinuationEventArgs);
            if (res != null)
            {
                if (res.WebAuthenticationResult.ResponseStatus == Windows.Security.Authentication.Web.WebAuthenticationStatus.Success) {
                    Microsoft.IdentityModel.Clients.ActiveDirectory.
                        WebAuthenticationBrokerContinuationHelper.
                        SetWebAuthenticationBrokerContinuationEventArgs(args as IWebAuthenticationBrokerContinuationEventArgs);
                }
                else {
                    if (WP8Plugin.Plugin.LoginCallback != null) WP8Plugin.Plugin.LoginCallback("error");
                    System.Diagnostics.Debug.WriteLine("error");
                }

            }
        }


    }
}
