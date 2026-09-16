<%@ Page
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="LibraryAutomation.Web._Default" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <title>Ana Sayfa</title>

</asp:Content>


<asp:Content
    ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="container-fluid">


        <div class="p-5 mb-4 bg-light rounded-3 shadow-sm">

            <div class="container-fluid py-4">

                <h1 class="display-5 fw-bold">
                    📚 Kütüphane Otomasyonu
                </h1>

                <p class="col-md-8 fs-5 text-muted">
                    Kütüphane kitap, üye, kategori ve ödünç
                    işlemlerini kolayca yönetin.
                </p>

            </div>

        </div>


        <div class="row g-4">


            <div class="col-md-3">

                <div class="card shadow-sm h-100">

                    <div class="card-body">

                        <h5 class="card-title">
                            📚 Kitaplar
                        </h5>

                        <p class="card-text text-muted">
                            Kitap kayıtlarını yönetin.
                        </p>

                        <a
                            href="~/Book/BookList.aspx"
                            class="btn btn-primary">

                            Kitaplara Git

                        </a>

                    </div>

                </div>

            </div>


            <div class="col-md-3">

                <div class="card shadow-sm h-100">

                    <div class="card-body">

                        <h5 class="card-title">
                            🗂️ Kategoriler
                        </h5>

                        <p class="card-text text-muted">
                            Kitap kategorilerini yönetin.
                        </p>

                        <a
                            href="~/Category/CategoryList.aspx"
                            class="btn btn-primary">

                            Kategorilere Git

                        </a>

                    </div>

                </div>

            </div>


            <div class="col-md-3">

                <div class="card shadow-sm h-100">

                    <div class="card-body">

                        <h5 class="card-title">
                            👥 Üyeler
                        </h5>

                        <p class="card-text text-muted">
                            Kütüphane üyelerini yönetin.
                        </p>

                        <a
                            href="~/Member/MemberList.aspx"
                            class="btn btn-primary">

                            Üyelere Git

                        </a>

                    </div>

                </div>

            </div>


            <div class="col-md-3">

                <div class="card shadow-sm h-100">

                    <div class="card-body">

                        <h5 class="card-title">
                            📖 Ödünç İşlemleri
                        </h5>

                        <p class="card-text text-muted">
                            Ödünç verme ve iade işlemlerini yönetin.
                        </p>

                        <a
                            href="~/Loan/LoanList.aspx"
                            class="btn btn-primary">

                            Ödünç İşlemlerine Git

                        </a>

                    </div>

                </div>

            </div>


        </div>

    </div>


</asp:Content>