using LibraryAutomation.Business.Managers;
using LibraryAutomation.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryAutomation.Web.Member
{
    public partial class MemberList : System.Web.UI.Page
    {
        private readonly MemberManager _memberManager;

        public MemberList()
        {
            _memberManager = new MemberManager();
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
            var members = _memberManager.GetAllMembers();

            gvMembers.DataSource = members;
            gvMembers.DataBind();
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = sender as Button;

                int memberId = Convert.ToInt32(
                    btnEdit.CommandArgument
                );

                var member = _memberManager.GetMemberById(memberId);

                if (member == null)
                {
                    lblMessage.Text = "Üye bulunamadı.";
                    return;
                }

                hdnMemberId.Value = member.Id.ToString();

                txtFirstName.Text = member.FirstName;
                txtLastName.Text = member.LastName;
                txtEmail.Text = member.Email;
                txtPhone.Text = member.Phone;
                txtAddress.Text = member.Address;

                if (member.BirthDate.HasValue)
                {
                    txtBirthDate.Text =
                        member.BirthDate.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtBirthDate.Text = "";
                }

                chkIsActive.Checked = member.IsActive;

                btnSaveMember.Text = "Üyeyi Güncelle";

                string script = @"
                    setTimeout(function () {
                        var modalElement =
                            document.getElementById('memberModal');

                        if (modalElement) {
                            var modal =
                                bootstrap.Modal.getOrCreateInstance(modalElement);

                            modal.show();
                        }
                    }, 100);
                ";

                ClientScript.RegisterStartupScript(
                    GetType(),
                    "OpenMemberModal",
                    script,
                    true
                );
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDelete = sender as Button;

                int memberId = Convert.ToInt32(
                    btnDelete.CommandArgument
                );

                _memberManager.RemoveMember(memberId);

                lblMessage.Text =
                    "Üye başarıyla pasife alındı.";

                List();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Hata: " + ex.Message;
            }
        }

        protected void btnSaveMember_Click(object sender, EventArgs e)
        {
            try
            {

                int memberId;

                bool isUpdate = int.TryParse(
                    hdnMemberId.Value,
                    out memberId
                );

                DateTime birthDate;
                DateTime? birthDateValue = null;

                if (DateTime.TryParse(
                    txtBirthDate.Text,
                    out birthDate))
                {
                    birthDateValue = birthDate;
                }

                var member = new Entities.Member
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    BirthDate = birthDateValue,
                    IsActive = chkIsActive.Checked
                };

                if (isUpdate)
                {
                    member.Id = memberId;

                    _memberManager.UpdateMember(member);

                    lblMessage.Text =
                        "Üye başarıyla güncellendi.";
                }
 
                else
                {
                    string memberNumber;

                    Random random = new Random();

                    do
                    {
                        memberNumber =
                            "UYE-" +
                            random.Next(100000, 1000000);
                    }
                    while (
                        _memberManager.MemberNumberExists(
                            memberNumber
                        )
                    );

                    member.MemberNumber = memberNumber;
                    member.CreatedDate = DateTime.Now;

                    _memberManager.AddMember(member);

                    lblMessage.Text =
                        "Üye başarıyla eklendi. Üye No: "
                        + memberNumber;
                }

                List();

                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Hata: " + ex.Message;
            }
        }


        private void ClearForm()
        {
            hdnMemberId.Value = "";

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtBirthDate.Text = "";

            chkIsActive.Checked = true;

            btnSaveMember.Text =
                "Üyeyi Kaydet";
        }
    }
}