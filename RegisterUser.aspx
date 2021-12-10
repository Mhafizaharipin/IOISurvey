<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterUser.aspx.cs" Inherits="RegisterUser" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">>  
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
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
                     &nbsp;</td>
            </tr>
            <tr>
                <td>Password</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" EnableTheming="true" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="ShowPassword" runat="server" CssClass="checkbox" OnCheckedChanged="ShowPassword_CheckedChanged" AutoPostBack="true"/>Show Password
                </td>
            </tr>
       
            <tr>
                <td></td>
                <td></td>
                 <td>
                     &nbsp;</td>
            </tr>
            <tr>
                <td>Full Name</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
                </td>
            </tr>
           
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