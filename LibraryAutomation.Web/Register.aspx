<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="LibraryAutomation.Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Kayıt Ol - Kütüphane Otomasyonu</title>

    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
        rel="stylesheet" />

    <style>

        body {
            min-height: 100vh;
            margin: 0;
            background: linear-gradient(135deg, #212529, #495057);
            display: flex;
            align-items: center;
            justify-content: center;
            font-family: Arial, sans-serif;
        }

        .register-wrapper {
            width: 100%;
            max-width: 520px;
            padding: 20px;
        }

        .register-card {
            background: #ffffff;
            border-radius: 18px;
            padding: 40px;
            box-shadow: 0 15px 40px rgba(0, 0, 0, 0.25);
        }

        .logo {
            width: 70px;
            height: 70px;
            background: #212529;
            color: white;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 32px;
            margin: 0 auto 20px auto;
        }

        .register-title {
            text-align: center;
            font-weight: 700;
            color: #212529;
            margin-bottom: 5px;
        }

        .register-subtitle {
            text-align: center;
            color: #6c757d;
            margin-bottom: 30px;
        }

        .form-label {
            font-weight: 600;
        }

        .form-control {
            padding: 11px;
            border-radius: 10px;
        }

        .register-button {
            width: 100%;
            padding: 12px;
            border-radius: 10px;
            font-weight: 600;
            margin-top: 10px;
        }

        .message {
            display: block;
            text-align: center;
            margin-top: 20px;
            font-weight: 500;
        }

        .login-link {
            display: block;
            text-align: center;
            margin-top: 20px;
            text-decoration: none;
            font-weight: 600;
        }

        .footer-text {
            text-align: center;
            color: #6c757d;
            margin-top: 20px;
            font-size: 14px;
        }

    </style>

</head>


<body>

<form id="form1" runat="server">

    <div class="register-wrapper">

        <div class="register-card">

            <!-- LOGO -->

            <div class="logo">
                📚
            </div>


            <!-- BAŞLIK -->

            <h2 class="register-title">
                Hesap Oluştur
            </h2>

            <p class="register-subtitle">
                Kütüphane otomasyonuna kayıt olun
            </p>


            <!-- KULLANICI ADI -->

            <div class="mb-3">

                <asp:Label
                    ID="lblUsername"
                    runat="server"
                    Text="Kullanıcı Adı"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox
                    ID="txtUsername"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Kullanıcı adınızı belirleyin">
                </asp:TextBox>

            </div>


            <!-- ŞİFRE -->

            <div class="mb-3">

                <asp:Label
                    ID="lblPassword"
                    runat="server"
                    Text="Şifre"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox
                    ID="txtPassword"
                    runat="server"
                    TextMode="Password"
                    CssClass="form-control"
                    placeholder="Şifrenizi belirleyin">
                </asp:TextBox>

            </div>


            <!-- ŞİFRE TEKRAR -->

            <div class="mb-3">

                <asp:Label
                    ID="lblPasswordAgain"
                    runat="server"
                    Text="Şifre Tekrar"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox
                    ID="txtPasswordAgain"
                    runat="server"
                    TextMode="Password"
                    CssClass="form-control"
                    placeholder="Şifrenizi tekrar giriniz">
                </asp:TextBox>

            </div>


            <!-- AD SOYAD -->

            <div class="mb-3">

                <asp:Label
                    ID="lblFullName"
                    runat="server"
                    Text="Ad Soyad"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox
                    ID="txtFullName"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Adınızı ve soyadınızı giriniz">
                </asp:TextBox>

            </div>


            <!-- E-POSTA -->

            <div class="mb-3">

                <asp:Label
                    ID="lblEmail"
                    runat="server"
                    Text="E-posta"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox
                    ID="txtEmail"
                    runat="server"
                    TextMode="Email"
                    CssClass="form-control"
                    placeholder="ornek@mail.com">
                </asp:TextBox>

            </div>


            <!-- KAYIT OL -->

            <asp:Button
                ID="btnRegister"
                runat="server"
                Text="Kayıt Ol"
                CssClass="btn btn-dark register-button"
                OnClick="btnRegister_Click" />


            <!-- MESAJ -->

            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="message text-danger">
            </asp:Label>


            <!-- GİRİŞ LİNKİ -->

            <asp:HyperLink
                ID="lnkLogin"
                runat="server"
                NavigateUrl="Login.aspx"
                Text="Zaten hesabım var, giriş yap"
                CssClass="login-link text-primary">
            </asp:HyperLink>


            <div class="footer-text">

                Kütüphane Yönetim Sistemi

            </div>

        </div>

    </div>

</form>

</body>
</html>