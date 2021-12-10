<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPerimeterMap.aspx.cs" Inherits="AddPerimeterMap"  MasterPageFile="~/MasterPage.master"%>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .label_page
        {
            margin-left:25px;
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
        .ddl
        {
            font-size:15px;
            height:25px;
        }
        div
        {
            font-size:18px;
        }

    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:2%;">
        <center>
            <h2>ADD LAND TITLE MAP</h2>
            <div id="map_add" runat="server">
            <table>
                <tr>
                    <td>Land Title Map (File)</td>
                    <td>:</td>
                    <td style="float:left;">
                        <asp:FileUpload ID="map" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="UPLOAD" OnClick="btnUploadMap_Click" />
                    </td>
                </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:ImageButton ID="image2" OnClientClick="DisplayPlanNo()" runat="server" width="450px" Height="250px"/>
                        </td>
                    </tr>
                <tr>
                    <td>Land Title</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="land_title" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Estate</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="estate" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
                </div>
            <br />
           
            <script type="text/javascript">
                function DisplayPlanNoP()
                {
                    window.open('DisplayPlanNo.aspx', 'open_window', 'width=1000, height=900, left = 0, top = 0, center= yes, scrollbars= 1');
                }
            </script>
            <div id="button" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Button CssClass="button" ID="savePlan" Text="SAVE" runat="server" OnClick="savePlan_Click" />
                    </td>
                    <td>
                        <asp:Button CssClass="button" ID="deletePlan" Text="DELETE" runat="server" OnClick="deletePlan_Click" />
                    </td>
                    <td>
                        <asp:Button CssClass="button" ID="exitPlan" Text="EXIT" runat="server" OnClick="exitPlan_Click" />
                    </td>
                </tr>
            </table>
           </div>
        </center>
    </div>
</asp:Content>