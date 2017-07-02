using Service;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Personel : Form
    {
        IPersonelService personelService;

        public Personel()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                personelService = new PersonelService();
                personelService.insert("insert into Personel (Adi, Soyadi, KayitTarihi) values ('" + txtAdi.Text + "','" + txtSoyadi.Text + "','" +
                    Convert.ToDateTime(dtpTarih.Text) + "')");
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi..!", "Tebrikler");
                personelListe();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Eklenemedi..!","Uyarı");
            }
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            personelListe();
        }

        public void personelListe()
        {
            personelService = new PersonelService();
            var sonuc = personelService.personelListesi("Select * from Personel");
            comboBox1.DataSource = sonuc;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Adi";
            dtPersonelListe.DataSource = sonuc;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var item = (PersonelDTO)dtPersonelListe.SelectedRows[0].DataBoundItem;
                personelService = new PersonelService();
                personelService.delete("Delete from Personel where Id= " + item.Id + "");
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Silndi..!", "Tebrikler");
                personelListe();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinemedi..!", "Uyarı");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var item = (PersonelDTO) dtPersonelListe.SelectedRows[0].DataBoundItem;
            personelService = new PersonelService();
            personelService.update("update Personel set Adi = '" + txtAdi.Text + "', Soyadi = '" + txtSoyadi.Text + 
                "', KayitTarihi = '" + Convert.ToDateTime(dtpTarih.Value) + "' where Id= '" + item.Id + "'");
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi..!", "Tebrikler");
            personelListe(); 
                
        }

        private void dtPersonelListe_SelectionChanged(object sender, EventArgs e)
        {
            if(dtPersonelListe.SelectedRows.Count != 0)
            {
                var item = (PersonelDTO) dtPersonelListe.SelectedRows[0].DataBoundItem;
                txtAdi.Text = item.Adi;
                txtSoyadi.Text = item.Soyadi;
                dtpTarih.Value = item.KayitTarihi;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
