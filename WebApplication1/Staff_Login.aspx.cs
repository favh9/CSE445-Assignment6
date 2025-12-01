using ClassLibrary1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Xml.Linq;
using WebApplication1.ImageVerifier;

namespace WebApplication1
{
    public partial class Staff_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initial startup of the page; set everything 
            if (!IsPostBack) 
            {
                
            } else
            {
                label_login_error.Visible = false;
            }

            
        }

        // By Naif Lohani
        private string GetDecryptedPasswordFromXml(string username)
        {
            // Example: load XML file, find user element and password element
            // adjust path / element names to match your data layout
            var doc = XDocument.Load(Server.MapPath("~/Staff.xml"));
            var user = doc.Root.Elements("Staff")
                         .FirstOrDefault(x => (string)x.Element("Username") == username);
            Class1 c1 = new Class1();

            return c1.Decrypt(user?.Element("Password")?.Value); // this is the decrypted password
        }

        // By Fausto Velazquez
        protected void button_signin_Click(Object sender, EventArgs e)
        {
            var username = Request.Form["input_username"];
            var password = Request.Form["input_password"].ToString();
            

            if (staff_exists(username) && password == GetDecryptedPasswordFromXml(username))
            {

                // successful login, add authentication cookie
                var auth_ticket = new System.Web.Security.FormsAuthenticationTicket(
                    1,
                    username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    "staff"
                );
                var enc_ticket = System.Web.Security.FormsAuthentication.Encrypt(auth_ticket);
                var auth_cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, enc_ticket);
                Response.Cookies.Add(auth_cookie);
                Response.Redirect("~/Staff.aspx");
            }
            else
            {
                label_login_error.Text = "Authorization failed.";
                label_login_error.Visible = true;
            }

        }

        // By Fausto Velazquez
        private bool staff_exists(string username)
        {
            string filepath = Server.MapPath("~/Staff.xml");

            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);

            foreach (XElement member in doc.Descendants("Staff"))
            {
                string staff_username = member.Element("Username").Value;
                if (staff_username == username)
                    return true;
            }

            // exhausted all possible members in file, return false
            return false;

        }


    }
}