using LibraryAutomation.Business.Managers;
using LibraryAutomation.Entities;
using System;

namespace LibraryAutomation.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UserManager _userManager;

        public Login()
        {
            _userManager = new UserManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Kullanıcı adı ve şifre boş bırakılamaz.";
                return;
            }

            User user = _userManager.Login(username, password);

            if (user == null)
            {
                lblMessage.Text = "Kullanıcı adı veya şifre hatalı.";
                return;
            }

            Session["UserId"] = user.Id;
            Session["Username"] = user.Username;
            Session["FullName"] = user.FullName;
            Session["Role"] = user.Role;

            Response.Redirect("Loan/LoanList.aspx");
        }
    }
}