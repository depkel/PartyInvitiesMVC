//you’re creating a DOMAIN MODEL by identifying the real-world entities, operations, and rules that exist in the industry 
//or subject matter you’re targeting (the domain), and by creating a representation of that domain in software
//(usually an object-oriented representation backed by some kind of persistent storage system, such as a
//relational database or a document database).

//1) Anti-pattern --design pattern --all mixed
//2) model-view :Architecture If the only separation in your application is between UI and domain model 
//3) three-tier architecture : cuts persistence code(DA) out of the domain
//model and places that in a separate, third component, called the data access layer (DAL).

//CTRL + k + c

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public string Index() //' no VIEW's are used bcos returns plain text string and so no HTML doc are returned 
        //{
        //    return "hello world";
        //}

        //second code 
        //ActionResult is a general result type that can have 11 subtypes like Viewresult,EmptyResult,RedirectResult,JsonResult,JavaScriptResult etc
        //Calls INDEX.ASPX VIEW by default, if not will give error--********using VIEW means RETURNING HTML DOC *******-------
        public ViewResult Index() //calls index.aspx --delivered collection of things found in VIEWDATA Structure
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Yes Good Morning" : "Yes Good AfterNoon";
            ViewBag.Person = "My Dear friend";
            return View();
        }

        // To produce an HTML response to a browser request, I need a view.
        // By returning an object of type VIEWRESULT, you’re giving the MVC Framework an 
        //instruction to render a VIEW, you are generating that VIEWRESULT object by calling VIEW() with no parameters,
        //means you’re telling the framework to render the Action’s Default View.

        //it’s the CONTROLLER’s job to construct some data, and the VIEW’s(index.aspx view template) job is to render it
        //as HTML.The data is passed from Controller to View using a data structure called VIEWDATA.

        // In MVC Your 'MODEL' is a software representation of the real-world objects, processes,
        // and rules that make up the subject matter, or domain, of your application
        //. It’s the central keeper of data and domain logic (i.e., business processes
        //and rules). Everything else (Controllers and Views) is merely expose the model’s operations and data to the Web

        //VIEW files are normally associated with Action Methods by means of naming convention. Each action method auto has it own URL
        // so no need to create seprate page or class for each url.
        //Calls http://yourserver/Home/RsvpForm it means Action method called RsvpForm() on HomeController

        //notice that, unlike traditional aSp.net applications, MVC urls do not correspond to physical files.each action
        //method has its own url, and MVC uses the aSp.net routing system to translate these urls into actions.

        //        A method that responds to HTTP GET requests: A GET request is what a browser issues normally
        //each time someone clicks a link.This version of the action will be responsible for displaying
        //the initial blank form when someone first visits /Home/RsvpForm.
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        // A method that responds to HTTP POST requests: By default, forms rendered using
        //Html.BeginForm() are submitted by the browser as a POST request.This version of the action
        //will be responsible for receiving submitted data and deciding what to do with it.

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // TODO: Email response to the party organizer
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        //        In an MVC application, validation is typically applied in the domain model, rather than in the
        //      user interface.
        //  In MVC, controllers are C# classes, usually derived from the System.Web.Mvc.Controller class. Each public method
        //in a class derived from Controller is an action method, which is associated with a configurable URL through the
        //ASP.NET routing system.When a request is sent to the URL associated with an action method, the statements in the
        //controller class are executed in order to perform some operation on the domain model and then select a view to
        //display to the client

        //******************* What is DEPEDENCY INJECTION 
        //        public class PasswordResetHelper
        //        {
        //            private IEmailSender emailSender;
        //            public PasswordResetHelper(IEmailSender emailSenderParam)
        //            {
        //                emailSender = emailSenderParam;
        //            }
        //            public void ResetPassword()
        //            {
        //                // ...call interface methods to configure e-mail details...
        //                emailSender.SendEmail();
        //            }
        //        }
        //      

        //        The constructor for the PasswordResetHelper class is now said to declare a dependency on the IEmailSender
        //interface, meaning that it can’t be created and used unless it receives an object that implements the IEmailSender
        //interface. In declaring its dependency, the PasswordResetHelper class no longer has any knowledge of
        //MyEmailSender, it only depends on the IEmailSender interface. In short, the PassworsResetHelper no longer knows
        //or cares how the IEmailSender interface is implemented.
        //The dependencies are injected into the PasswordResetHelper at runtime; that is to say, an instance of some class
        //that implements the IEmailSender interface will be created and passed to the PasswordResetHelper constructor
        //during instantiation.There is no compile-time dependency between PasswordResetHelper and any class that
        //implements the interfaces it depends on.
        //Because the dependencies are dealt with at runtime, I can decide which interface implementations are going
        //to be used when I run the application.I can choose between different e-mail providers or inject a special mocked
        //implementation for testing
        //      IEmailSender sender = new MyEmailSender();
        //      helper = new PasswordResetHelper(sender);
        //    


    }
    }