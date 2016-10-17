<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RichercheBibliografiche.aspx.cs" Inherits="RichercheBibliografiche" MasterPageFile="~/Homepage.master" %>

<asp:Content ContentPlaceHolderID="RicercheBibliografiche" runat="server">
    <div class="section">
      <div class="container-fluid" style="padding: 20px;">
          <h1>Editori Nazionali</h1>
          <hr />
        <div class="row">
          <div class="col-md-4">
            <h1>Cerca con IBS</h1>

              <div class="form-group">
                <label class="control-label" for="titoloIBS">Titolo</label>
                  <asp:TextBox ID="titoloIBS" CssClass="form-control" Placeholder="Titolo" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="autoreIBS">Autore</label>
                  <asp:TextBox ID="autoreIBS" CssClass="form-control" Placeholder="Autore" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="editoreIBS">Editore</label>
                  <asp:TextBox ID="editoreIBS" CssClass="form-control" Placeholder="Editore" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="argomentoIBS">Argomento</label>
                  <asp:TextBox ID="argomentoIBS" CssClass="form-control" Placeholder="Argomento" runat="server"></asp:TextBox>
              </div>
              <asp:Button ID="cercaIBS" runat="server" CssClass="btn btn-default" OnClick="cercaIBS_Click" Text="Cerca con IBS" />
          </div>
          <div class="col-md-4">
            <h1>UniLibro</h1>
              <div class="form-group">
                <label class="control-label" for="titoloUnilibro">Titolo</label>
                  <asp:TextBox ID="titoloUnilibro" CssClass="form-control" Placeholder="Titolo" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="autoreUnilibro">Autore</label>
                  <asp:TextBox ID="autoreUnilibro" CssClass="form-control" Placeholder="Autore" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="editoreUnilibro">Editore</label>
                  <asp:TextBox ID="editoreUnilibro" CssClass="form-control" Placeholder="Editore" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="collanaISBN">Collana</label>
                  <asp:TextBox ID="collanaISBN" CssClass="form-control" Placeholder="Argomento" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                <label class="control-label" for="isbnUnilibro">ISBN</label>
                  <asp:TextBox ID="isbnUnilibro" CssClass="form-control" Placeholder="Argomento" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                  <label class="control-label" for="ddlPrezzo">Prezzo</label>
                  <asp:DropDownList ID="ddlPrezzo" CssClass="form-control" runat="server">
                      <asp:ListItem Text="Qualsiasi" Value=""></asp:ListItem>
                      <asp:ListItem Text="Superiore a € 100,00" Value=""></asp:ListItem>
                      <asp:ListItem Text="Tra € 75,00 e € 100,00" Value=""></asp:ListItem>
                      <asp:ListItem Text="Tra € 50,00 e € 75,00" Value=""></asp:ListItem>
                      <asp:ListItem Text="Tra € 25,00 e € 50,00" Value=""></asp:ListItem>
                      <asp:ListItem Text="Tra € 10,00 e € 25,00" Value=""></asp:ListItem>
                      <asp:ListItem Text="Inferiore a € 10,00" Value=""></asp:ListItem>
                  </asp:DropDownList>
              </div>
              <div class="form-group">
                  <label class="control-label" for="ddlTitoliNonAcquistabili">Anche titoli non acquistabili</label>
                  <asp:DropDownList ID="ddlTitoliNonAcquistabili" CssClass="form-control" runat="server">
                      <asp:ListItem Text="No" Value=""></asp:ListItem>
                      <asp:ListItem Text="Si" Value=""></asp:ListItem>
                  </asp:DropDownList>
              </div>
              <div class="form-group">
                  <label class="control-label" for="ddlOrdinaPer">Ordina per</label>
                  <asp:DropDownList ID="ddlOrdinaPer" CssClass="form-control" runat="server">
                      <asp:ListItem Text="Titolo" Value=""></asp:ListItem>
                      <asp:ListItem Text="Autore" Value=""></asp:ListItem>
                      <asp:ListItem Text="Editore" Value=""></asp:ListItem>
                      <asp:ListItem Text="Anno" Value=""></asp:ListItem>
                      <asp:ListItem Text="Classificazione" Value=""></asp:ListItem>
                      <asp:ListItem Text="Prezzo" Value=""></asp:ListItem>
                  </asp:DropDownList>
              </div>
              <div class="form-group">
                  <label class="control-label" for="ddlVisualizzaMax">Visualizza Max</label>
                  <asp:DropDownList ID="ddlVisualizzaMax" CssClass="form-control" runat="server">
                      <asp:ListItem Text="10" Value=""></asp:ListItem>
                      <asp:ListItem Text="20" Value=""></asp:ListItem>
                      <asp:ListItem Text="100" Value=""></asp:ListItem>
                      <asp:ListItem Text="200" Value=""></asp:ListItem>
                  </asp:DropDownList>
              </div>
              <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="cercaIBS_Click" Text="Cerca con IBS" />

          </div>
          <div class="col-md-4">
            <h1>LibreriaUniversitaria</h1>
              <div id="3dfa1e11a14b4927570f25ed903ca1ea" class="id_form"></div>
<script src="http://www.libreriauniversitaria.it/javascripts/iframe.js" type="text/javascript"></script>
<script type="text/javascript">draw_search_libreriauniversitaria("357321", "6", "3dfa1e11a14b4927570f25ed903ca1ea", "www.libreriauniversitaria.it");</script>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1>Heading</h1>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <ul class="list-group">
              <li class="list-group-item"><h5><a href="http://opac.sbn.it/opacsbn/opac/iccu/free.jsp">Opac Nazionale</a></h5></li>
              <li class="list-group-item"><h5><a href="http://opac.provincia.ra.it/SebinaOpac/Opac">Rete Bibliotecaria in Romagna</a></h5></li>
              <li class="list-group-item"><h5><a href="http://www.treccani.it/enciclopedia/ricerca/">Enciclopedia Treccani</a></h5></li>
              <li class="list-group-item"><h5><a href="http://www.teche.rai.it/biblioteca.html">RaiTeche</a></h5></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1 class="text-center">Subscribe</h1>
          </div>
        </div>
        <div class="row">
          <div class="col-md-offset-3 col-md-6">
              <div class="form-group">
                <div class="input-group">
                  <input type="text" class="form-control" placeholder="Enter your email">
                  <span class="input-group-btn">
                    <a class="btn btn-success" type="submit">Go</a>
                  </span>
                </div>
              </div>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1 class="text-center">Subscribe</h1>
          </div>
        </div>
        <div class="row">
          <div class="col-md-offset-3 col-md-6">
              <div class="form-group">
                <div class="input-group">
                  <input type="text" class="form-control" placeholder="Enter your email">
                  <span class="input-group-btn">
                    <a class="btn btn-success" type="submit">Go</a>
                  </span>
                </div>
              </div>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1 class="text-center">Subscribe</h1>
          </div>
        </div>
        <div class="row">
          <div class="col-md-offset-3 col-md-6">
              <div class="form-group">
                <div class="input-group">
                  <input type="text" class="form-control" placeholder="Enter your email">
                  <span class="input-group-btn">
                    <a class="btn btn-success" type="submit">Go</a>
                  </span>
                </div>
              </div>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
