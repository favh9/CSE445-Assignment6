using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ImageVerifier;

namespace WebApplication1
{
    public partial class Member_Sign_Up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refresh_captcha();
        }

        // generate a random string
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

        protected void button_refresh_captcha_Click(object sender, EventArgs e)
        {
            refresh_captcha();
        }
    }
}