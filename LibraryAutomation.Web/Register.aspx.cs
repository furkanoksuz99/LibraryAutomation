using LibraryAutomation.Business.Managers;
using System;

namespace LibraryAutomation.Web
{
    public partial class Register : System.Web.UI.Page
    {
        private readonly UserManager _userManager;

    public Register()
        {
            _userManager = new UserManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string passwordAgain = txtPasswordAgain.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(passwordAgain) ||
                string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(email))
            {
                lblMessage.Text = "Tüm alanlar doldurulmalıdır.";
                return;
            }

            if (password != passwordAgain)
            {
                lblMessage.Text = "Şifreler eşleşmiyor.";
                return;
            }

            var user = new Entities.User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Email = email,
                Role = "User",
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            _userManager.AddUser(user);

            Session["UserId"] = user.Id;
            Session["Username"] = user.Username;
            Session["FullName"] = user.FullName;
            Session["Role"] = user.Role;

            Response.Redirect("Loan/LoanList.aspx");
        }
    }

}
