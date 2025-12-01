using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["chat_history"] == null)
            {
                Session["chat_history"] = new List<string>();
            }

            render_chat();

        }

        // By Fausto Velazquez
        protected void button_send_message_Click(object sender, EventArgs e)
        {
            // what should happen when the user sends a message?
            // - step 1: their message should be appended to the chatbox (done)
            // - step 2: the chatbot should respond to their message (in progress)
            // - step 3: the response should be displayed in the chatbox (not yet)
            // - step 4: save the chat history and clear their message
            string user_message = textbox_message.Text;
            if (string.IsNullOrWhiteSpace(user_message))
                return;

            // step 1
            add_message(user_message, "user");

            // step 2-4
            solar_bot_response(user_message);
        }

        // By Fausto Velazquez
        private void render_chat()
        {
            panel_chatbox.Controls.Clear();
            var chat_history = (List<string>)Session["chat_history"];

            foreach (string message in chat_history) 
            {
                Literal literal_message = new Literal();
                literal_message.Text = message + "<br/>";
                panel_chatbox.Controls.Add(literal_message);
            }

        }

        // By Fausto Velazquez
        private void add_message(string message, string sender)
        {
            var chat_history = (List<string>)Session["chat_history"];
            var chat_element = $"<div class='{sender}-message'><b>{sender}:</b> {message}</div>";
            chat_history.Add(chat_element);


            Session["chat_history"] = chat_history;
            render_chat();
            textbox_message.Text = "";
        }

        // By Fausto Velazquez
        private async void solar_bot_response(string input)
        {
            string output = "";

            const string base_url = "https://localhost:44389/";

            string endpoint = $"api/chatbot/ask?inputTxt={input}";

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
                    output = message;
                else
                    output = "No message returned.";

                add_message(output, "solarbot");
            }
            catch (JsonReaderException)
            {
                add_message(output, "system");
            }
            catch (HttpRequestException ex)
            {
                // Handle errors
                output = $"Error connecting to API: {ex.Message}";
                add_message(output, "system");
            }
            catch (Exception)
            {
                add_message(output, "system");

            }
        }
    }
}