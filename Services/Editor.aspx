<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editor.aspx.cs" Inherits="Services_Editor" MasterPageFile="~/Services/AdminPanel.master" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ContentPlaceHolderID="Editor" runat="server">
    <div class="section">
        <div class="row" >
            <div class="col-md-12">
                <h1>Editor</h1>
                <hr />
                <CKEditor:CKEditorControl ID="CKEditor1" BasePath="~/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                <div class="btn-group btn-group-lg" style="padding-top: 20px;">
                    <asp:DropDownList ID="ddl1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="populateSubcatParam" runat="server"></asp:DropDownList>
                </div>
                <div class="btn-group btn-group-lg" style="padding-top: 20px;" >
                    <asp:DropDownList ID="ddl2" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="populateArgumentParam" runat="server"></asp:DropDownList>
                </div>
                <div class="btn-group btn-group-lg" style="padding-top: 20px;">
                    <asp:DropDownList ID="ddl3" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="populateSectionParam" runat="server"></asp:DropDownList>
                </div>
                <div class="btn-group btn-group-lg" style="padding-top: 20px;">
                    <asp:DropDownList ID="ddl4" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label" for="exampleInputEmail1">Nome sezione</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tb1" placeholder="Nuova sezione"></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label" runat="server" ID="lbl" ForeColor="Gray">Posizione all'interno dell'argomento</asp:Label>
                        <asp:TextBox runat="server" ID="tb2" CssClass="form-control" placeholder="Posizione" Enabled="false"></asp:TextBox>
                        <div class="checkbox-inline" style="padding-top: 10px;">
                            <asp:CheckBox ID="cb" runat="server" AutoPostBack="true" Checked="true" Text="  Inserisci in coda" OnCheckedChanged="cb_CheckedChanged" ></asp:CheckBox>
                        </div>
                    </div>
                    <asp:Button type="submit" Text="Inserisci" OnClick="InsertSection" CssClass="btn btn-default" runat="server"></asp:Button>
            </div>
        </div>
    </div>
    <!--
    <h1 class="page-header">Editor</h1>
    <div>
        <div>
<asp:DropDownList ID="categories" CssClass="form-control" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="subcategories" CssClass="form-control" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="argument" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    
        <br />
    
    <asp:Label ID="stringa" Text="" runat="server"></asp:Label>
    </div>
    -->
</asp:Content>
