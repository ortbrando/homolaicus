<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accedi.aspx.cs" Inherits="Accedi" MasterPageFile="Homepage.master" %>

<asp:Content ContentPlaceHolderID="Accedi" runat="server">
    <div class="container">
        <div class="row" style="margin-top: 20px; padding-bottom: 60px;">
            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                <fieldset>
                    <h2>Effettua l'accesso</h2>
                    <hr class="colorgraph">
                    <div class="form-group">
                        <asp:TextBox ID="tbNickname" runat="server" placeholder="Username" CssClass="form-control input-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tbPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control input-lg"></asp:TextBox>
                    </div>
                    <span class="button-checkbox">
                        <asp:LinkButton CssClass="btn btn-link pull-right" placeholder="Hai dimenticato la Password?" runat="server"></asp:LinkButton>
                    </span>
                    <hr class="colorgraph">
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6">
                            <asp:Button ID="btnAccedi" OnClick="btnAccedi_Click" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Accedi" />
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-6">
                            <a href="Registrazione.aspx" class="btn btn-lg btn-primary btn-block">Registrati</a>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
