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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Veritabanı bağlamı oluşturuluyor
        EgitimCampiEfTravelDbEntities db = new EgitimCampiEfTravelDbEntities();

        // Listeleme butonuna tıklanınca yapılacak işlemler
        private void btnList_Click(object sender, EventArgs e)
        {
            // Tbl_Location tablosundaki veriler alınıyor ve DataGridView'e atanıyor
            var values = db.Tbl_Location.ToList();
            dataGridView1.DataSource = values;
        }

        // Ekleme butonuna tıklanınca yapılacak işlemler
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Yeni bir Tbl_Location nesnesi oluşturuluyor
            Tbl_Location tbl_Location = new Tbl_Location();
            // Formdaki veriler Tbl_Location nesnesine atanıyor
            tbl_Location.LocationCity = txtCity.Text;
            tbl_Location.LocationCountry = txtCountry.Text;
            tbl_Location.LocationCapacity = byte.Parse(numericUpDown1.Value.ToString());
            tbl_Location.LocationPrice = decimal.Parse(txtPrice.Text);
            tbl_Location.DayNight = txtDayNight.Text;
            tbl_Location.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            // Tbl_Location nesnesi veritabanına ekleniyor
            db.Tbl_Location.Add(tbl_Location);
            db.SaveChanges();
            // Kullanıcıya başarılı bir ekleme mesajı gösteriliyor
            MessageBox.Show("Location Added Successfully!");
        }

        // Form yüklendiğinde yapılacak işlemler
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            // Tbl_Guide tablosundaki veriler alınıyor ve ComboBox'a atanıyor
            var values = db.Tbl_Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();

            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "GuideId";
            comboBox1.DataSource = values;
        }

        // Silme butonuna tıklanınca yapılacak işlemler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Silinecek kaydın ID'si alınıyor
            int id = int.Parse(txtId.Text);
            // ID'ye göre kayıt bulunuyor ve veritabanından siliniyor
            var removedValue = db.Tbl_Location.Find(id);
            db.Tbl_Location.Remove(removedValue);
            db.SaveChanges();
            // Kullanıcıya başarılı bir silme mesajı gösteriliyor
            MessageBox.Show("Location Deleted Successfully");
        }

        // Güncelleme butonuna tıklanınca yapılacak işlemler
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Güncellenecek kaydın ID'si alınıyor
            int id = int.Parse(txtId.Text);
            // ID'ye göre kayıt bulunuyor ve alanları güncelleniyor
            var updatedValue = db.Tbl_Location.Find(id);
            updatedValue.LocationCity = txtCity.Text;
            updatedValue.LocationCountry = txtCountry.Text;
            updatedValue.LocationCapacity = byte.Parse(numericUpDown1.Value.ToString());
            updatedValue.LocationPrice = decimal.Parse(txtPrice.Text);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            // Değişiklikler veritabanına kaydediliyor
            db.SaveChanges();
            // Kullanıcıya başarılı bir güncelleme mesajı gösteriliyor
            MessageBox.Show("Location Updated Successfully!");
        }

        // ID'ye göre kayıt getirme butonuna tıklanınca yapılacak işlemler
        private void btnGetbyid_Click(object sender, EventArgs e)
        {
            // Getirilecek kaydın ID'si alınıyor
            int id = int.Parse(txtId.Text);
            // ID'ye göre kayıt bulunuyor ve DataGridView'e atanıyor
            var value = db.Tbl_Location.Where(x => x.LocationId == id).ToList();
            dataGridView1.DataSource = value;
        }

    }
}
