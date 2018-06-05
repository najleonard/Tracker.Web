using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace Tracker.Web.Controllers
{
	public class SmsController : TwilioController
	{
		[HttpPost]
		public ActionResult ReceiveSms()
		{
			var messagingResponse = new MessagingResponse();
			string SMSFrom = Request["From"];
			string To = Request["To"];
			string Body = Request["Body"];
            string ForwardToNumber = Request["ForwardToNumber"];


            //forward to L&L staff numbers
            //neil/danielle/annie
			var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
			var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
			TwilioClient.Init(accountSid, authToken);

            if (ForwardToNumber != null)
            {
                var to = new PhoneNumber(ForwardToNumber);
				var from = new PhoneNumber("+14152002558");

				var message = MessageResource.Create(
					to: to,
					from: from,
					body: Body
				);
                return Content(message.Sid);
			}
            else
            {
                var from = new PhoneNumber("+14152002558");
                if (String.Equals(SMSFrom,"+14156963814") || String.Equals(SMSFrom, "+14157066938"))
                {
                    var to3 = new PhoneNumber(Body.Substring(0,12));
					var message3 = MessageResource.Create(
					   to: to3,
					   from: from,
                        body: Body.Substring(13,Body.Length-13)
				   );
                    return Content(message3.Sid);
                }
                else
                {
                    var to = new PhoneNumber("+14156963814");

                    var message = MessageResource.Create(
                        to: to,
                        from: from,
                        body: SMSFrom + ": " + Body
                    );

                    var to2 = new PhoneNumber("+14157066938");
                    var message2 = MessageResource.Create(
                        to: to2,
                        from: from,
                        body: SMSFrom + ": " + Body
                    );

                    var to3 = new PhoneNumber("+17073194734");
                    var message3 = MessageResource.Create(
                        to: to3,
                        from: from,
                        body: SMSFrom + ": " + Body
                    );
                    return Content(message.Sid);
                }
            }

		}

        public ActionResult SendSMS()
        {
			var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
			var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
			TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+14156963814");
            var from = new PhoneNumber("+14152002558");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "hello neil testing"
            );

            return Content(message.Sid);

        }
	}
}
