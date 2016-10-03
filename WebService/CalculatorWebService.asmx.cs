using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for CalculatorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorWebService : System.Web.Services.WebService
    {
        //[WebMethod]
        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}

        [WebMethod(EnableSession = true)]
        public int Add(int a, int b)
        {
            List<string> calculations;
            if (Session["CALCULATIONS"] == null)
            {
                calculations = new List<string>();
            }
            else
            {
                calculations = (List<String>)Session["CALCULATIONS"];
            }
            string formattedResult = string.Format($"{a} + {b} = {a + b}");
            calculations.Add(formattedResult);
            Session["CALCULATIONS"] = calculations;
            return a + b;
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetCalculations()
        {
            // TODO: Refact!
            //var calculations = Session["CALCULATIONS"] as List<String>;
            if (Session["CALCULATIONS"] == null)
            {
                //List<string> calculatoins = new List<string>();
                var calculations = new List<string>();
                calculations.Add("You have not performed any calculations!");
                return calculations;
            }
            else
            {
                return (List<string>)Session["CALCULATIONS"];
            }
        }
    }
}
