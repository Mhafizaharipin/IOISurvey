<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FunctionSelection.aspx.cs" Inherits="FunctionSelection" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .button
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            width: 150px;
            font-size: 18px;
            height: 40px;
            border-radius: 5px;
        }

        .button:hover
        {
            opacity:0.8;
        }
        
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <h2 style="margin-top:7%">SELECT FUNCTION</h2>
            <table style="margin-top:2%">
                <tr>
                    <td>
                        <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" Text="ADD" CssClass="button" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="searchBtn" runat="server" OnClick="searchBtn_Click" Text="SEARCH" CssClass="button" />
                    </td>
                </tr>
                </table>
        </center>
    </div>
</asp:Content>

