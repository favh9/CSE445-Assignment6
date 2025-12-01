<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Title -->
            <div>
                <h3>Staff Page</h3>
            </div>
            <!-- Back button -->
            <div>
                <asp:Button ID="button_back_to_default" runat="server" Text="Back to default" PostBackUrl="~/Default.aspx"/>
                <!-- By Naif Lohani -->
                <br />
                
                <br />
                <asp:Repeater ID="repUsers" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Username") %></td>
                            <td>
                                <asp:Button 
                                    ID="btnDeleteUser" 
                                    runat="server" 
                                    Text="Delete User"
                                    CommandName="delete"
                                    CommandArgument='<%# Eval("Username") %>'
                                    OnCommand="DeleteUser_Command" />
                            </td>
                        </tr>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <asp:TextBox ID="tbUsernameInput" runat="server" placeholder="Enter Username for Staff"></asp:TextBox>
                <asp:TextBox ID="tbPasswordInput" runat="server" placeholder="Enter Password for Staff"></asp:TextBox>
                <asp:Button ID="addUser" runat="server" Text="Add User" OnClick="addUser_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
