using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Configuration;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using WebApplication1.ImageVerifier;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private string captchaString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceClient client2 = new ServiceClient();
            //generate captcha image
            captchaString = GetRandomString(6);
            Stream stream = client2.GetImage(captchaString);

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            byte[] imageBytes = ms.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            image_captcha.ImageUrl = "data:image/png;base64," + base64String;

            client2.Close();


        }

        // Testing Faris Abujolban
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

        // Testing Faris Abujolban
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

        // Testing Faris Abujolban
        protected void button_submit_email_click(object sender, EventArgs e)
        {
            EmailService.WebService1SoapClient client = new EmailService.WebService1SoapClient();

            string toEmail = textbox_email_address.Text;
            string message = textbox_email_content.Text;

            string result = client.SendEmail(toEmail, message);
            textbox_email_result.Text = result;

            client.Close();
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

        protected void button_refresh_captcha_Click(object sender, EventArgs e)
        {
            // WCF-based WSDL-SOAP service with two operations:
            // Stream GetImage() and GetVerifierString(string length)
            ServiceClient client2 = new ServiceClient();
            //generate captcha image
            captchaString = GetRandomString(6);
            Stream stream = client2.GetImage(captchaString);

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            byte[] imageBytes = ms.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            image_captcha.ImageUrl = "data:image/png;base64," + base64String;

            client2.Close();
        }

        protected async void button_solarbot_button_Click(object sender, EventArgs e)
        {
            const string BaseUrl = "https://localhost:44389/";

            var text_input = textbox_solarbot_input.Text;
            string endpoint = $"api/chatbot/ask?inputTxt={text_input}";

            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseUrl);

            try
            {
                // Send the HTTP GET request
                string response = await client.GetStringAsync(endpoint);

                // parse JSON to extract "message"
                var json = JObject.Parse(response);
                string message = json["message"]?.ToString();

                if (message != "")
                    textbox_solarbot_output.Text = message;
                else
                    textbox_solarbot_output.Text = "No message returned.";
            }
            catch (HttpRequestException ex)
            {
                // Handle errors
                textbox_solarbot_output.Text = $"Error connecting to API: {ex.Message}";
            }

        }
    }
}