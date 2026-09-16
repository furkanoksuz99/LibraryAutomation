using LibraryAutomation.Business.Managers;
using LibraryAutomation.Entities;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryAutomation.Web.Loan
{
    public partial class LoanList : System.Web.UI.Page
    {
        private readonly LoanManager _loanManager;
        private readonly MemberManager _memberManager;
        private readonly BookManager _bookManager;

        public LoanList()
        {
            _loanManager = new LoanManager();
            _memberManager = new MemberManager();
            _bookManager = new BookManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect(
                    "~/Login.aspx?ReturnUrl=" +
                    Server.UrlEncode(Request.RawUrl)
                );

                return;
            }

            if (!IsPostBack)
            {
                List();
                LoadMembers();
                LoadBooks();

                txtBorrowDate.Text =
                    DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

                txtDueDate.Text =
                    DateTime.Now.AddDays(14).ToString("yyyy-MM-dd");
            }
        }

        private void List()
        {
            var loans = _loanManager.GetAllLoans();

            gvLoans.DataSource = loans;
            gvLoans.DataBind();
        }

        private void LoadMembers()
        {
            var members = _memberManager
                .GetAllMembers()
                .Where(x => x.IsActive)
                .ToList();

            ddlMember.DataSource = members;
            ddlMember.DataTextField = "FirstName";
            ddlMember.DataValueField = "Id";
            ddlMember.DataBind();

            ddlMember.Items.Insert(
                0,
                new ListItem("Üye seçiniz", "")
            );
        }

   
        private void LoadBooks()
        {
            var books = _bookManager
                .GetAllBooks()
                .Where(x => x.IsActive && x.Stock > 0)
                .ToList();

            ddlBook.DataSource = books;
            ddlBook.DataTextField = "Name";
            ddlBook.DataValueField = "Id";
            ddlBook.DataBind();

            ddlBook.Items.Insert(
                0,
                new ListItem("Kitap seçiniz", "")
            );
        }

        protected void btnSaveLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlMember.SelectedValue))
                {
                    lblMessage.Text = "Lütfen üye seçiniz.";
                    return;
                }

        
                if (string.IsNullOrEmpty(ddlBook.SelectedValue))
                {
                    lblMessage.Text = "Lütfen kitap seçiniz.";
                    return;
                }

           
                if (Session["UserId"] == null)
                {
                    Response.Redirect(
                        "~/Login.aspx?ReturnUrl=" +
                        Server.UrlEncode(Request.RawUrl)
                    );

                    return;
                }

                int loanId;

                bool isUpdate = int.TryParse(
                    hdnLoanId.Value,
                    out loanId
                );

              
                DateTime borrowDate;
                DateTime dueDate;

                if (!DateTime.TryParse(
                    txtBorrowDate.Text,
                    out borrowDate))
                {
                    lblMessage.Text =
                        "Geçerli bir ödünç alma tarihi giriniz.";

                    return;
                }

                if (!DateTime.TryParse(
                    txtDueDate.Text,
                    out dueDate))
                {
                    lblMessage.Text =
                        "Geçerli bir teslim tarihi giriniz.";

                    return;
                }

                if (dueDate < borrowDate)
                {
                    lblMessage.Text =
                        "Teslim tarihi, ödünç alma tarihinden önce olamaz.";

                    return;
                }

                
                var loan = new Entities.Loan
                {
                    MemberId = Convert.ToInt32(
                        ddlMember.SelectedValue
                    ),

                    BookId = Convert.ToInt32(
                        ddlBook.SelectedValue
                    ),

                    BorrowDate = borrowDate,

                    DueDate = dueDate,

                    Notes = txtNotes.Text.Trim()
                };

            
                if (!isUpdate)
                {
                    loan.UserId = Convert.ToInt32(
                        Session["UserId"]
                    );

                    loan.Status = LoanStatus.Borrowed;

                    _loanManager.AddLoan(loan);

                    lblMessage.Text =
                        "Kitap başarıyla ödünç verildi.";
                }
              
                else
                {
                    loan.Id = loanId;

                    loan.Status = LoanStatus.Borrowed;

                    _loanManager.UpdateLoan(loan);

                    lblMessage.Text =
                        "Ödünç kaydı başarıyla güncellendi.";
                }

                List();

                ClearForm();

                LoadBooks();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Hata: " + ex.Message;
            }
        }

        
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnReturn = sender as Button;

                if (btnReturn == null)
                {
                    lblMessage.Text =
                        "İade işlemi için kayıt bulunamadı.";

                    return;
                }

                int loanId = Convert.ToInt32(
                    btnReturn.CommandArgument
                );

                _loanManager.ReturnBook(loanId);

                lblMessage.Text =
                    "Kitap başarıyla iade alındı.";

                List();

                LoadBooks();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "İade işlemi sırasında hata oluştu: "
                    + ex.Message;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = sender as Button;

                if (btnEdit == null)
                {
                    lblMessage.Text = "Düzenlenecek kayıt bulunamadı.";
                    return;
                }

                int loanId = Convert.ToInt32(
                    btnEdit.CommandArgument
                );

                var loan = _loanManager
                    .GetAllLoans()
                    .FirstOrDefault(x => x.Id == loanId);

                if (loan == null)
                {
                    lblMessage.Text = "Ödünç kaydı bulunamadı.";
                    return;
                }

              

                if (loan.Status == LoanStatus.Returned)
                {
                    lblMessage.Text =
                        "İade edilmiş bir ödünç kaydı düzenlenemez.";

                    return;
                }


                LoadMembers();
                LoadBooks();



                hdnLoanId.Value =
                    loan.Id.ToString();


              

                if (ddlMember.Items.FindByValue(
                    loan.MemberId.ToString()) != null)
                {
                    ddlMember.SelectedValue =
                        loan.MemberId.ToString();
                }


            
                if (ddlBook.Items.FindByValue(
                    loan.BookId.ToString()) != null)
                {
                    ddlBook.SelectedValue =
                        loan.BookId.ToString();
                }



                txtBorrowDate.Text =
                    loan.BorrowDate.ToString(
                        "yyyy-MM-ddTHH:mm"
                    );

                txtDueDate.Text =
                    loan.DueDate.ToString(
                        "yyyy-MM-dd"
                    );



                txtNotes.Text =
                    loan.Notes ?? "";



                btnSaveLoan.Text = "Güncelle";



                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "OpenLoanModal",
                    "var modal = new bootstrap.Modal(document.getElementById('loanModal')); modal.show();",
                    true
                );
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Düzenleme sırasında hata oluştu: "
                    + ex.Message;
            }
        }

       
        private void ClearForm()
        {
            hdnLoanId.Value = "";

            ddlMember.SelectedIndex = 0;
            ddlBook.SelectedIndex = 0;

            txtBorrowDate.Text =
                DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

            txtDueDate.Text =
                DateTime.Now.AddDays(14).ToString("yyyy-MM-dd");

            txtNotes.Text = "";

            btnSaveLoan.Text = "Ödünç Ver";
        }
    }
}