<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPerimeterPlan.aspx.cs" Inherits="SearchPlan" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
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
        .backbtn
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:2px;
            height:25px;
            width:80px;
            font-size:15px;
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
    <link rel="stylesheet" href="StyleSheet.css" />
    <div style="margin-top:2%;">
        <center>
            <h2>PERIMETER SURVEY MAP</h2>
            <table>
                <tr>
                    <td>Plan No</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="planno" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button CssClass="button" ID="search_planno" runat="server" Text="SEARCH" OnClick="search_planno_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div id="result" runat="server">
                <!-- search result will be displayed here -->
                <table>
                    <tr>
                        <td>Plan No</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="planNumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:ImageButton ID="plan_url" runat="server" OnClientClick="DisplayPlanNo()" width="450px" Height="250px" />
                        </td>
                    </tr>
                    <tr>
                        <td>District</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="district" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Estate</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="estate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Traverse Vol</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="tvName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Page</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="tvpage" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            <script type="text/javascript">
               function DisplayPlanNo()
               {
                  window.open('DisplayPlanNoPerimeter.aspx', 'open_window', 'width=1000, height=900, left = 0, top = 0, center=yes, scrollbars=1');
               }
            </script>
            </div>
            <br />
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Button CssClass="button" ID="deletebtn" runat="server" OnClick="deletebtn_Click" Text="DELETE" />
                        </td>
                        <td>
                            <a href="SearchPerimeterSelection.aspx" class="backbtn" runat="server">BACK</a>
                        </td>
                    </tr>
                </table>
            </div>
        </center>
    </div>
</asp:Content>
    