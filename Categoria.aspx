<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categoria.aspx.cs" Inherits="Categoria" MasterPageFile="Homepage.master" %>

<asp:Content ContentPlaceHolderID="Categoria" runat="server">

    <div class="section" style="padding-bottom: 100px;">
        <div class="container">
            <div class="row" style="margin-bottom: 30px;">
                <div class="col-md-12">
                    <div class="input-group">
                        <asp:TextBox ID="searchTb" CssClass="form-control" Placeholder="Ricerca negli articoli..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton runat="server" ID="searchButton" Text="Cerca" CssClass="btn btn-default" OnClick="searchButton_Click"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

            <div class="row">
                <asp:Repeater ID="repeater" runat="server" OnItemDataBound="repeater_ItemDataBound1">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="btn-group btn-block">
                                <ul class="nav nav-pills nav-justified">
                                    <li class="dropdown">
                                        <button class="btn-block btn-default img-responsive dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true"
                                            aria-expanded="true" style="background: url(https://unsplash.imgix.net/photo-1422513391413-ddd4f2ce3340?w=1024&amp;q=50&amp;fm=jpg&amp;s=282e5978de17d6cd2280888d16f06f04)
                                         no-repeat; height: 237px; border-radius: 0px; font-size: 30px; color: white; margin-top: 20px;">
                                            <%# Eval("Nome") %></button>
                                        <ul class="dropdown-menu" id="menu1">
                                            <asp:Repeater runat="server" ID="child">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton Text='<%# Eval("Nome") %>' OnClick="openArgument" CommandArgument='<%# Eval("Id") %>' runat="server"></asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
                            <asp:HiddenField Value='<%# Eval("Id") %>' runat="server" ID="hidden" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
