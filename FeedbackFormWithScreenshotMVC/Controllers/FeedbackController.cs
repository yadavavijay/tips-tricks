using FeedbackFormWithScreenshotMVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

namespace FeedbackFormWithScreenshotMVC.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(string feedback)
        {
            JObject json = JObject.Parse(feedback);
            Feedback form = JsonConvert.DeserializeObject<Feedback>(json.ToString());

            // Convert base64 to image online : http://codebeautify.org/base64-to-image-converter
            // Even paste into Chrome addressbar to view image

            return View();
        }
    }
}