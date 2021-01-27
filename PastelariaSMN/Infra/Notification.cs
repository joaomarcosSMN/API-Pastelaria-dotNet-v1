using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastelariaSMN.Infra
{
	public class Notification
	{
		public string Key { get; set; }
		public string Message { get; set; }

		public Notification(string key, string message)
		{
			Key = key;
			Message = message;
		}
	}
}
