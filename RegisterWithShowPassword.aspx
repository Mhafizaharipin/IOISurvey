<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterWithShowPassword.aspx.cs" Inherits="RegisterWithShowPassword" MasterPageFile="~/MasterPage.master" %>


<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>  
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
    <script type="text/javascript">
        $(document).ready(function () {
            $('#show_password').hover(function show() {
                //Change the attribute to text  
                $('#txtPassword').attr('type', 'text');
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
            function () {
                //Change the attribute back to password  
                $('#txtPassword').attr('type', 'password');
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
            });
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');
            });
        });
    </script>   
        <div class="container">  
            <h2>Show or Hide Password</h2>  
            <div class="row">  
                <div class="col-md-6">  
                    <p>Hover on the eye to show/hide the password</p>  
                    <label>Password</label>  
                    <div class="input-group">  
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>  
                        <div class="input-group-append">  
                            <button id="show_password" class="btn btn-primary" type="button">  
                                <span class="fa fa-eye-slash icon"></span>  
                            </button>  
                        </div>  
                    </div>  
                </div>  
                <div class="col-md-6">  
                    <p>Check to show/hide the password</p>  
                    <label>Password</label>  
                    <div class="input-group">  
                        <asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>  
                        <div class="input-group-append">  
                            <span class="input-group-text">  
                                <asp:CheckBox ID="ShowPassword" runat="server" CssClass="checkbox" />  
                            </span>  
                        </div>  
                    </div>  
                </div>  
            </div>  
        </div>  
 
</asp:Content>
