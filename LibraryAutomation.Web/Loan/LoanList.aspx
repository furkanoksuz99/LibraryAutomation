<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="LoanList.aspx.cs"
    Inherits="LibraryAutomation.Web.Loan.LoanList" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <title>Ödünç İşlemleri</title>

</asp:Content>


<asp:Content
    ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="container-fluid mt-4">


        <!-- BAŞLIK -->

        <div class="d-flex justify-content-between align-items-center mb-4">

            <div>

                <h2 class="mb-1">
                    Ödünç İşlemleri
                </h2>

                <p class="text-muted mb-0">
                    Kitap ödünç verme ve iade işlemlerini yönetin.
                </p>

            </div>


            <button
                type="button"
                class="btn btn-primary"
                data-bs-toggle="modal"
                data-bs-target="#loanModal">

                + Yeni Ödünç Ver

            </button>

        </div>


        <!-- MESAJ -->

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="d-block mb-3">
        </asp:Label>


        <!-- ÖDÜNÇ LİSTESİ -->

        <div class="card shadow-sm">

            <div class="card-header bg-white">

                <h5 class="mb-0">
                    Ödünç Kayıtları
                </h5>

            </div>


            <div class="card-body">

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvLoans"
                        runat="server"
                        AutoGenerateColumns="False"
                        CssClass="table table-bordered table-hover align-middle mb-0">

                        <Columns>

                            <asp:BoundField
                                DataField="Id"
                                HeaderText="ID" />

                            <asp:BoundField
                                DataField="MemberId"
                                HeaderText="Üye ID" />

                            <asp:BoundField
                                DataField="BookId"
                                HeaderText="Kitap ID" />

                            <asp:BoundField
                                DataField="BorrowDate"
                                HeaderText="Ödünç Tarihi"
                                DataFormatString="{0:dd.MM.yyyy HH:mm}" />

                            <asp:BoundField
                                DataField="DueDate"
                                HeaderText="Son Teslim"
                                DataFormatString="{0:dd.MM.yyyy}" />

                            <asp:BoundField
                                DataField="ReturnDate"
                                HeaderText="İade Tarihi"
                                DataFormatString="{0:dd.MM.yyyy HH:mm}" />

                            <asp:BoundField
                                DataField="Status"
                                HeaderText="Durum" />

                            <asp:BoundField
                                DataField="Notes"
                                HeaderText="Not" />


                            <asp:TemplateField
                                HeaderText="İşlemler">

                                <ItemTemplate>

    <asp:Button
        ID="btnReturn"
        runat="server"
        Text="İade Al"
        CssClass="btn btn-sm btn-success me-2"
        CommandArgument='<%# Eval("Id") %>'
        OnClick="btnReturn_Click"
        OnClientClick="return confirm('İadeyi onaylıyor musunuz?');" />

    <asp:Button
        ID="btnEdit"
        runat="server"
        Text="Düzenle"
        CssClass="btn btn-sm btn-primary"
        CommandArgument='<%# Eval("Id") %>'
        OnClick="btnEdit_Click" />

</ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>

    </div>


    <!-- ÖDÜNÇ MODAL -->

    <div
        class="modal fade"
        id="loanModal"
        tabindex="-1"
        aria-hidden="true">

        <div class="modal-dialog modal-lg">

            <div class="modal-content">


                <!-- MODAL HEADER -->

                <div class="modal-header">

                    <h5 class="modal-title">
                        Yeni Ödünç Ver
                    </h5>

                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal">
                    </button>

                </div>


                <!-- MODAL BODY -->

                <div class="modal-body">


                    <asp:HiddenField
                        ID="hdnLoanId"
                        runat="server" />


                    <div class="row g-3">


                        <!-- ÜYE -->

                        <div class="col-md-6">

                            <label class="form-label">
                                Üye
                            </label>

                            <asp:DropDownList
                                ID="ddlMember"
                                runat="server"
                                CssClass="form-select">

                                <asp:ListItem
                                    Text="Üye seçiniz"
                                    Value="">
                                </asp:ListItem>

                            </asp:DropDownList>

                        </div>


                        <!-- KİTAP -->

                        <div class="col-md-6">

                            <label class="form-label">
                                Kitap
                            </label>

                            <asp:DropDownList
                                ID="ddlBook"
                                runat="server"
                                CssClass="form-select">

                                <asp:ListItem
                                    Text="Kitap seçiniz"
                                    Value="">
                                </asp:ListItem>

                            </asp:DropDownList>

                        </div>


                        <!-- ÖDÜNÇ TARİHİ -->

                        <div class="col-md-6">

                            <label class="form-label">
                                Ödünç Tarihi
                            </label>

                            <asp:TextBox
                                ID="txtBorrowDate"
                                runat="server"
                                CssClass="form-control"
                                TextMode="DateTimeLocal">
                            </asp:TextBox>

                        </div>


                        <!-- SON TESLİM TARİHİ -->

                        <div class="col-md-6">

                            <label class="form-label">
                                Son Teslim Tarihi
                            </label>

                            <asp:TextBox
                                ID="txtDueDate"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Date">
                            </asp:TextBox>

                        </div>


                        <!-- NOT -->

                        <div class="col-12">

                            <label class="form-label">
                                Not
                            </label>

                            <asp:TextBox
                                ID="txtNotes"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="3"
                                placeholder="Ödünç işlemiyle ilgili not...">
                            </asp:TextBox>

                        </div>


                    </div>

                </div>


                <!-- MODAL FOOTER -->

                <div class="modal-footer">

                    <button
                        type="button"
                        class="btn btn-secondary"
                        data-bs-dismiss="modal">

                        Vazgeç

                    </button>


                    <asp:Button
                        ID="btnSaveLoan"
                        runat="server"
                        Text="Ödünç Ver"
                        CssClass="btn btn-primary"
                        OnClick="btnSaveLoan_Click" />

                </div>

            </div>

        </div>

    </div>


</asp:Content>