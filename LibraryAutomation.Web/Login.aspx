<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="LibraryAutomation.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Kütüphane Otomasyonu - Giriş</title>

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

        .login-wrapper {
            width: 100%;
            max-width: 430px;
            padding: 20px;
        }

        .login-card {
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

        .login-title {
            text-align: center;
            font-weight: 700;
            color: #212529;
            margin-bottom: 5px;
        }

        .login-subtitle {
            text-align: center;
            color: #6c757d;
            margin-bottom: 30px;
        }

        .form-label {
            font-weight: 600;
        }

        .form-control {
            padding: 12px;
            border-radius: 10px;
        }

        .login-button {
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

        .footer-text {
            text-align: center;
            color: #6c757d;
            margin-top: 25px;
            font-size: 14px;
        }

    </style>

</head>


<body>

<form id="form1" runat="server">

    <div class="login-wrapper">

        <div class="login-card">

            <!-- LOGO -->

            <div class="logo">
                📚
            </div>


            <!-- BAŞLIK -->

            <h2 class="login-title">
                Kütüphane Otomasyonu
            </h2>

            <p class="login-subtitle">
                Hesabınıza giriş yapın
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
                    placeholder="Kullanıcı adınızı giriniz">
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
                    placeholder="Şifrenizi giriniz">
                </asp:TextBox>

            </div>


            <!-- GİRİŞ -->

            <asp:Button
                ID="btnLogin"
                runat="server"
                Text="Giriş Yap"
                CssClass="btn btn-dark login-button"
                OnClick="btnLogin_Click" />


            <!-- MESAJ -->

            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="message text-danger">
            </asp:Label>


            <div class="footer-text">

                Kütüphane Yönetim Sistemi

            </div>

        </div>

    </div>

</form>

</body>
</html>