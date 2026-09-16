<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="BookList.aspx.cs"
    Inherits="LibraryAutomation.Web.Book.BookList" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <title>Kitaplar - Kütüphane Otomasyonu</title>

    <style>

        body {
            font-family: Arial, sans-serif;
            background-color: #f5f6f8;
            margin: 0;
        }

        .page-container {
            max-width: 1400px;
            margin: auto;
        }

        .page-header {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            margin-bottom: 20px;

            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .page-header h2 {
            margin: 0;
        }

        .book-grid {
            width: 100%;
            background-color: white;
            border-radius: 10px;
            overflow: hidden;
        }

        .book-grid th {
            padding: 12px;
            background-color: #343a40;
            color: white;
            text-align: left;
        }

        .book-grid td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        .book-grid tr:hover {
            background-color: #f5f5f5;
        }

        .empty-message {
            display: block;
            margin-top: 20px;
            color: #777;
        }

    </style>

</asp:Content>


<asp:Content
    ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="page-container">


        <!-- SAYFA BAŞLIĞI -->

        <div class="page-header">

            <h2>Kitaplar</h2>


            <button
                type="button"
                class="btn btn-success"
                data-bs-toggle="modal"
                data-bs-target="#bookModal">

                + Yeni Kitap

            </button>

        </div>


        <!-- KİTAP LİSTESİ -->

        <asp:GridView
            ID="gvBooks"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="book-grid"
            EmptyDataText="Henüz kayıtlı kitap bulunmuyor.">

            <Columns>

                <asp:BoundField
                    DataField="Id"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="Name"
                    HeaderText="Kitap Adı" />

                <asp:BoundField
                    DataField="Author"
                    HeaderText="Yazar" />

                <asp:BoundField
                    DataField="ISBN"
                    HeaderText="ISBN" />

                <asp:BoundField
                    DataField="Publisher"
                    HeaderText="Yayınevi" />

                <asp:BoundField
                    DataField="PublishYear"
                    HeaderText="Yayın Yılı" />

                <asp:BoundField
                    DataField="PageCount"
                    HeaderText="Sayfa" />

                <asp:BoundField
                    DataField="Stock"
                    HeaderText="Stok" />

                <asp:BoundField
                    DataField="CategoryId"
                    HeaderText="Kategori ID" />

                <asp:CheckBoxField
                    DataField="IsActive"
                    HeaderText="Aktif" />

                <asp:TemplateField
                    HeaderText="İşlemler">

                    <ItemTemplate>

                        <asp:Button
                            ID="btnEdit"
                            runat="server"
                            Text="Düzenle"
                            CssClass="btn btn-sm btn-primary me-2"
                            CommandArgument='<%# Eval("Id") %>' />

                        <asp:Button
                            ID="btnDelete"
                            runat="server"
                            Text="Sil"
                            CssClass="btn btn-sm btn-danger"
                            CommandArgument='<%# Eval("Id") %>'
                            OnClick="btnDelete_Click"
                            OnClientClick="return confirm('Bu kitabı silmek istediğinize emin misiniz?');" />

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>


        <!-- MESAJ -->

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="empty-message">
        </asp:Label>

    </div>


    <!-- YENİ KİTAP MODAL -->

    <div
        class="modal fade"
        id="bookModal"
        tabindex="-1"
        aria-hidden="true">

        <div class="modal-dialog modal-lg">

            <div class="modal-content">


                <!-- MODAL BAŞLIK -->

                <div class="modal-header">

                    <h5 class="modal-title">
                        Yeni Kitap Ekle
                    </h5>

                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal">
                    </button>

                </div>


                <!-- MODAL İÇERİK -->

                <div class="modal-body">

                    <div class="row">


                        <!-- KİTAP ADI -->

                        <div class="col-md-6 mb-3">

                            <label class="form-label">
                                Kitap Adı
                            </label>

                            <asp:TextBox
                                ID="txtBookName"
                                runat="server"
                                CssClass="form-control">
                            </asp:TextBox>

                        </div>


                        <!-- YAZAR -->

                        <div class="col-md-6 mb-3">

                            <label class="form-label">
                                Yazar
                            </label>

                            <asp:TextBox
                                ID="txtAuthor"
                                runat="server"
                                CssClass="form-control">
                            </asp:TextBox>

                        </div>


                        <!-- ISBN -->

                        <div class="col-md-6 mb-3">

                            <label class="form-label">
                                ISBN
                            </label>

                            <asp:TextBox
                                ID="txtISBN"
                                runat="server"
                                CssClass="form-control">
                            </asp:TextBox>

                        </div>


                        <!-- YAYINEVİ -->

                        <div class="col-md-6 mb-3">

                            <label class="form-label">
                                Yayınevi
                            </label>

                            <asp:TextBox
                                ID="txtPublisher"
                                runat="server"
                                CssClass="form-control">
                            </asp:TextBox>

                        </div>


                        <!-- YAYIN YILI -->

                        <div class="col-md-4 mb-3">

                            <label class="form-label">
                                Yayın Yılı
                            </label>

                            <asp:TextBox
                                ID="txtPublishYear"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number">
                            </asp:TextBox>

                        </div>


                        <!-- SAYFA SAYISI -->

                        <div class="col-md-4 mb-3">

                            <label class="form-label">
                                Sayfa Sayısı
                            </label>

                            <asp:TextBox
                                ID="txtPageCount"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number">
                            </asp:TextBox>

                        </div>


                        <!-- STOK -->

                        <div class="col-md-4 mb-3">

                            <label class="form-label">
                                Stok
                            </label>

                            <asp:TextBox
                                ID="txtStock"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number">
                            </asp:TextBox>

                        </div>


                        <!-- KATEGORİ -->

                        <div class="col-md-12 mb-3">

                            <label class="form-label">
                                Kategori
                            </label>

                            <asp:DropDownList
                                ID="ddlCategory"
                                runat="server"
                                CssClass="form-select">

                                <asp:ListItem
                                    Text="Kategori seçiniz"
                                    Value="">
                                </asp:ListItem>

                            </asp:DropDownList>

                        </div>

                    </div>

                </div>


                <!-- MODAL FOOTER -->

                <div class="modal-footer">

                    <button
                        type="button"
                        class="btn btn-secondary"
                        data-bs-dismiss="modal">

                        İptal

                    </button>


                    <asp:Button
                        ID="btnSaveBook"
                        runat="server"
                        Text="Kitabı Kaydet"
                        CssClass="btn btn-success"
                        OnClick="btnSaveBook_Click" />

                </div>

            </div>

        </div>

    </div>


</asp:Content>