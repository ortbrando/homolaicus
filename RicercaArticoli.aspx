<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RicercaArticoli.aspx.cs" Inherits="RicercaArticoli" MasterPageFile="~/Homepage.master" %>

<asp:Content ContentPlaceHolderID="RicercaArticoli" runat="server">
    <div class="section" style="padding-bottom: 350px;">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 style="margin-bottom: 30px;">Ricerca sugli articoli: "
                        <asp:Label runat="server" ID="textInput"></asp:Label> "</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <ul class="media-list">
                        <asp:Repeater runat="server" ID="resultRepeater">
                            <ItemTemplate>
                                <li class="media">
                                    <a class="pull-left">
                                        <i class="fa fa-2x fa-book" aria-hidden="true"></i>
                                    </a>
                                    <div class="media-body">
                                        <h4 class="media-heading"><%# Eval("Nome") %></h4>
                                        <a href="Argomento.aspx?Sub=<%# Eval("IdSottocategoria") %>&Arg=<%# Eval("Id") %>"> Visualizza articolo </a>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>