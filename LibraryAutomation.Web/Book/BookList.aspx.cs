using LibraryAutomation.Business.Managers;
using LibraryAutomation.Entities;
using NuGet.Protocol.Plugins;
using System;

namespace LibraryAutomation.Web.Book
{
    public partial class BookList : System.Web.UI.Page
    {
        private readonly BookManager _bookManager;
        private readonly CategoryManager _categoryManager;

        public BookList()
        {
            _bookManager = new BookManager();
            _categoryManager = new CategoryManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBooks();
                LoadCategories();
            }
        }

        private void LoadBooks()
        {
            var books = _bookManager.GetAllBooks();

            gvBooks.DataSource = books;
            gvBooks.DataBind();
        }

        protected void btnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                var book = new Entities.Book();

                book.Name = txtBookName.Text.Trim();
                book.Author = txtAuthor.Text.Trim();
                book.ISBN = txtISBN.Text.Trim();
                book.Publisher = txtPublisher.Text.Trim();
                book.PublishYear = int.Parse(txtPublishYear.Text);
                book.PageCount = int.Parse(txtPageCount.Text);
                book.Stock = int.Parse(txtStock.Text);
                book.CategoryId = int.Parse(ddlCategory.SelectedValue);
                book.IsActive = true;
                book.CreatedDate = DateTime.Now;

                _bookManager.AddBook(book);

                LoadBooks();

                lblMessage.Text = "Kitap başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }

        private void LoadCategories()
        {
            var categories = _categoryManager.GetActiveCategories();

            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(
                0,
                new System.Web.UI.WebControls.ListItem("Kategori seçiniz", ""));

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32((sender as System.Web.UI.WebControls.Button).CommandArgument);
                bool isDeleted = _bookManager.DeleteBook(bookId);
                if (isDeleted)
                {
                    LoadBooks();
                    lblMessage.Text = "Kitap başarıyla silindi.";
                }
                else
                {
                    lblMessage.Text = "Kitap silinemedi. Lütfen tekrar deneyin.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }
    }
}