using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class FormLogin : Form
    {
        private string user;
        private string pass;
        public IMemberRepository memRespository;


        public FormLogin()
        {
            InitializeComponent();
        }

        public FormLogin(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //txtEmail.Text = user;
            //txtPassword.Text = pass;
            memRespository = new MemberRepository();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check null
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Email or password must not null", "Announcement");
                return;

            }

            if (memRespository.GetMemberByEP(txtEmail.Text, txtPassword.Text) != null)
            {
                memberRole();

            }
            else if (txtEmail.Text == user && txtPassword.Text == pass)
            {
                AdminRole();

            }
            else
            {
                MessageBox.Show("Wrong Username, Password", "Announcement");
                return;
            }
        }
        // Admin window
        void AdminRole()
        {
            FormMemberManagerment form = new FormMemberManagerment()
            {
                Text = "Memeber Manager",
                memberRepository1 = memRespository
            };
            this.Hide();
            form.ShowDialog();
            txtEmail.Text = user;
            txtPassword.Text = pass;
            this.Show();
        }
        // memeberWindow
        void memberRole()
        {
            MemberObject mem = memRespository.GetMemberByEP(txtEmail.Text, txtPassword.Text);

            FormMemberDetail form1 = new FormMemberDetail()
            {
                Text = "Your info detals",
                insertOrUpdate = true,
                member = mem,
                memberRepository = this.memRespository
            };
            this.Hide();
            form1.ShowDialog();
            txtEmail.Text = user;
            txtPassword.Text = pass;
            this.Show();
        }


        private void btnCancle_Click(object sender, EventArgs e) => Close();

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "exit", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
