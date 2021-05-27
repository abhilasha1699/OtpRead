using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.Phone;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace OtpAutofill.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { SmsRetriever.SmsRetrievedAction})]
    public class SmsBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
            if (intent.Action != SmsRetriever.SmsRetrievedAction)
            {
                return;
            }
            var extrasBundle = intent.Extras;
            if (extrasBundle == null)
            {
                return;
            }
            var status = (Statuses)extrasBundle.Get(SmsRetriever.ExtraStatus);
            switch (status.StatusCode)
            {
                case CommonStatusCodes.Success:
                    var messageContent = (string)extrasBundle.Get(SmsRetriever.ExtraSmsMessage);
                    MessagingCenter.Send<string>(messageContent, "ReceivedOTP");
                    break;

                case CommonStatusCodes.Timeout:
                    break;
            }
        }
    }
}