using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
			var accountSid = "AC01316b284a8c2fe1a2024489794cada6";
			var authToken = "08a1f0d1a1f00414358c6e42dd16e807";
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
                return Content(message2.Sid);
            }

		}

        public ActionResult SendSMS()
        {
            var accountSid = "AC01316b284a8c2fe1a2024489794cada6";
            var authToken = "08a1f0d1a1f00414358c6e42dd16e807";
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
