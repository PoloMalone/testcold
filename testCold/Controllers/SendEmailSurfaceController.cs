using Microsoft.AspNetCore.Mvc;
using testCold.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Aspose.Email;
using Aspose.Email.Clients.Smtp;
using Aspose.Email.Mapi;

namespace testCold.Controllers
{
    public class SendEmailSurfaceController : SurfaceController
    {
        public SendEmailSurfaceController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(SendEmailmodel model)
        {
            if (ModelState.IsValid)
            {
                sendingEmail(model);
                return RedirectToCurrentUmbracoPage();
            }

            return CurrentUmbracoPage();
        }

        private void sendingEmail(SendEmailmodel model)
        {
            //input credentials for smtp server
            string SMTPserver = "";
            int port = 0000;
            string username = "";
            string password = "";
            string senderEmail = "";
            string subject = "";

            SmtpClient client = new SmtpClient(SMTPserver, port, username, password);
            MailMessage message = new MailMessage(senderEmail, model.Email, subject, model.Message);
            client.Send(message);

        }
    }
}







