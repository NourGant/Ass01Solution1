using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using System.Xml.Linq;
using System.CodeDom;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace MyStoreWinApp
{
    public partial class FormMemberManagerment : Form
    {

        public IMemberRepository memberRepository1;
        BindingSource bindingSource;
        List<MemberObject> memberList;

        List<string> cityList;
        List<string> countryList;

        bool sortStatus = true; // true : sort name ascending, false : sort name decending

        public FormMemberManagerment()
        {
            InitializeComponent();
        }

        private void FormMemberManagerment_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnSort.Enabled = false;
            LoadCityList();
            LoadCountryList();
        }
        private MemberObject getMember()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject()
                {
                    MemberID = Convert.ToInt32(txtID.Text),
                    MemberName = txtName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");

            }
            return member;
        }


        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormMemberDetail form1 = new FormMemberDetail()
            {
                Text = "Update member",
                insertOrUpdate = true,
                member = getMember(),
                memberRepository = memberRepository1,
                listCity = cityList,
                listCountry = countryList
            };
            if (form1.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                bindingSource.Position = bindingSource.Count - 1;

            }


        }
        private void ClearText()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;

        }


        private void LoadMemberList()
        {
            var members = memberList;
            try
            {
                bindingSource = new BindingSource();
                // assign biding source to source members
                bindingSource.DataSource = members;

                // clear databiding in txtbox
                txtID.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();


                txtID.DataBindings.Add("Text", bindingSource, "MemberID");
                txtName.DataBindings.Add("Text", bindingSource, "MemberName");
                txtEmail.DataBindings.Add("Text", bindingSource, "Email");
                txtPassword.DataBindings.Add("Text", bindingSource, "Password");
                txtCity.DataBindings.Add("Text", bindingSource, "City");
                txtCountry.DataBindings.Add("Text", bindingSource, "Country");

                // assign binding source to datagridview
                dgvMember.DataSource = null;
                dgvMember.DataSource = bindingSource;
                if (members.Count == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnSort.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");

            }
        }

        private void LoadCountryList()
        {
            countryList = memberRepository1.getListMember().Select(x => x.Country).Distinct().ToList();
            countryList.Insert(0, "none");
            cbxCountry.DataSource = null;
            cbxCountry.DataSource = countryList;
        }

        private void LoadCityList()
        {
            cityList = memberRepository1.getListMember().Select(x => x.City).Distinct().ToList();
            cityList.Insert(0, "none");
            cbxCity.DataSource = null;
            cbxCity.DataSource = cityList;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            memberList = memberRepository1.getListMember();
            LoadMemberList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormMemberDetail form1 = new FormMemberDetail()
            {
                Text = "Add member",
                insertOrUpdate = false,
                memberRepository = memberRepository1,
                listCity = cityList,
                listCountry = countryList

            };
            if (form1.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                LoadCityList();
                LoadCountryList();
                bindingSource.Position = bindingSource.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = getMember();
                memberRepository1.Delete(mem.MemberID);
                LoadMemberList();
                LoadCityList();
                LoadCountryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleate member");

            }

        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            sortFuctionText();

        }
        private void sortFuctionText()
        {
            ClearText();
            string textSearch = txtSearchBox.Text;
            var members = memberRepository1.getListMember();
            var sortMembers = members.Where(x => x.MemberName.Contains(textSearch) || x.MemberID.ToString().Equals(textSearch)).ToList();
            memberList = sortMembers;
            LoadMemberList();

        }

        // reset memberlist clear all data form datagridview
        private void btnClear_Click(object sender, EventArgs e)
        {
            //dgvMember.DataSource = null;
            txtSearchBox.Text = string.Empty;
            cbxCity.Text = string.Empty;
            cbxCountry.Text = string.Empty;
            sortStatus = true;

            ClearText();
            LoadCityList();
            LoadCountryList();
            memberList = new List<MemberObject>();
            LoadMemberList();

            btnDelete.Enabled = false;
            btnSort.Enabled = false;
            //LoadMemberList();
        }


        private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCountry.Text = "none ";
            if (memberList != null)
            {
                string key = cbxCity.Text;
                if (key.Equals("none"))
                {
                    sortFuctionText();
                }
                else
                {
                    var sortMembers = memberRepository1.getListMember().Where(x => x.City.Equals(key)).ToList();
                    memberList = sortMembers;
                    LoadMemberList();
                }
            }
        }
        private void cbxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCity.Text = "none ";
            if (memberList != null)
            {
                string key = cbxCountry.Text;
                if (key.Equals("none"))
                {
                    sortFuctionText();
                }
                else
                {
                    var sortMembers = memberRepository1.getListMember().Where(x => x.Country.Equals(key)).ToList();
                    memberList = sortMembers;
                    LoadMemberList();
                }
            }
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memberList = memberRepository1.getListMember();
            LoadMemberList();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMemberDetail form1 = new FormMemberDetail()
            {
                Text = "Add member",
                insertOrUpdate = false,
                memberRepository = memberRepository1
            };
            if (form1.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                bindingSource.Position = bindingSource.Count - 1;

            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string regex = ".+@gmail.com";
            if (!Regex.IsMatch(txtEmail.Text, regex))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }


        }

        // sort function
        private void button2_Click(object sender, EventArgs e)
        {
            if (sortStatus)
            {
                memberList.Sort(MemberObject.NameComparisonDesc);
                btnSort.Text = "sort decending";

            }
            else
            {
                memberList.Sort(MemberObject.NameComparison);
                btnSort.Text = "sort ascending";
            }
            sortStatus = !sortStatus;   
            LoadMemberList();
        }
    }
}
