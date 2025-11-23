<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Staff" %>

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
                <h3>Staff Login</h3>
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
                                    <input type="submit" name="btnLogin" value="Submit" id="btnLogin" />
                                </td>
                            </tr>
                        </table>
                        <p>No account? Try Test Account: Bob 123</p>
                    </div>
                </div>
            </div>
            <!-- Back button -->
            <div>
                <asp:Button ID="button_back_to_default" runat="server" Text="Back to default" PostBackUrl="~/Default.aspx"/>
            </div>
        </div>
    </form>
</body>
</html>
