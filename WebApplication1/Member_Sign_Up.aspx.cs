using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebApplication1.ImageVerifier;

namespace WebApplication1
{
    public partial class Member_Sign_Up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initial startup; everything that will be done
            // when someone opens this page
            if (!IsPostBack)
            {
                refresh_captcha();
            }
            
        }

        // generate a random string
        // By Fausto Velazquez
        private string GetRandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] buffer = new char[length];

            for (int i = 0; i < length; i++)
            {
                buffer[i] = chars[random.Next(chars.Length)];
            }

            return new string(buffer);
        }

        // By Fausto Velazquez
        private void refresh_captcha()
        {
            // WCF-based WSDL-SOAP service with two operations:
            // Stream GetImage() and GetVerifierString(string length)
            ServiceClient client = new ServiceClient();
            //generate captcha image
            var captcha_string = GetRandomString(6);
            Stream stream = client.GetImage(captcha_string);

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            byte[] image_bytes = ms.ToArray();
            string base_64_string = Convert.ToBase64String(image_bytes);
            image_captcha.ImageUrl = "data:image/png;base64," + base_64_string;


            client.Close();

            // set session state
            Session["captcha"] = captcha_string;
        }

        // By Fausto Velazquez
        protected void button_refresh_captcha_Click(object sender, EventArgs e)
        {
            refresh_captcha();
        }

        // By Fausto Velazquez
        private bool member_exists(string username)
        {
            string filepath = Server.MapPath("~/Member.xml");

            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);

            foreach (XElement member in doc.Descendants("Member"))
            {
                string member_username = member.Element("Username").Value;
                if (member_username == username)
                    return true;
            }

            // exhausted all possible members in file, return false
            return false;

        }

        // By Fausto Velazquez
        private bool add_user()
        {

            var username = Request.Form["input_username"];
            var password = Request.Form["input_password"];
            var confirm_password = Request.Form["input_confirm_password"];
            string captcha = Session["captcha"].ToString();

            // check if fields are empty
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirm_password))
            {
                return false;
            }

            // validate captcha
            string user_attempt_captcha = textbox_captcha_input.Text;
            if (captcha != user_attempt_captcha)
            {
                return false;
            }

            // check if passwords match
            if (password != confirm_password)
            {
                return false;
            }

            // check if username exists
            if (member_exists(username))
            {
                return false;
            }

            // access DLL library 
            Class1 c = new Class1();

            // password encryption
            c.Encrypt(password);

            

            // adding the new Member
            // define the path
            string file_path = Server.MapPath("~/Member.xml");

            // load the existing file
            XDocument doc = XDocument.Load(file_path);

            // create a Member element
            XElement new_member = new XElement("Member",
                new XElement("Username", username),
                new XElement("Password", password)
                );

            // put the user into the doc object
            doc.Root.Add(new_member);

            // save the object
            doc.Save(file_path);

            return true;
        }

        // By Fausto Velazquez
        protected void button_submit_Click(object sender, EventArgs e)
        {
            if (add_user())
            {
                // redirect to Default page
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}