<%@ Page Language="C#" Async="true" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication1.Member" %>

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
                    <asp:Panel ID="panel_chatbox" runat="server" Width="1000" Height="300" Style="overflow: scroll;" ScrollBars="Both"></asp:Panel>
                </div>
                <!-- Input Container -->
                <div>
                    <asp:TextBox ID="textbox_message" runat="server" Width="900"></asp:TextBox>
                    <asp:Button ID="button_send_message" type="sumbit" runat="server" Text="Send" OnClick="button_send_message_Click" />
                </div>
                <br />
                <!-- Email Container -->
                <div>
                    <p>
                        Would you like to receive this conversation to your email?
                        <br />
                        Note: use the option below to send an email.
                    </p>
                    <table cellpadding="4">
                        <tr>
                            <td>
                                <asp:Label ID="label_email_address" runat="server" Text="Your email:"></asp:Label>
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
                                <asp:Label ID="label_submit_email_response" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <p>
                        Important: To reset the inputs and outputs, please click the Reset button below.
                    </p>
                    <asp:Button ID="button_email_reset" runat="server" Text="Reset" OnClick="button_email_reset_Click" />
                </div>
                <!-- Solar Energy Container -->
                <div>
                    <p>Would you like to know the estimated annual kWh savings from installing solar panels on your roof?
                        <br />Enter the zipcode and roof area. The output is an estimate of the Annual kWh you would save,
                        <br />
                        should you opt in for solar panels.
                        <br />
                        Note: Please enter only numerical values.
                    </p>
                    <table cellpadding="4">
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
                        <tr>
                            <td>
                                <asp:Button ID="button_solar" runat="server" Text="Submit" OnClick="button_solar_Click" />
                            </td>
                            <td>
                                <asp:TextBox ID="textbox_solar_error_output" runat="server" Style="border: none;" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <p>
                        Important: To reset the Solar Service inputs and outputs, please click the Reset button below.
                    </p>
                    <asp:Button ID="button_solar_reset" runat="server" Text="Reset" OnClick="button_solar_reset_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
