using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void button_send_message_Click(object sender, EventArgs e)
        {
            // what should happen when the user sends a message?
            // - step 1: the message should be appended to the chatbox (in progress)
            // - step 2: the chatbox should respond to their message (not yet)
            // - step 3: the response should be displayed in the chatbox (not yet)
            // - step 4: save the chat history and clear their message
            string user_message = textbox_message.Text;
            if (string.IsNullOrWhiteSpace(user_message))
                return;

            // step 1
            var chat_history = (List<string>)Session["chat_history"];
            var chat_element = $"<div class='user-message'><b>You:</b> {user_message}</div>";
            chat_history.Add(chat_element);

            // step 2
            // ...

            // step 3
            // ...

            // step 4
            Session["chat_history"] = chat_history;
            render_chat();
            textbox_message.Text = "";
        }

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
    }
}