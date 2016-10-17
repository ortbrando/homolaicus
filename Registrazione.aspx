<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrazione.aspx.cs" Inherits="Registrazione" MasterPageFile="Homepage.master" %>

<asp:Content ContentPlaceHolderID="Registrazione" runat="server">
    <div class="container" style="padding-bottom: 60px;">

<div class="row">
    <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
			<h2>Registrazione <small>Gratuita ieri, ora e sempre</small></h2>
        <asp:Label ID="prova" runat="server"></asp:Label>
			<hr class="colorgraph">
			<div class="form-group">
                <asp:TextBox ID="Username" CssClass="form-control input-lg" Placeholder="Username" runat="server"></asp:TextBox>
				
			</div>
			<div class="form-group">
                <asp:TextBox ID="Email" CssClass="form-control input-lg" Placeholder="Indirizzo Email" runat="server"></asp:TextBox>
			</div>
			<div class="row">
				<div class="col-xs-12 col-sm-6 col-md-6">
					<div class="form-group">
                        <asp:TextBox ID="Password" CssClass="form-control input-lg" Placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
					</div>
				</div>
				<div class="col-xs-12 col-sm-6 col-md-6">
					<div class="form-group">
                        <asp:TextBox ID="CheckPassword" CssClass="form-control input-lg" Placeholder="Conferma Password" runat="server" TextMode="Password"></asp:TextBox>
					</div>
				</div>
			</div>
			
			
			<hr class="colorgraph">
			<div class="row">
				<div class="col-xs-12 col-md-6">
                    <asp:Button ID="Registrati" Text="Registrati" OnClick="Registrati_Click" CssClass="btn btn-primary btn-block btn-lg" runat="server" />
                    <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
                    </div>
				<div class="col-xs-12 col-md-6">
                    <a href="Login.aspx" class="btn btn-success btn-block btn-lg">Login</a></div>
			</div>
	</div>
</div>
</div>
</asp:Content>
