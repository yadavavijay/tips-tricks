using System.Collections.Generic;

namespace FeedbackFormWithScreenshotMVC.Models
{
    public class Feedback
    {
        public Browser browser { get; set; }
        public string url { get; set; }
        public string html { get; set; }
        public string img { get; set; }
        public string note { get; set; }
    }

    public class Browser
    {
        public string appCodeName { get; set; }
        public string appName { get; set; }
        public string appVersion { get; set; }
        public bool cookieEnabled { get; set; }
        public bool onLine { get; set; }
        public string platform { get; set; }
        public string userAgent { get; set; }
        public List<string> plugins { get; set; }
    }
}