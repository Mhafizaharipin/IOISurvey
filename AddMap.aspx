<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMap.aspx.cs" Inherits="AddMap"  MasterPageFile="~/MasterPage.master"%>
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
            <h2>ADD MAP</h2>
            <div id="map_type" runat="server">
                <table>
                    <tr>
                        <td>Type</td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList CssClass="ddl" ID="type" runat="server" OnSelectedIndexChanged="type_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Select Map" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Topographic(S)" Value="topo_s"></asp:ListItem>
                                <asp:ListItem Text="Topographic(N)" Value="topo_n"></asp:ListItem>
                                <asp:ListItem Text="Perimeter" Value="perimeter"></asp:ListItem>
                                <asp:ListItem Text="Soil Reconnaissance" Value="soil_r"></asp:ListItem>
                                <asp:ListItem Text="Semi Detailed Soil" Value="soil_d"></asp:ListItem>
                                <asp:ListItem Text="Marine" Value="marine"></asp:ListItem>
                                <asp:ListItem Text="Locality" Value="locality"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="others"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="map_add" runat="server">
            <table>
                <tr>
                    <td>Plan No (File)</td>
                    <td>:</td>
                    <td style="float:left;">
                        <asp:FileUpload ID="planno" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="UPLOAD" OnClick="btnUploadPlan_Click" />
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
                    <td>Plan No</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="plan_no" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>District</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="district" runat="server"></asp:TextBox>
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
            <div id="map_perimeter" runat="server">
            <table>
                <tr>
                    <td>Plan No (File)</td>
                    <td>:</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="Button1" runat="server" Text="UPLOAD" OnClick="btnUploadPlanP_Click" />
                    </td>
                </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" OnClientClick="DisplayPlanNoP()" runat="server" width="450px" Height="250px"/>
                        </td>
                    </tr>
                <tr>
                    <td>Plan No</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="planno_p" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>District</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="district_p" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Name/Estate</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="estate_p" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>TV</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="tv" runat="server"></asp:TextBox>
                        <asp:Label Text="Page:" runat="server" CssClass="label_page"></asp:Label>
                        <asp:TextBox ID="tvpage" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
           </div>
            <br />
            <script type="text/javascript">
                function DisplayPlanNoP()
                {
                    window.open('DisplayPlanNoPerimeter.aspx', 'open_window', 'width=1000, height=900, left = 0, top = 0, center= yes, scrollbars= 1');
                }
                function DisplayPlanNo() {
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