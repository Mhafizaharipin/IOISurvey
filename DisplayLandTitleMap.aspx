<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayLandTitleMap.aspx.cs" Inherits="DisplayLandTitleMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IOI Survey</title>
    <link rel="shortcut icon" href="images/icon.png" />
    <style>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image runat="server" id="image1" Width="1000px" Height="880px"/>
    </div>
    </form>
</body>
</html>
