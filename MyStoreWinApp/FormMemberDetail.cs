using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class FormMemberDetail : Form
    {
        internal IMemberRepository memberRepository;
        internal bool insertOrUpdate; // 0 : insert, 1: update
        internal MemberObject member;
        internal object listCountry;
        internal object listCity;

        public FormMemberDetail() => InitializeComponent();

        // created by form
        private void FormMemberDetail_Load(object sender, EventArgs e)
        {
            cbxCity.DataSource = listCity;
            cbxCountry.DataSource = listCountry;
            txtID.Enabled = !insertOrUpdate;
            if (insertOrUpdate == true)
            {
                txtID.Text = member.MemberID.ToString();
                txtName.Text = member.MemberName.ToString();
                txtEmail.Text = member.Email.ToString();
                txtPassword.Text = member.Password.ToString();
                cbxCity.Text = member.City.ToString();
                cbxCountry.Text = member.Country.ToString();
            }
        }
        // save btn 
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = new MemberObject()
                {
                    MemberID = Convert.ToInt32(txtID.Text),
                    MemberName = txtName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = cbxCity.Text,
                    Country = cbxCountry.Text
                };
                if (insertOrUpdate == false) //insert
                {
                    memberRepository.Add(mem);
                }
                else  //update
                {
                    memberRepository.Update(mem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save member");
            }
        }
        private void button2_Click(object sender, EventArgs e) => Close();

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            string regex = ".+@gmail.com";
            if (!Regex.IsMatch(txtEmail.Text, regex))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;

            }

        }




    }
}
