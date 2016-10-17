<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RicercaLibri.aspx.cs" Inherits="Ricerca" MasterPageFile="Homepage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="Ricerca">
    <div class="section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 style="margin-bottom: 30px;">Ricerca sugli indici: "
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
                                        <a href="<%# Eval("LinkGoogle") %>"> Anteprima E-Book </a>
                                        <br />
                                        <a href="<%# Eval("Link") %>">Acquista su Lulu</a>
                                        <br />
                                        <button type="button" class="btn-link"
                                    data-toggle="modal" data-target="#<%# Eval("Id") %>">Visualizza indice
                                </button>
                                        <div id="<%# Eval("Id") %>" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4>
                                                <div class="modal-title"><%# Eval("Nome") %></div>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <div style="text-align: center;"><a href="<%# Eval("LinkGoogle") %>">Anteprima E-Book </a></div>
                                            <img class="img-responsive center-block" src='<%# Eval("Copertina") %>' />
                                            <br />
                                            <br />
                                            <%# Eval("Indice") %>
                                        </div>
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
