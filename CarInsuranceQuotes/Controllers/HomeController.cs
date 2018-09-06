using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuotes.Models;

namespace CarInsuranceQuotes.Controllers
{
    public class HomeController : Controller
    {
        public int CarInsuranceQuotesVM { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(string firstName, string lastName, string emailAddress, string dateOfBirth, string carYear, string carMake, string carModel, string dui, string tickets, string fullLiability)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrEmpty(carYear) || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(dui) || string.IsNullOrEmpty(tickets) || string.IsNullOrEmpty(fullLiability))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
                {
                    var getQuote = new Customer();
                    getQuote.FirstName = firstName;
                    getQuote.LastName = lastName;
                    getQuote.EmailAddress = emailAddress;
                    getQuote.DateOfBirth = dateOfBirth;
                    getQuote.CarYear = carYear;
                    getQuote.CarMake = carMake;
                    getQuote.CarModel = carModel;
                    getQuote.DUI = dui;
                    getQuote.Tickets = tickets;
                    getQuote.FullLiability = fullLiability;

                    db.Customers.Add(getQuote);
                    db.SaveChanges();
                }
            }

            return View("Success");
        }

        public ActionResult Quote()
        {
            return View();
        }
    }
}