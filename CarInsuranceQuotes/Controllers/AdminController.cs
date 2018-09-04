using CarInsuranceQuotes.Models;
using CarInsuranceQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuotes.Controllers
{
    public ActionResult Index()
    {
        using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
        {            
            var quotesVM = new List<CarInsuranceQuotesVM>();
            foreach (var signup in quotesVM)
            {
                var getQuoteVm = new CarInsuranceQuotesVM();
                getQuoteVm.Id = signup.Id;
                getQuoteVm.FirstName = signup.FirstName;
                getQuoteVm.LastName = signup.LastName;
                getQuoteVm.EmailAddress = signup.EmailAddress;
                getQuoteVm.Add(quotesVM);
            }

            return View();
        }
    }
}