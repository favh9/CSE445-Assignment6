<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <!-- Instructions -->
            <div> 
                <h2>What this page includes</h2>
                <ul>
                    <li>Deploymet URL</li>
                    <li>Buttons to access Member and Staff pages.</li>
                    <li>Login redirection, if you log in, you will be redirected.</li>
                    <li>Testing components from service directory.</li>
                    <li>Application and Components Summary Table.</li>
                </ul>
            </div>

            <!-- Buttons to navigate to Member and Staff home pages -->
            <div>
                <h3>Buttons to navigate to Member or Staff page</h3>
                <table cellpadding="2">
                    <tr>
                        <td>
                             <asp:Button ID="button_member_login" runat="server" Text="Member Login" PostBackUrl="~/Member.aspx"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="button_staff_login" runat="server" Text="Staff Login" PostBackUrl="~/Staff.aspx"/>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- Login + CAPTCHA  
                by Fausto Velazquez -->
            <div>
                <h3>Login + CAPTCHA by Fausto Velazquez</h3>
                <p>Please use the following textboxes to login. If the credentials and captcha are correct, you will be redirected to the 
                    <br />Member or Staff page based on your role.
                    <br />Note: Enter your username and password, then enter the correct captcha.
                </p>
                <div>
                    <!-- Login -->
                    <div>
                        <table cellpadding="4">
                            <tr>
                                <td> User Name:  </td>
                                <td>
                                    <input name="txtUserName" type="text" id="txtUserName" />
                                </td>
                            </tr>
                            <tr>
                                <td> Password: </td>
                                <td>
                                    <input name="txtPassword" type="password" id="txtPassword" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="submit" name="btnLogin" value="Login" id="btnLogin" />
                                </td>
                                <td>
                                    <!-- output error message -->
                                    <asp:TextBox ID="textbox_login_error" runat="server" style="border: none; color: red;" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <p>No account? Try Test Account: Bob 123</p>
                    </div>
                    <!-- CAPTCHA -->
                    <div>
                        <asp:Image ID="image_captcha" runat="server" width="200" AlternateText="captcha image"/>
                        <br /> <br />
                        <asp:Button ID="button_refresh_captcha" runat="server" Text="Refresh captcha" OnClick="button_refresh_captcha_Click" />
                        <br /> <br />
                        <asp:Label ID="label_captcha_input" runat="server" Text="Please enter the string here"></asp:Label>
                        <asp:TextBox ID="textBox_captcha_input" runat="server" Width="50"></asp:TextBox>
                    </div>
                </div>
            </div>
            <!-- Cookie and session 
                by Fausto Velazquez -->
            <div>
                <h3>Cookie and session by Fausto Velazquez</h3>
                <table cellpadding="4">
                    <tr>
                        <td>
                            <asp:Button ID="button_store_cookie" runat="server" Text="Store cookie"></asp:Button>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_output_store_cookie" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="button_retrieve_cookie" runat="server" Text="Retrieve cookie"/>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_output_retrieve_cookie" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Button ID="button_store_session" runat="server" Text="Store session"></asp:Button>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_output_store_session" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="button_retrieve_session" runat="server" Text="Retrieve session"/>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_output_retrieve_session" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                </table> 
            </div>
            <!-- SolarBot 
                by Fausto Velazquez -->
            <div>
                <h3>SolarBot by Fausto Velazquez</h3>
                <p>Note: Enter a question about solar energy, then click on the Action below.</p>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="label_solarbot_input" runat="server" Text="Input:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_solarbot_input" runat="server" Columns="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="label_solarboat_action" runat="server" Text="Action:"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="button_solarbot_button" runat="server" Text="Submit" OnClick="button_solarbot_button_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="label_solarbot_output" runat="server" Text="Output:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_solarbot_output" runat="server" TextMode="MultiLine" Columns="150" Rows="4"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>

            <!-- Email Service 
                by Faris Abujolban -->
            <div>
                <h3>Email service by Faris Abujolban</h3>
                <p>Enter the message you want to send by email, 
                    <br />then enter the email you want the message to be sent to.
                    <br />Finally, click the Send button.
                    <br />Note: use the textboxes below to send an email.
                </p>
                <table cellpaddiong="4">
                    <tr>
                        <td>
                             <asp:Label ID="label_email_content" runat="server" Text="Input message:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_email_content" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="label_email_address" runat="server" Text="Input email:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_email_address" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="button_submit_email" runat="server" Text="Send" OnClick="button_submit_email_click" />
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_email_result" runat="server" Width="200" style="border:none;" Enabled="false" TextMode="MultiLine" Text=""></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- Encryption/Decryption
                by Faris Abujolban -->
            <div>
                <!-- Encryption -->
                <div>
                    <h3>Encrypt by Faris Abujolban</h3>
                    <p>Note: Please input a string of characters of your choice, then click the Action below.</p>
                    <table cellpadding="4">
                        <tr>
                            <td>
                                <asp:Label ID="label_encrypt_input" runat="server" Text="Input:"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="textbox_encrypt_input" runat="server" Width="200"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label_encrypt_action" runat="server" Text="Action:"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="button_encrypt" runat="server" Text="Enrypt" OnClick="button_encrypt_click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label_encrypt_output" runat="server" Text="Output:"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="textbox_encrypt_result" runat="server" Width="200" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="label_reset_encrypt_decrypt" runat="server" Text="Important: To reset Encrypt and Decrypt, click the Reset button."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="button_reset_encrypt_decrypt" runat="server" Text="Reset" />
                            </td>
                        </tr>
                    </table>                    
                </div>
                <!-- Decryption -->
                <div>
                    <h3>Decrypt by Faris Abujolban</h3>
                    <p>Note: Please use the encryption service first, then click the Action below.</p>
                    <table cellpadding="4">
                        <tr>
                            <td>
                                <asp:Label ID="label_decrypt_action" runat="server" Text="Action:"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="button_decrypt" runat="server" Text="Decrypt" OnClick="button_decrypt_click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label_decrypt_output" runat="server" Text="Output:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textbox_decrypt_result" runat="server" Width="200" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>                    
                </div>
            </div>
            <!-- Solar Service
                by Naif Lohani -->
            <div>
                <h3>Solar Service by Naif Lohani</h3>
                <p>Enter the zipcode and roof area. The output is an estimate of the Annual kWh you would save,
                    <br />should you opt in for solar panels.
                    <br />Note: Please enter only numerical values.
                </p>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="label_zipcode" runat="server" Text="Zipcode"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_zipcode" runat="server" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="label_roof_area" runat="server" Text="Roof area (m^2)"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_roof_area" runat="server" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="label_solar_output" runat="server" Text="Annual kWh"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_solar_output" runat="server" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            
            <!-- Contribution Table -->
            <div>
                <h3></h3>
                <table border="1" cellpadding="5">
                    <!-- Table Header -->
                    <thead>
                        <tr>
                            <th colspan="4">Application and Components Summary Table</th>
                        </tr>
                        <tr>
                            <th colspan="4">Percentage of overall contribution: Faris Abujolban: 33%, Fausto Velazquez: 33% Naif Lohani: 33%</th>
                        </tr>
                        <tr>
                            <th>Provider Name</th>
                            <th>Page and component type, e.g., aspx, DLL, SVC, etc.</th>
                            <th>Component description: What does the component do? What are inputs/parameters and output/return value?</th>
                            <th>Actual resources and methods used to implement the component and where this component is used.</th>
                        </tr>
                    </thead>
                    <!-- Table Body -->
                    <tbody>
                        <!-- Contribution #1 -->
                        <!-- by Faris Abujolban -->
                        <tr>
                            <td>Faris Abujolban</td>
                            <td>DLL</td>
                            <td>Hashing function:<br />Input: String<br />Output: String</td>
                            <td>GUI design and C# code behind GUI using HTTP cookies library. It is linked to the login page.</td>
                        </tr>
                        <!-- Contribution #2 -->
                        <!-- by Faris Abujolban -->
                        <tr>
                            <td>Faris Abujolban</td>
                            <td>Email Service (RESTful)</td>
                            <td>[input/output]</td>
                            <td>[description]</td>
                        </tr>
                        <!-- Contribution #3 -->
                        <!-- by Fausto Velazquez -->
                        <tr>
                            <td>Fausto Velazquez</td>
                            <td>Cookies</td>
                            <td>Store user ID and password.</td>
                            <td>GUI design and C# code behind GUI using HTTP cookies library. It is linked to the login page.</td>
                        </tr>
                        <!-- Contribution #4 -->
                        <!-- by Fausto Velazquez -->
                        <tr>
                            <td>Fausto Velazquez</td>
                            <td>Solar ChatBot (RESTful)</td>
                            <td>[input/output]</td>
                            <td>[description]</td>
                        </tr>
                        <!-- Contribution #5 -->
                        <!-- by Naif Lohani -->
                        <tr>
                            <td>Naif Lohani</td>
                            <td>Global.asax</td>
                            <td>Application start event handler</td>
                            <td>C# code as script in Global.asax file</td>
                        </tr>
                        <!-- Contribution #6 -->
                        <!-- by Naif Lohani -->
                        <tr>
                            <td>Naif Lohani</td>
                            <td>Solar Service (RESTful)</td>
                            <td>Input: zipcode, roof area <br />Output: annual kWh</td>
                            <td>Estimates annual solar energy generation based on available roof area and average solar irradiance.</td>
                        </tr>
                    </tbody>
                </table>
            <!-- End of Contribution Table -->
            </div>
        </div>
    </form>
</body>
</html>
