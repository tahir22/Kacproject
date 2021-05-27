using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace webappiProject.Controllers
{
    public class StringRemoveController : Controller
    {
        // GET: StringRemove
        public ActionResult stringRemoving()
        {
            string input = "57 gfdfg665dfgd KG ";
            string output = new string(input.Where(c => (Char.IsDigit(c) || c == '.' || c == ',')).ToArray());
            string value = Regex.Replace(input, "[A-Za-z ]", "");
            double parsedValue = double.Parse(value);

            var ttt = string.Join("",
               from ch in input
               where char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)
               select ch);
            return View();
        }
    }
}