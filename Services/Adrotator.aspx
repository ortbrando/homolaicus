<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adrotator.aspx.cs" Inherits="Adrotator" MasterPageFile="AdminPanel.master" %>

<asp:Content ContentPlaceHolderID="Banner" runat="server">
        <div class="container">
            <h3 class="page-header">Il tuo banner</h3>
          
            <asp:Label ID="lblRotator" runat="server"></asp:Label>
            <asp:SqlDataSource ID="datasource" ConnectionString="<%$ConnectionStrings:LocalDb%>" SelectCommand="SELECT ID, ImageUrl, NavigateUrl, AlternateText,Impressions FROM Ads" runat="server"></asp:SqlDataSource>
            <asp:AdRotator ID="rotator" runat="server" CssClass="img-responsive" DataSourceID="datasource" />

       
            <h3 class="page-header">Statistiche pubblicitarie</h3>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Indirizzo</th>
                        <th>Clicks</th>

                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="statsRepeater" >
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ID") %></td>
                                <td><%#(Eval("NavigateUrl").ToString().Replace("~/Adsclicked.aspx?url=","")) %></td>
                                <td><%#Eval("Hits") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
            <asp:Label ID="lblClicks" runat="server"></asp:Label>
            <h3 class="page-header">Personalizza il tuo banner</h3>

            <div id="FirstInsert" runat="server">
                <asp:Label runat="server" Text="Indirizzo immagine"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbImageUrlF"></asp:TextBox>
                <asp:Label Text="Indirizzo navigazione" runat="server"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbNavigateUrlF"></asp:TextBox>
                <asp:Label Text="Testo" runat="server"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbAlternateTextF"></asp:TextBox>

                <asp:Label Text="Keyword" runat="server"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbKeywordF"></asp:TextBox>

                <asp:Label Text="Frequenza" runat="server"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbImpressionsF"></asp:TextBox>

                <asp:Label Text="Larghezza" runat="server"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbWeightF"></asp:TextBox>

                <asp:Label Text="Altezza" runat="server"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txbHeightF"></asp:TextBox>

                <asp:Button ID="first_insert" CssClass="btn btn-default" Text="Inserisci" runat="server" OnClick="first_insert_Click" />

            </div>

            <div  id="tbl-container">
            <asp:GridView ID="GridView1" CssClass="table" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="true" OnPageIndexChanging="OnPaging" OnRowEditing="EditCustomer"
                OnRowUpdating="UpdateCustomer" OnRowCancelingEdit="CancelEdit" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indirizzo immagine">
                        <ItemTemplate>
                            <a href="<%# Eval("ImageUrl")%>"<asp:Label ID="lblImageUrl" runat="server" Text='<%# Eval("ImageUrl")%>'></asp:Label></a>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Eval("ImageUrl")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtImageUrl" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indirizzo navigazione">
                        <ItemTemplate>
                            <asp:Label ID="lblNavigateUrl" runat="server" Text='<%#(Eval("NavigateUrl").ToString().Replace("~/Adsclicked.aspx?url=","")) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNavigateUrl" runat="server" Text='<%#(Eval("NavigateUrl").ToString().Replace("~/Adsclicked.aspx?url=","")) %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNavigateUrl" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Testo">
                        <ItemTemplate>
                            <asp:Label ID="lblAlternateText" runat="server" Text='<%# Eval("AlternateText")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAlternateText" runat="server" Text='<%# Eval("AlternateText")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAlternateText" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KeyWord">
                        <ItemTemplate>
                            <asp:Label ID="lblKeyword" runat="server" Text='<%# Eval("Keyword")%>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="txtKeyword" runat="server" Text='<%# Eval("Keyword")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtKeyword" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Frequenza">
                        <ItemTemplate>
                            <asp:Label ID="lblImpressions" runat="server" Text='<%# Eval("Impressions")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImpressions" runat="server" Text='<%# Eval("Impressions")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtImpressions" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Larghezza">
                        <ItemTemplate>
                            <asp:Label ID="lblWidth" runat="server" Text='<%# Eval("Width")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWidth" runat="server" Text='<%# Eval("Width")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtWidth" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Altezza">
                        <ItemTemplate>
                            <asp:Label ID="lblHeight"  runat="server" Text='<%# Eval("Height")%>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="txtHeight" runat="server" Text='<%# Eval("Height")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtHeight" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("ID")%>'
                                OnClientClick="return confirm('Sicuro di volere eliminare il banner pubblicitario? Con esso verranno eliminate anche le relative statistiche!')"
                                Text="Delete" OnClick="DeleteCustomer"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAdd" CssClass="btn btn-default" runat="server" Text="Aggiungi" OnClick="AddNewCustomer" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
                <PagerStyle HorizontalAlign = "Center" CssClass ="pagination-ys" />
            </asp:GridView>
            </div>
        </div>
</asp:Content>
