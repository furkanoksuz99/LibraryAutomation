<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MemberList.aspx.cs"
    Inherits="LibraryAutomation.Web.Member.MemberList" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <title>Üyeler - Kütüphane Otomasyonu</title>

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

        .member-grid {
            width: 100%;
            background-color: white;
            border-radius: 10px;
            overflow: hidden;
        }

        .member-grid th {
            padding: 12px;
            background-color: #343a40;
            color: white;
            text-align: left;
        }

        .member-grid td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        .member-grid tr:hover {
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

            <h2>Üyeler</h2>

            <button
                type="button"
                class="btn btn-success"
                data-bs-toggle="modal"
                data-bs-target="#memberModal">

                + Yeni Üye

            </button>

        </div>


        <asp:GridView
            ID="gvMembers"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="member-grid"
            EmptyDataText="Henüz kayıtlı üye bulunmuyor.">

            <Columns>

                <asp:BoundField
                    DataField="Id"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="MemberNumber"
                    HeaderText="Üye No" />

                <asp:BoundField
                    DataField="FirstName"
                    HeaderText="Ad" />

                <asp:BoundField
                    DataField="LastName"
                    HeaderText="Soyad" />

                <asp:BoundField
                    DataField="Email"
                    HeaderText="E-posta" />

                <asp:BoundField
                    DataField="Phone"
                    HeaderText="Telefon" />

                <asp:BoundField
                    DataField="Address"
                    HeaderText="Adres" />

                <asp:BoundField
                    DataField="BirthDate"
                    HeaderText="Doğum Tarihi"
                    DataFormatString="{0:dd.MM.yyyy}" />

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
                            OnClientClick="return confirm('Bu üyeyi silmek istediğinize emin misiniz?');" />

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


        <!-- ÜYE MODALI -->

        <div
            class="modal fade"
            id="memberModal"
            tabindex="-1"
            aria-hidden="true">

            <div class="modal-dialog modal-lg">

                <div class="modal-content">


                    <div class="modal-header">

                        <h5 class="modal-title">
                            Üye
                        </h5>

                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal">
                        </button>

                    </div>


                    <div class="modal-body">

                        <asp:HiddenField
                            ID="hdnMemberId"
                            runat="server" />


                        <div class="row">


                            <div class="col-md-6 mb-3">

                                <label class="form-label">
                                    Ad
                                </label>

                                <asp:TextBox
                                    ID="txtFirstName"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="Örn: Ahmet">
                                </asp:TextBox>

                            </div>


                            <div class="col-md-6 mb-3">

                                <label class="form-label">
                                    Soyad
                                </label>

                                <asp:TextBox
                                    ID="txtLastName"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="Örn: Yılmaz">
                                </asp:TextBox>

                            </div>


                            <div class="col-md-6 mb-3">

                                <label class="form-label">
                                    E-posta
                                </label>

                                <asp:TextBox
                                    ID="txtEmail"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="Email"
                                    placeholder="ornek@mail.com">
                                </asp:TextBox>

                            </div>


                            <div class="col-md-6 mb-3">

                                <label class="form-label">
                                    Telefon
                                </label>

                                <asp:TextBox
                                    ID="txtPhone"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="0555 555 55 55">
                                </asp:TextBox>

                            </div>


                            <div class="col-md-6 mb-3">

                                <label class="form-label">
                                    Doğum Tarihi
                                </label>

                                <asp:TextBox
                                    ID="txtBirthDate"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="Date">
                                </asp:TextBox>

                            </div>


                            <div class="col-12 mb-3">

                                <label class="form-label">
                                    Adres
                                </label>

                                <asp:TextBox
                                    ID="txtAddress"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="MultiLine"
                                    Rows="3"
                                    placeholder="Üye adresi...">
                                </asp:TextBox>

                            </div>


                            <div class="col-12">

                                <div class="form-check">

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
                            ID="btnSaveMember"
                            runat="server"
                            Text="Üyeyi Kaydet"
                            CssClass="btn btn-success"
                            OnClick="btnSaveMember_Click" />

                    </div>


                </div>

            </div>

        </div>

    </div>


</asp:Content>