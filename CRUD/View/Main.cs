using CRUD.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Main : Form, AppInterface
    {
        EmployeeController controller = null;

        public Main()
        {
            InitializeComponent();
            controller = new EmployeeController(this);
        }

        #region Interfaces
        public string EmployeeId
        {
            get
            {
                return txtID.Text;
            }

            set
            {
                txtID.Text = value;
            }
        }

        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }

            set
            {
                txtFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }

            set
            {
                txtLastName.Text = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return txtMiddleName.Text;
            }

            set
            {
                txtMiddleName.Text = value;
            }
        }

        public void SetController(EmployeeController _controller)
        {
            controller = _controller;
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = controller.GetEmployee();

                if (dt.Rows.Count > 0)
                {
                    dgvView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Employee id not found.");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (controller.Save() > 0)
                {
                    MessageBox.Show("Employee saved successfully");
                    btnClear.PerformClick();
                }
                else
                    MessageBox.Show("Failed to save employee. Please try again");

            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();

            txtLastName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (controller.Update() > 0)
                    MessageBox.Show("Employee updated successfully");
                else
                    MessageBox.Show("Failed to update employee. Please try again");

            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (controller.Delete() > 0)
                    MessageBox.Show("Employee deleted successfully");
                else
                    MessageBox.Show("Failed to delete employee. Please try again");

            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }
    }
}
