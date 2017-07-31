using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace Tracker.Web.Controllers
{
	public class SmsController : TwilioController
	{
		[HttpPost]
		public ActionResult Index()
		{
			var messagingResponse = new MessagingResponse();
			messagingResponse.Message("The Robots are coming! Head for the hills!");

			return TwiML(messagingResponse);
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
