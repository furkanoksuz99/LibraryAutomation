using LibraryAutomation.Business.Managers;
using System;
using System.Web.UI.WebControls;

namespace LibraryAutomation.Web.Category
{
    public partial class CategoryList : System.Web.UI.Page
    {
        private readonly CategoryManager _categoryManager;

        public CategoryList()
        {
            _categoryManager = new CategoryManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List();
            }
        }

        private void List()
        {
            var categories = _categoryManager.GetAllCategories();

            gvCategories.DataSource = categories;
            gvCategories.DataBind();
        }

        // KAYDET / GÜNCELLE
        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId;

                // HiddenField doluysa güncelleme yapıyoruz
                bool isUpdate = int.TryParse(
                    hdnCategoryId.Value,
                    out categoryId
                );

                var category = new Entities.Category
                {
                    Name = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    IsActive = chkIsActive.Checked
                };

                if (isUpdate)
                {
                    // GÜNCELLE
                    category.Id = categoryId;

                    _categoryManager.UpdateCategory(category);

                    lblMessage.Text = "Kategori başarıyla güncellendi.";
                }
                else
                {
                    // YENİ KAYIT
                    category.CreatedDate = DateTime.Now;

                    _categoryManager.AddCategory(category);

                    lblMessage.Text = "Kategori başarıyla eklendi.";
                }

                List();

                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }

        // SİL
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDelete = sender as Button;

                int categoryId = Convert.ToInt32(
                    btnDelete.CommandArgument
                );

                _categoryManager.DeleteCategory(categoryId);

                List();

                lblMessage.Text = "Kategori başarıyla silindi.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }

        // DÜZENLE
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = sender as Button;

                int categoryId = Convert.ToInt32(
                    btnEdit.CommandArgument
                );

                // ID'ye göre kategoriyi getir
                var category = _categoryManager.GetCategoryById(categoryId);

                if (category == null)
                {
                    lblMessage.Text = "Kategori bulunamadı.";
                    return;
                }

                // Formu doldur
                hdnCategoryId.Value = category.Id.ToString();

                txtCategoryName.Text = category.Name;

                txtDescription.Text = category.Description;

                chkIsActive.Checked = category.IsActive;

                // Buton yazısını değiştir
                btnSaveCategory.Text = "Kategoriyi Güncelle";

                // Modalı tekrar aç
                string script = @"
                    setTimeout(function () {
                        var modalElement = document.getElementById('categoryModal');

                        if (modalElement) {
                            var modal = bootstrap.Modal.getOrCreateInstance(modalElement);
                            modal.show();
                        }
                    }, 100);
                ";

                ClientScript.RegisterStartupScript(
                    GetType(),
                    "OpenCategoryModal",
                    script,
                    true
                );
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }

  
        private void ClearForm()
        {
            hdnCategoryId.Value = "";

            txtCategoryName.Text = "";

            txtDescription.Text = "";

            chkIsActive.Checked = true;

            btnSaveCategory.Text = "Kategoriyi Kaydet";
        }
    }
}