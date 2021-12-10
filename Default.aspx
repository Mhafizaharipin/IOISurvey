<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IOI Survey</title>
    <link rel="shortcut icon" href="images/icon.png" />
    <style>
        body{
            width:100%;
            background: #fff;
        }
        #form1
        {
            margin-top: 5%;
        }
        .login
        {
            font-family:Arial, Helvetica, sans-serif;
        }
        #loginBtn
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:2px;
            height:25px;
            font-size:15px;
            width:210px;
        }
        #loginBtn:hover
        {
            opacity:0.8;
        }
        div
        {
            width:40%;
            background:white;
            padding-top: 20px;
            padding-bottom : 20px;
        }
        .txtbox
        {
            height:25px;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div>
        <asp:Image runat="server" ImageUrl="~/images/icon.png" />
        <h3>Sign into your account</h3>
        <br />
        <table class="login">
            <tr>
                <td style="float:left">
                    <asp:Label ID="usernamelbl" Text="Employee ID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" CssClass="txtbox" ID="username" placeholder="Employee ID" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="float:left">
                    <asp:Label ID="passwordlbl" Text="Password" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="password" CssClass="txtbox" runat="server" TextMode="Password"  Width="200px" placeholder="IC No without dash (-)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ShowPassword" runat="server" CssClass="checkbox" OnCheckedChanged="ShowPassword_CheckedChanged" AutoPostBack="true"/>Show Password
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="loginBtn" runat="server" Text="LOGIN" Width="200px" OnClick="loginBtn_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    </center>
</body>
</html>
