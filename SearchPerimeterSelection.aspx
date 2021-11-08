<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPerimeterSelection.aspx.cs" Inherits="SearchPerimeterSelection" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
         .button
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            width: 250px;
            font-size: 18px;
            height: 40px;
            border-radius: 5px;
        }

        .button:hover
        {
            opacity:0.8;
        }
        .backbtn
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:2px;
            height:25px;
            width:80px;
            font-size:18px;
            display:block;
            line-height:25px;
            text-align:center;
        }

        .backbtn:hover
        {
            opacity:0.8;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div style="margin-top:2%;">
            <h2>SEARCH PERIMETER SURVEY MAP</h2>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="byPlanNo" CssClass="button" runat="server" Text="SEARCH BY PLAN NO." OnClick="byPlanNo_Click" />
                    </td>
                    <td></td>
                    <td>
                        <asp:Button ID="byEstate" CssClass="button" runat="server" Text="SEARCH BY ESTATE" OnClick="byEstate_Click" />
                    </td>
                </tr>
                </table>
            <br />
            <table>
                <tr>
                    <td></td>
                    <td>
                        <a href="SearchSelection.aspx" class="backbtn" runat="server">BACK</a>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>
