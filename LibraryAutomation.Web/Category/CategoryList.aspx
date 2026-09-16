<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="CategoryList.aspx.cs"
    Inherits="LibraryAutomation.Web.Category.CategoryList" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <title>Kategoriler - Kütüphane Otomasyonu</title>

    <style>

        body {
            font-family: Arial, sans-serif;
            background-color: #f5f6f8;
            margin: 0;
        }

        .page-container {
            max-width: 1200px;
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

        .category-grid {
            width: 100%;
            background-color: white;
            border-radius: 10px;
            overflow: hidden;
        }

        .category-grid th {
            padding: 12px;
            background-color: #343a40;
            color: white;
            text-align: left;
        }

        .category-grid td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        .category-grid tr:hover {
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

        <div class="page-header">

            <h2>Kategoriler</h2>

            <button
                type="button"
                class="btn btn-success"
                data-bs-toggle="modal"
                data-bs-target="#categoryModal">

                + Yeni Kategori

            </button>

        </div>


        <asp:GridView
            ID="gvCategories"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="category-grid"
            EmptyDataText="Henüz kayıtlı kategori bulunmuyor.">

            <Columns>

                <asp:BoundField
                    DataField="Id"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="Name"
                    HeaderText="Kategori Adı" />

                <asp:BoundField
                    DataField="Description"
                    HeaderText="Açıklama" />

                <asp:CheckBoxField
                    DataField="IsActive"
                    HeaderText="Aktif" />

                <asp:BoundField
                    DataField="CreatedDate"
                    HeaderText="Oluşturulma Tarihi"
                    DataFormatString="{0:dd.MM.yyyy HH:mm}" />

                <asp:TemplateField
                    HeaderText="İşlemler">

                    <ItemTemplate>

                        <asp:Button
                            ID="btnEdit"
                            runat="server"
                            Text="Düzenle"
                            CssClass="btn btn-sm btn-primary me-2"
                            CommandArgument='<%# Eval("Id") %>'
                            OnClick="btnEdit_Click" />

                        <asp:Button
                            ID="btnDelete"
                            runat="server"
                            Text="Sil"
                            CssClass="btn btn-sm btn-danger"
                            CommandArgument='<%# Eval("Id") %>'
                            OnClick="btnDelete_Click"
                            OnClientClick="return confirm('Bu kategoriyi silmek istediğinize emin misiniz?');" />

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>


        <br />


        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="empty-message">
        </asp:Label>


        <!-- KATEGORİ MODAL -->

        <div
            class="modal fade"
            id="categoryModal"
            tabindex="-1"
            aria-hidden="true">

            <div class="modal-dialog">

                <div class="modal-content">


                    <div class="modal-header">

                        <h5 class="modal-title">
                            Kategori
                        </h5>

                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal">
                        </button>

                    </div>


                    <div class="modal-body">

                        <asp:HiddenField
                            ID="hdnCategoryId"
                            runat="server" />


                        <div class="mb-3">

                            <label class="form-label">
                                Kategori Adı
                            </label>

                            <asp:TextBox
                                ID="txtCategoryName"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Örn: Roman">
                            </asp:TextBox>

                        </div>


                        <div class="mb-3">

                            <label class="form-label">
                                Açıklama
                            </label>

                            <asp:TextBox
                                ID="txtDescription"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="4"
                                placeholder="Kategori hakkında kısa açıklama...">
                            </asp:TextBox>

                        </div>


                        <div class="form-check mb-3">

                            <asp:CheckBox
                                ID="chkIsActive"
                                runat="server"
                                CssClass="form-check-input"
                                Checked="true" />

                            <label class="form-check-label">
                                Aktif
                            </label>

                        </div>

                    </div>


                    <div class="modal-footer">

                        <button
                            type="button"
                            class="btn btn-secondary"
                            data-bs-dismiss="modal">

                            İptal

                        </button>


                        <asp:Button
                            ID="btnSaveCategory"
                            runat="server"
                            Text="Kategoriyi Kaydet"
                            CssClass="btn btn-success"
                            OnClick="btnSaveCategory_Click" />

                    </div>


                </div>

            </div>

        </div>

    </div>

</asp:Content>