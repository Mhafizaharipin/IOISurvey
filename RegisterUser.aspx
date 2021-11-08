<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterUser.aspx.cs" Inherits="RegisterUser" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        div
        {
            margin-top: 2%;
        }
         .button
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:2px;
            height:25px;
            font-size:15px;
        }

        .button:hover
        {
            opacity:0.8;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div style="margin-top:2%;">
        <h2>REGISTER USER</h2>
        <table>
            <tr>
                <td>Employee ID</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                 <td style="float:left">
                    <asp:Label ID="lbluser" runat="server" Text="Username must be employee ID"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" EnableTheming="true" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                 <td>
                    <asp:Label ID="lblpass" runat="server" Text="Password must be IC number without dash(-)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Full Name</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>

            </tr>
            <td>

            </td>
            <tr>
                <td>
                    <asp:Label ID="label1" runat="server"></asp:Label>
                </td>
                <td></td>
                <td>
                    <asp:Button ID="registerbtn" CssClass="button" Text="REGISTER" OnClick="registerbtn_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
        </center>
</asp:Content>