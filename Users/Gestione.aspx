﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gestione.aspx.cs" Inherits="Users_Gestione" MasterPageFile="~/Users/UserHomepage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="Gestione">
    <div class="container">
        <div class="section">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="page-header" style="color: blue;">Modifica
                        <br>
                    </h1>
                </div>
            </div>
    </div>
    <div class="section">
            <div class="row">
                <div class="col-md-6">
                    <h1>Sottocategorie</h1>
                    <div class="btn-group btn-group-lg">
                            <asp:DropDownList id="ddl1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="populateSubcatParam1"  runat="server"></asp:DropDownList>
                    </div>
                    <div class="btn-group btn-group-lg">
                            <asp:DropDownList id="ddl2" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:DropDownList>
                    </div>
                        <div class="form-group">
                            <label class="control-label" for="exampleInputEmail1">Nome</label>
                            <asp:TextBox runat="server" ID="tb1" CssClass="form-control" Placeholder="Nuova sottocategoria"></asp:TextBox>
                        </div>
                        <asp:Button type="submit" Text="Modifica" OnClick="editSubcat" CssClass="btn btn-default" runat="server"></asp:Button>
                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                </div>
                <div class="col-md-6">
                    <h1>Argomenti
                           
                        <br>
                    </h1>
                    <div class="btn-group btn-group-lg">
                        <asp:DropDownList id="ddl3" CssClass="form-control"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="populateSubcatParam"></asp:DropDownList>
                    </div>
                    <div class="btn-group btn-group-lg">
                        <asp:DropDownList id="ddl4" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="populateArgumentParam"  runat="server"></asp:DropDownList>
                    </div>
                    <div class="btn-group btn-group-lg">
                        <asp:DropDownList id="ddl5" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:DropDownList>
                    </div>
                    
                        <div class="form-group">
                            <label class="control-label" for="exampleInputEmail1">Nome</label>
                            <asp:TextBox runat="server" ID="tb2" CssClass="form-control" Placeholder="Nuovo argomento"></asp:TextBox>
                        </div>
                        <asp:Button type="submit" Text="Modifica" OnClick="editArgument" CssClass="btn btn-default" runat="server"></asp:Button>
                        <asp:Label ID="lbl2" runat="server"></asp:Label>
                    
                </div>
            </div>
    </div>

    <div class="section">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="page-header" style="padding-top: 100px; color: blue;">Aggiungi
                           
                        <br>
                    </h1>
                </div>
            </div>
    </div>
    <div class="section">
            <div class="row">
                <div class="col-md-6">
                    <h1>Sottocategorie</h1>
                    <div class="btn-group btn-group-lg">
                        <asp:DropDownList id="ddl6" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                    
                        <div class="form-group">
                            <label class="control-label" for="exampleInputEmail1">Nome</label>
                            <asp:TextBox runat="server" ID="tb3" CssClass="form-control" Placeholder="Nuova sottocategoria"></asp:TextBox>
                             <!-- Upload File -->
                            <div style="visibility: hidden;"><label class="control-label">Immagine</label>
                            <asp:FileUpload id="FileUploadControl" CssClass="btn btn-default btn-file" runat="server" />
                            <asp:Button runat="server" id="UploadButton" CssClass="btn btn-default" text="Upload" OnClick="UploadButton_Click"/>
                            <br /><br />
                            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                                </div>
                        </div>
                        <asp:Button type="submit" Text="Aggiungi" OnClick="addSubcat" CssClass="btn btn-default" runat="server"></asp:Button>
                        <asp:Label ID="lbl3" runat="server"></asp:Label>
                    
                </div>
                <div class="col-md-6">
                    <h1>Argomenti
                           
                        <br>
                    </h1>
                    <div class="btn-group btn-group-lg">
                        <asp:DropDownList id="ddl7" CssClass="form-control" OnSelectedIndexChanged="populateSubcatParam2" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                    <div class="btn-group btn-group-lg">
                        <asp:DropDownList id="ddl8" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                    
                        <div class="form-group">
                            <label class="control-label" for="exampleInputEmail1">Nome</label>
                            <asp:TextBox runat="server" ID="tb4" CssClass="form-control" Placeholder="Nuovo argomento"></asp:TextBox>
                        </div>
                        <asp:Button type="submit" Text="Aggiungi" OnClick="addArgument" CssClass="btn btn-default" runat="server"></asp:Button>
                        <asp:Label ID="lbl4" runat="server"></asp:Label>
                    
                </div>
            </div>
    </div>
    <div class="section">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                </div>
            </div>
    </div>
    </div>
    

</asp:Content>

