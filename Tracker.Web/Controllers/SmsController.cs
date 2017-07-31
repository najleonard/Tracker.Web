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
	}
}
