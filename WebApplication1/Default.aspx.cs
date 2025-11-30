using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Configuration;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using WebApplication1.ImageVerifier;
using ClassLibrary1;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // initial startup; everything that will be done
            // when someone opens this page
            if (!IsPostBack)
                refresh_captcha();
        }

        // By Faris Abujolban
        protected void button_encrypt_click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary1.Class1 obj = new ClassLibrary1.Class1();
                string input = textbox_encrypt_input.Text;
                string encrypted = obj.Encrypt(input);
                textbox_encrypt_result.Text = encrypted;
            }
            catch (Exception ex)
            {
                textbox_encrypt_result.Text = "Error: " + ex.Message;
            }
        }

        // By Faris Abujolban
        protected void button_decrypt_click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary1.Class1 obj = new ClassLibrary1.Class1();
                string input = textbox_encrypt_result.Text;
                string decrypted = obj.Decrypt(input);
                textbox_decrypt_result.Text = decrypted;
            }
            catch (Exception ex)
            {
                textbox_decrypt_result.Text = "Error: " + ex.Message;
            }
        }

        // By Faris Abujolban
        protected void button_submit_email_click(object sender, EventArgs e)
        {
            EmailService.WebService1SoapClient client = new EmailService.WebService1SoapClient();

            string to_email = textbox_email_address.Text;
            string message = textbox_email_content.Text;

            string result = client.SendEmail(to_email, message);
            textbox_email_result.Text = result;

            client.Close();
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
        protected async void button_solarbot_button_Click(object sender, EventArgs e)
        {
            const string base_url = "https://localhost:44389/";

            var text_input = textbox_solarbot_input.Text;
            string endpoint = $"api/chatbot/ask?inputTxt={text_input}";

            var client = new HttpClient();

            client.BaseAddress = new Uri(base_url);

            string response = "";
            try
            {
                // Send the HTTP GET request
                response = await client.GetStringAsync(endpoint);

                // parse JSON to extract "message"
                var json = JObject.Parse(response);
                string message = json["message"]?.ToString();

                if (message != "")
                    textbox_solarbot_output.Text = message;
                else
                    textbox_solarbot_output.Text = "No message returned.";
            }
            catch (JsonReaderException)
            {
                textbox_solarbot_output.Text = response;
            }
            catch (HttpRequestException ex)
            {
                // Handle errors
                textbox_solarbot_output.Text = $"Error connecting to API: {ex.Message}";
            }
            catch (Exception)
            {
                textbox_solarbot_output.Text = response;
            }

        }

        // By Fausto Velazquez
        protected void button_store_cookie_Click(object sender, EventArgs e)
        {
            string cookie_name = "test_cookie";
            string cookie_value = textbox_store_cookie.Text;
            // Create a new cookie
            HttpCookie cookie = new HttpCookie(cookie_name, cookie_value);
            // Set the cookie to expire in 1 day
            cookie.Expires = DateTime.Now.AddDays(1);
            // Add the cookie to the response
            Response.Cookies.Add(cookie);
        }

        // By Fausto Velazquez
        protected void button_retrieve_cookie_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["test_cookie"];

            if (cookie == null)
                textbox_output_retrieve_cookie.Text = "No cookie found.";
            else if (cookie.Value == "")
                textbox_output_retrieve_cookie.Text = "Cookie value is empty.";
            else
                textbox_output_retrieve_cookie.Text = cookie.Value;

        }

        // By Fausto Velazquez
        protected void button_store_session_Click(object sender, EventArgs e)
        {
            var session_name = "test_session";
            var session_value = textbox_store_session.Text;
            Session[session_name] = session_value;
        }

        // By Fausto Velazquez
        protected void button_retrieve_session_Click(object sender, EventArgs e)
        {
            var session_name = "test_session";
            var session_value = Session[session_name].ToString();

            if (session_value == null)
                textbox_output_retrieve_session.Text = "No session found.";
            else if (session_value == "")
                textbox_output_retrieve_session.Text = "Session vale is empty";
            else
                textbox_output_retrieve_session.Text = session_value;
        }

        // By Naif Lohani
        protected async void button_solar_Click(object sender, EventArgs e)
        {
            string string_zipcode = textbox_zipcode.Text;
            string string_roof_area = textbox_roof_area.Text;

            string err_msg = "Insufficient data or incorrect data.";

            if (string_zipcode == "" || string_roof_area == "")
            {
                textbox_solar_error_output.Text = err_msg;
                return;
            }

            if (string_zipcode.Length < 5)
            {
                textbox_solar_error_output.Text = err_msg;
                return;
            }

            try
            {
                // Area and zipcode are numerical values
                double area = Convert.ToDouble(string_roof_area);
                double zipcode = Convert.ToInt64(string_zipcode);

                // call Solar Web API
                // use string_zipcode and area
                const string base_url = "https://localhost:44308/";

                string endpoint = $"api/solar/calculate?zip={string_zipcode}&roofArea={area}";

                var client = new HttpClient();

                client.BaseAddress = new Uri(base_url);

                string response = "";

                // Send the HTTP GET request
                response = await client.GetStringAsync(endpoint);

                textbox_solar_output.Text = response;
            }
            catch (FormatException)
            {

                textbox_solar_error_output.Text = err_msg;
                return;
            }
            catch (Exception ex)
            {
                textbox_solar_error_output.Text = ex.Message;
                return;
            }
        }

        // By Fausto Velazquez
        protected void button_cookie_session_reset_Click(Object sender, EventArgs e)
        {

            textbox_store_cookie.Text = "";
            textbox_output_retrieve_cookie.Text = "";
            textbox_store_session.Text = "";
            textbox_output_retrieve_session.Text = "";
        }

        // By Fausto Velazquez
        protected void button_solarbot_reset_Click(Object sender, EventArgs e)
        {
            textbox_solarbot_input.Text = "";
            textbox_solarbot_output.Text = "";
        }

        // By Fausto Velazquez
        protected void button_reset_encrypt_decrypt_Click(Object sender, EventArgs e)
        {
            textbox_encrypt_input.Text = "";
            textbox_encrypt_result.Text = "";
            textbox_decrypt_result.Text = "";
        }

        // By Fausto Velazquez
        protected void button_email_reset_Click(Object sender, EventArgs e)
        {

            textbox_email_content.Text = "";
            textbox_email_address.Text = "";
            textbox_email_result.Text = "";
        }

        // By Fausto Velazquez
        protected void button_solar_reset_Click(Object sender, EventArgs e)
        {

            textbox_zipcode.Text = "";
            textbox_roof_area.Text = "";
            textbox_solar_output.Text = "";
            textbox_solar_error_output.Text = "";
        }

        // By Fausto Velazquez
        protected void auth_login_Click(Object sender, EventArgs e)
        {
            var username = Request.Form["input_username"];
            var password = Request.Form["input_password"];
            string error = "Authentication failed, please try again";

            if (!is_captcha_valid())
            {
                label_login_error.Text = error;
                return;
            }
                
            if (username == null || password == null)
            {
                label_login_error.Text = error;
                return;
            }

            if (member_exists(username))
            {
                Response.Redirect("~/Member.aspx");
                return;
            }
            else
            {
                label_login_error.Text = "An error has occurred";
            }
                

        }

        // By Fausto Velazquez
        private bool is_captcha_valid()
        {
            // get the captcha secret message
            // get the user's input
            string captcha = Session["captcha"].ToString();
            string user_attempt = textBox_captcha_input.Text;

            // validate the captcha attempt
            if (user_attempt == null || user_attempt == "")
                return false;

            if (user_attempt == captcha)
                return true;
            else
                return false;
        }

        // By Fausto Velazquez
        private bool member_exists(string username)
        {
            string filepath = Server.MapPath("~/Member.xml");

            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);

            foreach(XElement member in doc.Descendants("Member"))
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

            // access DLL library 
            Class1 c = new Class1();

            // password encryption
            string password = "";
            c.Encrypt(password);

            // store username in xml
            // ...

            // store encrypted password in xml
            // ...
            return false;
        }
    }
}