using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wit.LoanApp.Controllers
{
    public class LoanController : Controller
    {
        //
        // GET: /Loan/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SimpleLoan()
        {
          return View();
        }
        public double  getAnnoLoan(int G, double r, int n)
        {
           return (G * ( r / (1 - (Math.Pow((double)(1+r),(double)(-n))))));
        }


        public JsonResult GetTerms(int G, double r, int n)
        {
          var output = new List<PaymentTerm>();
          var payment = getAnnoLoan(G, r, n);
          double grossSoFar = G;
          double netSoFar = 0;
          double interest = 0;

          for (int term = 1; term <= n; term++)
          {
            interest = grossSoFar * r;
            netSoFar = grossSoFar + interest - payment;
            PaymentTerm pt = new PaymentTerm() { Term = term, Year = 2014, GrossValue = grossSoFar, NetValue = netSoFar, Interest = interest, Payment = payment };
            output.Add(pt);
            grossSoFar = netSoFar;
          }
          return Json(output,JsonRequestBehavior.AllowGet);
        }

    }
    public class PaymentTerm
    {
      public int Term { get; set; }
      public int Year { get; set; }
      public double GrossValue { get; set; }
      public double Interest { get; set; }
      public double Payment { get; set; }
      public double Tax { get; set; }
      public double NetValue { get; set; }
    }
}

