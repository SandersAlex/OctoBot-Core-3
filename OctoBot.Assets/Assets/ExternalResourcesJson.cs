using System;
using Newtonsoft.Json;

namespace OctoBot.Assets
{
	public class ExternalResourcesJson
	{
		[JsonProperty("current-user-feedback-form")]
		public string CurrentUserFeedbackForm { get; set; }
		[JsonProperty("public-announcements")]
		public string PublicAnnouncements { get; set; }
	}
}