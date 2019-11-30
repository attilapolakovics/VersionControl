using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName;
            btnAdd.Text = Resource1.Add;
            btnToFile.Text = Resource1.ToFile;
            btnDelete.Text = Resource1.Delete;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text,
            };
            users.Add(u);
        }

        private void BtnToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = Resource1.CSVFiles + "|*.csv";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(dialog.FileName))
                {
                    foreach (User row in listUsers.Items)
                    {
                        writer.WriteLine(string.Format("{0},{1}", row.ID, row.FullName));
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedIndex > -1)
            {
                users.RemoveAt(listUsers.SelectedIndex);
            }
        }
    }
}
