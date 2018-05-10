using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Demo1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult QueueMessage()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> QueueMessage(string q)
		{
			CloudStorageAccount account = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsDashboard"].ConnectionString);
			var client = account.CreateCloudQueueClient();
			var queue = client.GetQueueReference("queue");
			await queue.AddMessageAsync(new CloudQueueMessage(q));
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}