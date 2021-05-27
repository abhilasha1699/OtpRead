using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.Phone;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OtpAutofill.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(HashKeyAndroid))]
namespace OtpAutofill.Droid
{
    public class HashKeyAndroid : IHashKeyService
    {
        [Obsolete]
        public string GenerateHashKey()
        {
            //throw new NotImplementedException();
            return new AppHashKeyHelper().GetAppHashKey(global::Android.App.Application.Context);
        }

        public void StartSmsRetRec()
        {
            //throw new NotImplementedException();
            //SmsRetrieverClient smsRetrieverClient = SmsRetrieverClient.getClient(this);
            SmsRetrieverClient _client = SmsRetriever.GetClient(Android.App.Application.Context);
            var task = _client.StartSmsRetriever();
        }
    }
}