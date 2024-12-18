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

        // Veritabanı bağlamı oluşturuluyor
        EgitimCampiEfTravelDbEntities db = new EgitimCampiEfTravelDbEntities();

        // Listeleme butonuna tıklanınca yapılacak işlemler
        private void btnList_Click(object sender, EventArgs e)
        {
            // Tbl_Guide tablosundaki veriler alınıyor ve DataGridView'e atanıyor
            var values = db.Tbl_Guide.ToList();
            dataGridView1.DataSource = values;
        }

        // Ekleme butonuna tıklanınca yapılacak işlemler
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Yeni bir Tbl_Guide nesnesi oluşturuluyor
            Tbl_Guide guide = new Tbl_Guide();
            // Formdaki veriler Tbl_Guide nesnesine atanıyor
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            // Tbl_Guide nesnesi veritabanına ekleniyor
            db.Tbl_Guide.Add(guide);
            db.SaveChanges();
            // Kullanıcıya başarılı bir ekleme mesajı gösteriliyor
            MessageBox.Show("Guide Added Successfully!");
        }

        // Silme butonuna tıklanınca yapılacak işlemler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Silinecek kaydın ID'si alınıyor
            int id = int.Parse(txtId.Text);
            // ID'ye göre kayıt bulunuyor ve veritabanından siliniyor
            var removeValue = db.Tbl_Guide.Find(id);
            db.Tbl_Guide.Remove(removeValue);
            db.SaveChanges();
            // Kullanıcıya başarılı bir silme mesajı gösteriliyor
            MessageBox.Show("Guide Removed Successfully!");
        }

        // Güncelleme butonuna tıklanınca yapılacak işlemler
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Güncellenecek kaydın ID'si alınıyor
            int id = int.Parse(txtId.Text);
            // ID'ye göre kayıt bulunuyor ve alanları güncelleniyor
            var updateValue = db.Tbl_Guide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            // Kullanıcıya başarılı bir güncelleme mesajı gösteriliyor
            MessageBox.Show("Guide Updated Successfully!");
        }

        // ID'ye göre kayıt getirme butonuna tıklanınca yapılacak işlemler
        private void btnGetbyid_Click(object sender, EventArgs e)
        {
            // Getirilecek kaydın ID'si alınıyor
            int id = int.Parse(txtId.Text);
            // ID'ye göre kayıt bulunuyor ve DataGridView'e atanıyor
            var values = db.Tbl_Guide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
        }

    }
}
