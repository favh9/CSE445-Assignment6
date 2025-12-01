using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Staff : System.Web.UI.Page
    {

        // By Faris Abujolban
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        // By Faris Abujolban
        private void LoadUsers()
        {
            // list of usernames from XML
            List<string> users = GetAllUsernames();

            repUsers.DataSource = users.Select(u => new { Username = u });
            repUsers.DataBind();
        }

        // By Faris Abujolban
        protected void DeleteUser_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();

            DeleteUser(username);   // your delete logic

            LoadUsers(); // refresh display
        }

        // By Faris Abujolban
        private bool userExists(string username)
        {
            string filepath = Server.MapPath("~/Staff.xml");

            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);

            foreach (XElement staff in doc.Descendants("Staff"))
            {
                string staff_username = staff.Element("Username").Value;
                if (staff_username == username)
                    return true;
            }

            // exhausted all possible staff in file, return false
            return false;

        }

        // By Faris Abujolban
        private List<string> GetAllUsernames()
        {
            string filepath = Server.MapPath("~/Staff.xml");

            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);

            List<string> usernames = new List<string>();

            foreach (XElement staff in doc.Descendants("Staff"))
            {
                string staff_username = staff.Element("Username").Value;
                if (staff_username == "TA") { continue; } // skip TA account
                usernames.Add(staff_username);
            }

            return usernames;

        }

        // By Faris Abujolban
        private bool add_user(string usersname, string password)
        {

            // access DLL library 
            Class1 c = new Class1();


            if (userExists(usersname))
            {
                return false;   // user already exists
            }

            string filepath = Server.MapPath("~/Staff.xml");

            // store username in xml
            // ...
            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);
            doc.Root.Add(
                new XElement("Staff",
                new XElement("Username", usersname),
                new XElement("Password", c.Encrypt(password))
)
            );

            doc.Save(filepath);

            return true;
        }

        // By Faris Abujolban
        private bool DeleteUser(string usersname)
        {
            string filepath = Server.MapPath("~/Staff.xml");
            // search for username in xml file
            XDocument doc = XDocument.Load(filepath);
            var userElement = doc.Descendants("Staff")
                                 .FirstOrDefault(m => m.Element("Username").Value == usersname);
            if (userElement != null)
            {
                userElement.Remove();
                doc.Save(filepath);
                return true;
            }
            return false;
        }

        // By Faris Abujolban
        protected void addUser_Click(object sender, EventArgs e)
        {
            add_user(tbUsernameInput.Text, tbPasswordInput.Text);

            LoadUsers(); // refresh display
        }
    }
}