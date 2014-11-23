using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wit.LoanApp.Controllers;

namespace wit.LoanApp.Tests
{
  [TestClass]
  public class LoanControllerTest
  {
    //Change2
    [TestMethod]
    public void getAnnoLoan_Simple()
    {
      int G = 2391000;
      double expected = 28381.59;
      double r = (0.025 / 4);
      int n = 120;
      LoanController ctrl = new LoanController();
      var result = ctrl.getAnnoLoan(G, r, n);
      Assert.AreEqual(expected, Math.Round(result,2));

    }
  }
}
