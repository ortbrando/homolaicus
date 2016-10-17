<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Libri.aspx.cs" Inherits="Libri" MasterPageFile="Homepage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="Libri">
    <div class="container">
        <div class="row" style="margin-bottom: 30px;">
            <div class="col-md-12">
                <div class="input-group">
                    <asp:TextBox ID="searchTb" CssClass="form-control" Placeholder="Ricerca sugli indici..." runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:LinkButton runat="server" ID="searchButton" Text="Cerca" CssClass="btn btn-default" OnClick="searchButton_Click"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                    </span>
                </div>
                <!-- /input-group -->
            </div>
            <!-- /.col-lg-6 -->
            </div>
       
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>N.</th>
                    <th>Testo cartaceo su Lulu     <i class="fa fa-cart-arrow-down" aria-hidden="true"></i></th>
                    <th>Anno</th>
                    <th>Indice</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="booksRepeater">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Numero") %></td>
                            <td><a href="<%# Eval("Link") %>"><%# Eval("Nome") %></a></td>
                            <td><%# Eval("Anno") %></td>
                            <asp:Label ID="indice" runat="server" Visible="false"> <%# Eval("Indice") %></asp:Label>
                            <td>
                                <button type="button" class="btn-link"
                                    data-toggle="modal" data-target="#<%# Eval("Id") %>">
                                    <i class="fa fa-arrow-circle-o-right" aria-hidden="true"></i>
                                </button>
                            </td>
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
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
