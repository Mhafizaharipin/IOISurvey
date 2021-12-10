<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMapSelection.aspx.cs" Inherits="AddMapSelection" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .button
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color:royalblue;
            color:white;
            cursor:pointer;
            font-size: 18px;
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
            <h2 style="margin-top:7%">SELECT ADD MAP</h2>
            <table style="margin-top:2%">
                <tr>
                    <td>
                        <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" Text="ADD OTHER MAP" CssClass="button" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="addMap" runat="server" OnClick="addMap_Click" Text="ADD LAND TITLE MAP" CssClass="button" Width="218px" />
                    </td>
                </tr>
                </table>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="backbtn" runat="server" Text="BACK" CssClass="button" Width="106px" OnClick="backbtn_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
