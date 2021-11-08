<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LocalityMap.aspx.cs" Inherits="LocalityMap" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .center_text
        {
            text-align:center;
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
    <center>
    <div style="margin-top:2%;">
        <h2>LOCALITY MAP</h2>
        <asp:DataList ID="DataList" runat="server" RepeatColumns="4" CellPadding="8" OnItemDataBound="DataList_ItemDataBound">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imageUrl" runat="server" OnClientClick="setTarget();" OnClick="imageUrl_Click" Width="250px" Height="150px" ImageUrl='<%#Eval("planNo_image") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="center_text">
                            <asp:Label runat="server" Text='<%#Eval("district")%>'></asp:Label>
                            <br />
                            <asp:Label runat="server" Text='<%#Eval("estate")%>'></asp:Label>
                            <br />
                            <asp:Label runat="server" Text='<%#Eval("planNo_image")%>' Visible="false" ID="map_url"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="labelEmpty" runat="server" Visible="false"></asp:Label>
        </center>
   <script type="text/javascript">
       function setTarget() {
           document.forms[0].target = "_blank";
       }
    </script>
    <center>
        <br />
            <br />
            <div>
                <a href="SearchSelection.aspx" class="backbtn" runat="server">BACK</a>
            </div>
    </center>
    </asp:Content>
