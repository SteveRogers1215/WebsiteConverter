using MimeKit; //Added for access to MimeMessage class
using MailKit.Net.Smtp; //Added for access to SmtpClient class
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteConverter.Models;

namespace WebsiteConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        
        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            _logger = logger;
            _config = config;
        }

        
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            ViewBag.Project = ProjectViewModel.GetProjects();
            return View();
        }

        public IActionResult PortfolioDetails(int? id)
        {
            return View(ProjectViewModel.GetProjects().FirstOrDefault(x => x.ID == id));
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]//default, optional
        public IActionResult Contact()
        {
            return View();
            #region Code Generation Steps

            //1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
            //2. Go to the Browse tab and search for Microsoft.VisualStudio.Web
            //3. Click Microsoft.VisualStudio.Web.CodeGeneration.Design
            //4. On the right, check the box next to the CORE1 project, then click "Install"
            //5. Once installed, return here and right click the Contact action
            //6. Select Add View, then select the Razor View template and click "Add"
            //7. Enter the following settings:
            //      - View Name: Contact
            //      - Template: Create
            //      - Model Class: ContactViewModel
            //8. Leave all other settings as-is and click "Add"

            #endregion
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            //Check if the model is valid before continuing
            if (!ModelState.IsValid)
            {
                //Send them back to the form. Pass the object through the View
                //so the form will contain original info provided.
                return View(cvm);
            }


            //To handle sending email...we need a new NuGet Package and add using statements.
            #region Email Setup Steps & Email Info

            //1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
            //2. Go to the Browse tab and search for NETCore.MailKit
            //3. Click NETCore.MailKit
            //4. On the right, check the box next to the CORE1 project, then click "Install"
            //5. Once installed, return here
            //6. Add the following using statements & comments:
            //      - using MimeKit; //Added for access to MimeMessage class
            //      - using MailKit.Net.Smtp; //Added for access to SmtpClient class
            //7. Once added, return here to continue coding email functionality
            #endregion

            //MIME - Multipurpose Internet Mail Extension. Allows email to contain info
            //other than ASCII, including audio, video, images, and HTML.
            //S/MIME - > secure apps/ PKI encryption

            //SMTP - Simple mail transfer protocol - An internet protocol like HTTP, that specializes in the collections and processing of email data.

            //Create the format for the message content we will receieve from the contact form
            string message = $"You have received a new email from your site's contact form!<br />" +
                             $"Sender: {cvm.Name}<br/>" +
                             $"Email: {cvm.Email}<br/>" +
                             $"Subject: {cvm.Subject}<br/> +" +
                             $"Message: {cvm.Message}";

            //Create a MimeMessage object to assist with storing/transferring the email info from the contact form

            var mm = new MimeMessage();

            //Even though the user is the one attempting to send a message to us, the actual sender of the email
            //is the "email user" we set up in SmarterASP.

            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));
            //The recipient is our personal email address(outlook)
            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            //We can add the users provided email to the list of "Reply to" addresses so our replies can go directly to them instead of the "email user" on SmarterAsp

            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            //The subject will be the subject provided by user in the form. this is stored in CVM object

            mm.Subject = cvm.Subject;

            //If we dont have any HTML we can assign the body as mm.Body = message.
            mm.Body = new TextPart("HTML") { Text = message };

            //We can set priority of message so it will be flagged in our email client
            mm.Priority = MessagePriority.Urgent;

            //The using directive will create an SMTP client object used to send the email. Once all the code inside is done it will close open connections and dispose the object for us.
            using (var client = new SmtpClient())
            {

                try
                {
                    client.Connect(_config.GetValue<string>("Credentials:Email:Client"), 8889);
                    //Login to mail server using credentials for email user
                    client.Authenticate(
                        //username
                        _config.GetValue<string>("Credentials:Email:User"),
                        //password
                        _config.GetValue<string>("Credentials:Email:Password")
                        );
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    //If there is an issue, we can store an error message in a ViewBag vairable to be displayed in the View.
                    ViewBag.ErrorMessage = $"There was an issue processing your request. Please" +
                        $" try again later.<br/>Error Message: {ex.Message}";
                    return View(cvm);
                }

            }//end using
            //If all goes well return a view that displays a confirmation to user that email was sent successfully
            return View("EmailConfirmation", cvm);
        }


    }
}