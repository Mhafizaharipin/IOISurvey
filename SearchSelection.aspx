<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchSelection.aspx.cs" Inherits="SearchSelection" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .link
        {
            margin-left:10%;
            margin-right: 10%;
            color: black;
            font-family: Garamond, serif;
            font-weight:bold;
            font-size:18px;
        }

        .link:hover
        {
            color:blue;
        }

        table
        {
            width:35%;
            text-align:center;
            border: solid 1px;
        }
        td
        {
            border: solid 1px;
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
        tr:nth-child(even)
        {
            background-color:#f2f2f2;
        }
        tr:hover
        {
            background-color:#ddd;
        }
        table
        {
            background-color:white;
        }
    </style>
</asp:Content> 

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h2>SEARCH MAP</h2>
        <div>
            <table>
                <tr>
                    <td>
                        <a href="SearchPerimeterSelection.aspx" class="link">Perimeter Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="SearchTopoS.aspx" class="link">Topographic (S) Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="SearchTopoN.aspx" class="link">Topographic (N) Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="SoilMap.aspx" class="link">Soil Reconnaissance Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="SoilMapD.aspx" class="link">Semi Detailed Soil Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="MarineMap.aspx" class="link">Marine Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="LocalityMap.aspx" class="link">Locality Map</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="Others.aspx" class="link">Others Map</a>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button CssClass="button" ID="exitBtn" runat="server" Text="EXIT" OnClick="exitBtn_Click" />
        </div>
    </center>
</asp:Content>

