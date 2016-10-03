using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var ws = new CalculatorService.CalculatorWebServiceSoapClient();
            int result = ws.Add(Convert.ToInt32(textFirstNumber.Text), int.Parse(secondNumber.Text));
            labelResult.Text = result.ToString();
        }
    }
}