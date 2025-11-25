<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member_Sign_Up.aspx.cs" Inherits="WebApplication1.Member_Sign_Up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Login + CAPTCHA  
     by Fausto Velazquez -->
            <div>
                <h3>Member Sign up</h3>
                <div>
                    <!-- Login -->
                    <div>
                        <table cellpadding="4">
                            <tr>
                                <td>User Name:  </td>
                                <td>
                                    <input name="txtUserName" type="text" id="txtUserName" />
                                </td>
                            </tr>
                            <tr>
                                <td>Password: </td>
                                <td>
                                    <input name="txtPassword" type="password" id="txtPassword" />
                                </td>
                            </tr>
                            <tr>
                                <td>Confirm Password: </td>
                                <td>
                                    <input name="txtPassword" type="password" id="txtConfirmPassword" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="submit" name="btnLogin" value="Submit" id="btnLogin" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- CAPTCHA -->
                    <div>
                        <asp:Image ID="image_captcha" runat="server" Width="200" AlternateText="captcha image" />
                        <br />
                        <br />
                        <asp:Button ID="button_refresh_captcha" runat="server" Text="Refresh captcha" OnClick="button_refresh_captcha_Click" />
                        <br />
                        <br />
                        <asp:Label ID="label_captcha_input" runat="server" Text="Please enter the captcha here"></asp:Label>
                        <asp:TextBox ID="textBox_captcha_input" runat="server" Width="50"></asp:TextBox>
                    </div>
                </div>
            </div>
            <!-- Back button -->
            <div>
                <asp:Button ID="button_back_to_default" runat="server" Text="Back to default" PostBackUrl="~/Default.aspx" />
            </div>
        </div>
    </form>
</body>
</html>
