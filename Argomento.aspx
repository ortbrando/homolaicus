<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Argomento.aspx.cs" Inherits="_Default" MasterPageFile="Homepage.master" %>

<asp:Content ContentPlaceHolderID="Argomento" runat="server">
    <!-- Breadcrumb con path -->
    <ol class="breadcrumb" style="padding-top: 5px;">
        <li><a href="HomePage.aspx">Home</a></li>
        <li><a href="#">
            <asp:LinkButton runat="server" ID="cat" OnClick="cat_Click"></asp:LinkButton>
        </a></li>
        <li><a href="#">
            <asp:LinkButton runat="server" ID="sub" OnClick="cat_Click"></asp:LinkButton>
        </a></li>
        <li><a>
            <asp:Label runat="server" ID="arg"></asp:Label>
        </a></li>
    </ol>

    <!-- Facebook -->
    <script language="javascript">
        function fbshareCurrentPage() {
            window.open("https://www.facebook.com/sharer/sharer.php?u=" + escape(window.location.href) + "&t=" + document.title, '',
            'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=300,width=600');
            return false;
        }
    </script>


    <!-- Desktop -->
    <div class="container">
        <div class="row hidden-lg hidden-md center-block">
                <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <!-- Link-Reat -->
                <ins class="adsbygoogle"
                    style="display: block"
                    data-ad-client="ca-pub-1911108298391583"
                    data-ad-slot="5752475758"
                    data-ad-format="link"></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>
        </div>
    </div>
    
    <div class="row">
        <!-- Menu laterale Affix -->
        <nav id="affix-nav" class="sidebar col-lg-2 col-md-2 hidden-sm hidden-xs">
            <ul class="nav sidenav" data-spy="affix" data-offset-top="330">
                <li>


                    <ul class="nav">
                        <asp:Repeater runat="server" ID="menu">
                            <ItemTemplate>
                                <li><a href="#<%# Eval("Nome") %>"><%# Eval("Nome") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
            </ul>
        </nav>
        <!-- Sezione centrale con pubblicità e contenuto -->
        <section id="content" class="col-lg-9 col-md-9 hidden-sm hidden-xs">
            <div class="row">
                <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <!-- Link-Reat -->
                <ins class="adsbygoogle"
                    style="display: block"
                    data-ad-client="ca-pub-1911108298391583"
                    data-ad-slot="5752475758"
                    data-ad-format="link"></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>
            </div>
            <article style="padding-bottom: 50px;">
                <asp:Repeater runat="server" ID="articleRepeater" >
                    <ItemTemplate>

                        <section id="<%# Eval("Nome") %>">
                            <h2>
                                <asp:Label runat="server" Text='<%# Eval("Nome") %>' ID="title"></asp:Label></h2>
                            <asp:Label runat="server" Text='<%# Eval("HtmlCode")%>' ID="htmlcode"></asp:Label>
                        </section>
                    </ItemTemplate>
                </asp:Repeater>
            </article>
            <hr>
            <div class="row">
                <div class="col-lg-3 col-md-3 hidden-sm hidden-xs">
                    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                    <!-- Skyscraper -->
                    <ins class="adsbygoogle"
                        style="display: inline-block; width: 300px; height: 600px"
                        data-ad-client="ca-pub-1911108298391583"
                        data-ad-slot="1182675359"></ins>
                    <script>
                        (adsbygoogle = window.adsbygoogle || []).push({});
                    </script>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-10 col-xs-12" style="padding-bottom: 50px;">
                <!-- Comments Form -->
                <div class="well">
                    <h4>Lascia un commento</h4>
                    <div class="form-group">
                        <asp:TextBox ID="tbComment" CssClass="form-control" style="resize: none;" TextMode="MultiLine" runat="server" Placeholder="Inserisci commento..." Rows="3"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnComment" runat="server" CssClass="btn btn-primary" Text="Inserisci" OnClick="btnComment_Click" />
                    <asp:Label ID="lblConfirm" runat="server" Visible="false"></asp:Label>
                </div>
                <hr>
                <!-- Comment -->
                <asp:Repeater ID="repeaterComments" runat="server">
                    <ItemTemplate>
                        <div class="media">
                            <a class="pull-left">
                                <img class="media-object img-responsive" width="64px" height="64px" src="<%# Eval("Immagine") %>" alt="">
                            </a>
                            <div class="media-body">
                                <h4 class="media-heading"><%# Eval("Nickname") %>
                                    <small><%# Eval("Data") %></small>
                                </h4>
                                <%# Eval("Testo") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                    </div>
            </div>
        </section>
        <!-- Colonna laterale dx con pulsanti social e PDF -->
        <div class="col-md-1 hidden-sm hidden-xs" style="text-align: center;">
            <div class="row" style="position: fixed;">
                <div class="col-md-12">
                    <a href="javascript:fbshareCurrentPage()" target="_blank" alt="Share on Facebook">
                        <div class="fb-share-button">Facebook</div>
                    </a>
                    <a href="https://twitter.com/share" class="twitter-share-button">Tweet</a>
                    <br />
                    <script>
                        !function (d, s, id) {
                            var js, fjs = d.getElementsByTagName(s)[0],
                                p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) {
                                    js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js';
                                    fjs.parentNode.insertBefore(js, fjs);
                                }
                        }(document, 'script', 'twitter-wjs');</script>
                    <a class="g-plus" data-action="share" data-annotation="none" style="color: rgb(204, 24, 30); text-decoration: none;"><i class="fa fa-4x fa-google-plus" aria-hidden="true"></i></a>
                    <script src="https://apis.google.com/js/platform.js" async="" defer="">
                                    { lang: 'it' }
                    </script>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Save to PDF" OnClick="savePDF" />
                </div>
            </div>
            <br>
            <br>
        </div>
    </div>

    <!-- Mobile -->
    <div class="hidden-lg hidden-md section">
        <div class="container-fluid">
            <div class="row">
                <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <!-- Link-Reat -->
                <ins class="adsbygoogle"
                    style="display: block"
                    data-ad-client="ca-pub-1911108298391583"
                    data-ad-slot="5752475758"
                    data-ad-format="link"></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:Repeater ID="mobileRepeater" runat="server">
                        <ItemTemplate>
                            <h3><a class="btn-block" role="button" data-toggle="collapse" href="#Id<%# Eval("Id") %>"
                                aria-expanded="false" aria-controls="Id<%# Eval("Id") %>" style="color: black; text-decoration: none;"><!--<i class="fa fa-angle-down"></i>--><%# Eval("Nome") %></a> </h3>
                            <hr />
                            <div class="collapse" id="Id<%# Eval("Id") %>">
                                <div style="padding-bottom: 20px;" >
                                    <%# Eval("HtmlCode") %>
                                </div>
                            </div>
                            <!--
                            <script>
                                $(document).ready(function () {
                                    $('.collapse')
                                        .on('shown.bs.collapse', function () {
                                            $(this)
                                                .parent()
                                                .find(".fa-angle-down")
                                                .removeClass("fa-angle-down")
                                                .addClass("fa-angle-right");
                                        })
                                        .on('hidden.bs.collapse', function () {
                                            $(this)
                                                .parent()
                                                .find(".fa-angle-right")
                                                .removeClass("fa-angle-right")
                                                .addClass("fa-angle-down");
                                        });
                                });
                            </script>
                            -->
                        </ItemTemplate>

                    </asp:Repeater>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                    <!-- Skyscraper -->
                    <ins class="adsbygoogle"
                        style="display: inline-block; width: 300px; height: 600px"
                        data-ad-client="ca-pub-1911108298391583"
                        data-ad-slot="1182675359"></ins>
                    <script>
                        (adsbygoogle = window.adsbygoogle || []).push({});
                    </script>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                <!-- Comments Form -->
                <div class="well">
                    <h4>Lascia un commento</h4>
                    <div class="form-group">
                        <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="MultiLine" style="resize: none;" runat="server" Placeholder="Inserisci commento..." Rows="5"></asp:TextBox>
                    </div>

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Inserisci" OnClick="btnComment_Click" />
                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                </div>
                <hr>
                <!-- Comment -->
                <asp:Repeater ID="mobileRepeaterComments" runat="server">
                    <ItemTemplate>
                        <div class="media">
                            <a class="pull-left">
                                <img class="media-object img-responsive" width="64px" height="64px" src="<%# Eval("Immagine") %>" alt="">
                            </a>
                            <div class="media-body">
                                <h4 class="media-heading"><%# Eval("Nickname") %>
                                    <small><%# Eval("Data") %></small>
                                </h4>
                                <%# Eval("Testo") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                    </div>
            </div>
        </div>
    </div>



    <script>
        $(document).ready(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#goTop').stop().animate({
                        bottom: '20px'
                    }, 500);
                }
                else {
                    $('#goTop').stop().animate({
                        bottom: '-100px'
                    }, 500);
                }
            });
            $('#goTop').click(function () {
                $('html, body').stop().animate({
                    scrollTop: 0
                }, 500, function () {
                    $('#goTop').stop().animate({
                        bottom: '-100px'
                    }, 500);
                });
            });
        });    </script>
    <a id="goTop" style="color: #424242; font-size: large; padding: 5px; position: fixed; bottom: -100px; right: 10px; z-index: 3; background-image: url('')"><i class="fa fa-2x fa-chevron-circle-up" aria-hidden="true"></i></a>
</asp:Content>

