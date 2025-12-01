<%@ Page Language="C#" AutoEventWireup="true" Async="true" MaintainScrollPositionOnPostBack="true" CodeBehind="Staff_Login.aspx.cs" Inherits="WebApplication1.Staff_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- Login + CAPTCHA -->
            <div>
                <h3>Staff Login</h3>
                <p>
                    Note: Enter your username and password, then enter the correct captcha,
                    <br />
                    and click the Sign in button to continue.
                </p>
                <div>
                    <!-- Login -->
                    <div>
                        <table cellpadding="4">
                            <tr>
                                <td>User Name:  </td>
                                <td>
                                    <input name="input_username" type="text" id="input_username" />
                                </td>
                            </tr>
                            <tr>
                                <td>Password: </td>
                                <td>
                                    <input name="input_password" type="password" id="input_password" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="button_signin" runat="server" Text="Sign in" OnClick="button_signin_Click"/>
                                </td>
                                <td>
                                    <!-- output error message -->
                                    <asp:Label ID="label_login_error" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p>
                            No account? Contact your administrator.
                        </p>
                    </div>
                </div>
        </div>
        <!-- Back button -->
        <div>
            <asp:Button ID="button_back_to_default" runat="server" Text="Back to default" PostBackUrl="~/Default.aspx"/>
        </div>

        <!-- End of code-->
        </div>
    </form>
</body>
</html>
