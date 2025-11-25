<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication1.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Back button -->
            <div>
                <asp:Button ID="button_back_to_default" runat="server" Text="Back to default" PostBackUrl="~/Default.aspx" />
            </div>
            <!-- Title -->
            <div>
                <h3>Member Page</h3>
            </div>

            <!-- Contents/Body -->
            <div>
                <!-- Chat Container -->
                <div>
                    <asp:Panel ID="panel_chatbox" runat="server" Width="200" Height="200"></asp:Panel>
                </div>
                <!-- Input Container -->
                <div>
                    <asp:TextBox ID="textbox_message" runat="server"></asp:TextBox>
                    <asp:Button ID="button_send_message" runat="server" Text="Send" OnClick="button_send_message_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
