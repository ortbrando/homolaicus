<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="~/css/bootstrap.min.css"/>
    <link href="~/css/signin.css" rel="stylesheet"/>
    <script src="~/js/jquery.min.js"></script>
    <script src="~/js/bootstrap.min.js"></script>
</head>
<body>
    <div>
        <div class="container">

      <form class="form-signin" id="formLogin" runat="server">
        <h2 class="form-signin-heading">Login</h2>
        <label for="inputEmail" class="sr-only">Username</label>
          <asp:TextBox ID="InputEmail" CssClass="form-control" runat="server" placeholder="Username"></asp:TextBox>
          <label for="inputPassword" class="sr-only">Password</label>
          <asp:TextBox ID="InputPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password">password</asp:TextBox>
          <div class="checkbox">
          <label id="ciao">
            <input type="checkbox" value="remember-me" /> Ricordami
          </label>
        </div>
          <asp:Button CssClass="btn btn-lg btn-primary btn-block" OnClick="login" Text="Sign In" runat="server" />
          <asp:Label Text="" ID="lblError" runat="server"></asp:Label>
                  
      </form>

    </div>
    </div>
    
</body>
</html>
