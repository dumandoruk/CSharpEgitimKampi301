using DevExpress.Utils.VisualEffects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimCampiEfTravelDbEntities db = new EgitimCampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {

            var values =db.Tbl_Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Guide guide = new Tbl_Guide();
            guide.GuideName=txtName.Text;
            guide.GuideSurname=txtSurname.Text;
            db.Tbl_Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Guide Added Successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtId.Text);
            var removeValue=db.Tbl_Guide.Find(id);
            db.Tbl_Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Guide Removed Successfully!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue=db.Tbl_Guide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Guide Updated Successfully!");
        }

        private void btnGetbyid_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var values=db.Tbl_Guide.Where(x=> x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
