using OtelRezervasyonSistemi.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi.Formlar
{
    public partial class frmOtelIslemleri : Form
    {
        public frmOtelIslemleri()
        {
            InitializeComponent();
        }
        IkiliAramaAgaci IkiliAramaAgac = new IkiliAramaAgaci();
        HashMusteriler hashMusteriler = new HashMusteriler();
        HashRezervasyonlar hashRezervasyonlar = new HashRezervasyonlar();
        Heap heap = new Heap(200);
        int j = 0;
        int i = 0;
        int toplam = 0;


        DataTable tablo = new DataTable();
        DataTable tabloPersonel = new DataTable();
        DataTable tabloOda = new DataTable();
        DataTable RezervasyonOdaListele = new DataTable();
        DataTable GuncelleRezervasyonOdaListele = new DataTable();


        private void frmOtelIslemleri_Load(object sender, EventArgs e)
        {
           
            tablo.Columns.Add("Otel Adı", typeof(string));
            tablo.Columns.Add("Adres", typeof(string));
            tablo.Columns.Add("Il", typeof(string));
            tablo.Columns.Add("Ilçe", typeof(string));
            tablo.Columns.Add("Eposta", typeof(string));
            tablo.Columns.Add("Oda Sayısı", typeof(int));
            tablo.Columns.Add("Puan", typeof(int));
            tablo.Columns.Add("Telefon No", typeof(string));
            tablo.Columns.Add("Yıldız Sayısı", typeof(int));
            dgvOtelListesi.DataSource = tablo;

            tabloPersonel.Columns.Add("Ad", typeof(string));
            tabloPersonel.Columns.Add("Soyad", typeof(string));
            tabloPersonel.Columns.Add("TC", typeof(string));
            tabloPersonel.Columns.Add("Telefon", typeof(string));
            tabloPersonel.Columns.Add("Adres", typeof(string));
            tabloPersonel.Columns.Add("Departman", typeof(string));
            tabloPersonel.Columns.Add("Pozisyon", typeof(string));
            tabloPersonel.Columns.Add("Eposta", typeof(string));
            dgvPersonel.DataSource = tabloPersonel;

            tabloOda.Columns.Add("Oda No", typeof(string));
            tabloOda.Columns.Add("Telefon No", typeof(string));
            tabloOda.Columns.Add("Kişi Sayısı", typeof(string));
            tabloOda.Columns.Add("Manzara Durumu", typeof(string));
            tabloOda.Columns.Add("Rezarvasyon Durumu", typeof(string));
            tabloOda.Columns.Add("Fiyat", typeof(string));
            dgvOdaBilgileri.DataSource = tabloOda;

            RezervasyonOdaListele.Columns.Add("Otel Adı", typeof(string));
            RezervasyonOdaListele.Columns.Add("Oda No", typeof(int));
            RezervasyonOdaListele.Columns.Add("Telefon No", typeof(string));
            RezervasyonOdaListele.Columns.Add("Kişi Sayısı", typeof(int));
            RezervasyonOdaListele.Columns.Add("Manzara Durumu", typeof(string));
            RezervasyonOdaListele.Columns.Add("Rezarvasyon Durumu", typeof(string));
            RezervasyonOdaListele.Columns.Add("Fiyat", typeof(float));
            dgvRezervasyonOdaListesi.DataSource = RezervasyonOdaListele;

            GuncelleRezervasyonOdaListele.Columns.Add("Otel Adı", typeof(string));
            GuncelleRezervasyonOdaListele.Columns.Add("Oda No", typeof(int));
            GuncelleRezervasyonOdaListele.Columns.Add("Telefon No", typeof(string));
            GuncelleRezervasyonOdaListele.Columns.Add("Kişi Sayısı", typeof(int));
            GuncelleRezervasyonOdaListele.Columns.Add("Manzara Durumu", typeof(string));
            GuncelleRezervasyonOdaListele.Columns.Add("Rezarvasyon Durumu", typeof(string));
            GuncelleRezervasyonOdaListele.Columns.Add("Fiyat", typeof(float));
            dgvGuncelleOdaListesi.DataSource = GuncelleRezervasyonOdaListele;

        }


        private void btnOtelEkle_Click(object sender, EventArgs e)
        {
            if (txtOtelAd.Text!="" && txtOtelAdres.Text!="" && cmbIl.Text!="" && cmbİlce.Text!="" && mskOtelTelefon.Text!="" && txtOtelEposta.Text!="" && mskOdaSayisi.Text!=""&& mskYildiz.Text!="")
            {
                try
                {
                    Otel otel = new Otel();
                    otel.Ad = txtOtelAd.Text;
                    otel.Adres = txtOtelAdres.Text;
                    otel.BulunduguIl = cmbIl.Text;
                    otel.BulunduguIlce = cmbİlce.Text;
                    otel.Eposta = txtOtelEposta.Text;
                    otel.OdaSayisi = Convert.ToInt32(mskOdaSayisi.Text);
                    otel.Puani = 0;
                    otel.TelefonNo = mskOtelTelefon.Text;
                    otel.YildizSayisi = Convert.ToInt32(mskYildiz.Text);
                    IkiliAramaAgac.IsmeGoreOtelEkle(otel);
                    tablo.Rows.Add(otel.Ad, otel.Adres, otel.BulunduguIl, otel.BulunduguIlce, otel.Eposta, otel.OdaSayisi, otel.Puani, otel.TelefonNo, otel.YildizSayisi);
                    dgvOtelListesi.DataSource = tablo;
                    cmbOtelListesi.Items.Add(otel.Ad);
                    cmbIsmeGore.Items.Add(otel.Ad);
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }

            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!");
            }
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOtelAdi.Text);
            
            if (txtAd.Text!="" && txtSoyad.Text!="" && mskTC.Text!="" && mskPersonelTelefon.Text!="" && txtPersonelAdres.Text!="" && cmbDepartman.Text!="" && cmbPozisyon.Text!="" && txtPersonelEposta.Text!="")
            {
                try
                {
                    OtelPersonel otelPersonel = new OtelPersonel()
                    {
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TCKimlikNo = mskTC.Text,
                        TelefonNo = mskPersonelTelefon.Text,
                        Adres = txtPersonelAdres.Text,
                        Departman = cmbDepartman.Text,
                        Pozisyon = cmbPozisyon.Text,
                        Eposta = txtPersonelEposta.Text

                    };
                    dugum.veri.personeller.InsertFirst(otelPersonel);
                    tabloPersonel.Rows.Add(otelPersonel.Ad, otelPersonel.Soyad, otelPersonel.TCKimlikNo, otelPersonel.TelefonNo, otelPersonel.Adres, otelPersonel.Departman, otelPersonel.Pozisyon, otelPersonel.Eposta);
                    dgvPersonel.DataSource = tabloPersonel;
                    MessageBox.Show("Kayıt Tamamlandı.");
                    EkranHazirla();

                    
                }



                catch (Exception ex)
                {
                    MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }

            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!");
            }
        }
        private void EkranHazirla()
        {
            txtPersonelAdres.Text = txtAd.Text = mskPersonelTelefon.Text = txtSoyad.Text = cmbDepartman.Text = txtPersonelEposta.Text = cmbPozisyon.Text = mskTC.Text = "";
            txtAd.Focus();

        }
        private void OdaOtelEkranHazirla()
        {
            mskOdaNo.Text = mskOdaTel.Text = mskKisiSayisi.Text = cmbManzara.Text = cmbRezervasyon.Text = mskFiyat.Text = "";
            txtAd.Focus();

        }
        private void frmOtelIslemleri_Shown(object sender, EventArgs e)
        {
            txtAd.Focus();
        }

        private void btnPersonelTemizle_Click(object sender, EventArgs e)
        {
            EkranHazirla();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Otel kayıt işlemini yapınız!");
                return;
            }

            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOtelAdi.Text);
            if (dugum != null)
            {
                MessageBox.Show(dugum.veri.Ad + " Otel bulundu");
                grpPersonel.Enabled = true;
                btnPersonelEkle.Enabled= true;
            }
            else
            {
                MessageBox.Show(txtOtelAdi.Text + " Otel bulunamadı.");
            }         
        }

        private void btnOtelSil_Click(object sender, EventArgs e)
        {

                if (txtOtelAd.Text != "")
                {
                    try
                    {
                        Otel otel = new Otel();
                        otel.Ad = txtOtelAd.Text;
                        IkiliAramaAgac.Sil(otel.Ad);
                        MessageBox.Show("Otel silme işlemi başarılı");

                        foreach (DataGridViewRow row in dgvOtelListesi.SelectedRows)
                        {
                            dgvOtelListesi.Rows.Remove(row);
                        }
                        Temizle();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }
                }
                else
                {
                    MessageBox.Show("Silmek istediğiniz otel Adını giriniz.");
                }
            
            
            
        }
       
        private void dgvOtelListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOtelAd.Text = dgvOtelListesi.CurrentRow.Cells[0].Value.ToString();
            txtOtelAdiGuncelle.Text= dgvOtelListesi.CurrentRow.Cells[0].Value.ToString();
            txtOtelAdres.Text = dgvOtelListesi.CurrentRow.Cells[1].Value.ToString();
            cmbIl.Text = dgvOtelListesi.CurrentRow.Cells[2].Value.ToString();
            cmbİlce.Text = dgvOtelListesi.CurrentRow.Cells[3].Value.ToString();
            txtOtelEposta.Text = dgvOtelListesi.CurrentRow.Cells[4].Value.ToString();
            mskOdaSayisi.Text = dgvOtelListesi.CurrentRow.Cells[5].Value.ToString();
            mskOtelTelefon.Text = dgvOtelListesi.CurrentRow.Cells[7].Value.ToString();
            mskYildiz.Text = dgvOtelListesi.CurrentRow.Cells[8].Value.ToString();
        }
        private void Temizle()
        {
            txtOtelAd.Text = "";
            txtOtelAdres.Text = "";
            cmbIl.Text = "";
            cmbİlce.Text = "";
            txtOtelEposta.Text = "";
            mskOdaSayisi.Text = "";
            mskOtelTelefon.Text = "";
            mskYildiz.Text = "";
        }

        private void TemizleYorum()
        {
            txtYorumAd.Text = "";
            txtYorumSoyad.Text = "";
            txtYorumEposta.Text = "";
            rtbYorum.Text = "";
            mtbYorumPuan.Text = "";
            cmbOtelListesi.Text = " ";

        }
        public void dataGridDuzenle()
        {
            string aranan = mskTC.Text;
            for (int i = 0; i <= dgvPersonel.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dgvPersonel.Rows)
                {
                    foreach (DataGridViewCell cell in dgvPersonel.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString() == aranan)
                            {
                                dgvPersonel.Rows.RemoveAt(dgvPersonel.Rows[i].Index);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void btnOtelTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnOtelGuncelle_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Otel kayıt işlemini yapınız!");
                return;
            }

            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOtelAdiGuncelle.Text);
            if (dugum != null)
            {
                Otel otel = new Otel();
                try
                {
                   
                    otel.Ad = txtOtelAdiGuncelle.Text;
                    IkiliAramaAgac.Sil(otel.Ad);
                    foreach (DataGridViewRow row in dgvOtelListesi.SelectedRows)
                    {
                        dgvOtelListesi.Rows.Remove(row);
                    }     
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
                try
                {
                    otel.Ad = txtOtelAd.Text;
                    otel.Adres = txtOtelAdres.Text;
                    otel.BulunduguIl = cmbIl.Text;
                    otel.BulunduguIlce = cmbİlce.Text;
                    otel.Eposta = txtOtelEposta.Text;
                    otel.OdaSayisi = Convert.ToInt32(mskOdaSayisi.Text);
                    otel.Puani = 0;
                    otel.TelefonNo = mskOtelTelefon.Text;
                    otel.YildizSayisi = Convert.ToInt32(mskYildiz.Text);
                    IkiliAramaAgac.IsmeGoreOtelEkle(otel);
                    tablo.Rows.Add(otel.Ad, otel.Adres, otel.BulunduguIl, otel.BulunduguIlce, otel.Eposta, otel.OdaSayisi, otel.Puani, otel.TelefonNo, otel.YildizSayisi);
                    dgvOtelListesi.DataSource = tablo;

                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }

            }
            else
            {
                MessageBox.Show(txtOtelAd.Text + " Otel bulunamadı.");
            }
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {

            if (mskTC.Text != "" && txtOtelAdi.Text != "")
            {
                IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOtelAdi.Text);
                if (dugum.veri.personeller.Head != null)
                {
                    try
                    {
                        if (dugum.veri.personeller.VarMi(mskTC.Text) == true)
                        {
                            int pozisyon = dugum.veri.personeller.FindPosition(mskTC.Text);
                            dugum.veri.personeller.DeletePos(pozisyon);
                            dataGridDuzenle();
                            MessageBox.Show("Personel silindi.");
                            EkranHazirla();
                        }
                        else
                        {
                            MessageBox.Show("Personel bulunamadı.");
                            EkranHazirla();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }

                }
                else
                {
                    MessageBox.Show("Otele personel kayıt işlemini yapınız!");
                    return;

                }
            }
            else
            {
                MessageBox.Show("Silinecek personelin otel adını ve silinecek personel TC'sini giriniz.");
            }



        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            
            if (cmbDepartmanAra.SelectedIndex>=0 && txtOtelAdi.Text != "")
            {
                IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOtelAdi.Text);
                if (dugum.veri.personeller != null)
                {
                    try
                    {
                        txtPersonelListe.Text = "";
                        string liste=dugum.veri.personeller.DisplayElements(cmbDepartmanAra.Text);
                        txtPersonelListe.Text = liste;
                        EkranHazirla();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }

                }
                else
                {
                    MessageBox.Show("Otele personel kayıt işlemini yapınız!");
                    return;

                }
            }
            else
            {
                MessageBox.Show("Listelenecek personelin yer aldığı otel adını giriniz ve departmanını seciniz.");
            }
            


        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" && txtSoyad.Text != "" && mskTC.Text != "" && mskPersonelTelefon.Text != "" && txtPersonelAdres.Text != "" && cmbDepartman.Text != "" && cmbPozisyon.Text != "" && txtPersonelEposta.Text != "" && txtOtelAdi.Text != "")
            {
                IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOtelAdi.Text);
                if (dugum.veri.personeller != null)
                {
                    OtelPersonel otelPersonel = new OtelPersonel();
                    try
                    {
                       
                        int pozisyon = dugum.veri.personeller.FindPosition(mskTC.Text);
                        dugum.veri.personeller.DeletePos(pozisyon);
                        otelPersonel.Ad = txtAd.Text;
                        otelPersonel.Soyad = txtSoyad.Text;
                        otelPersonel.TCKimlikNo = mskTC.Text;
                        otelPersonel.TelefonNo = mskPersonelTelefon.Text;
                        otelPersonel.Adres = txtPersonelAdres.Text;
                        otelPersonel.Departman = cmbDepartman.Text;
                        otelPersonel.Pozisyon = cmbPozisyon.Text;
                        otelPersonel.Eposta = txtPersonelEposta.Text;
                        dugum.veri.personeller.InsertPos(pozisyon, otelPersonel);
                        dataGridDuzenle();
                        tabloPersonel.Rows.Add(otelPersonel.Ad, otelPersonel.Soyad, otelPersonel.TCKimlikNo, otelPersonel.TelefonNo, otelPersonel.Adres, otelPersonel.Departman, otelPersonel.Pozisyon, otelPersonel.Eposta);
                        dgvPersonel.DataSource = tabloPersonel;
                       
                    
                        MessageBox.Show("Personel güncelleme işlemi başarılı.");
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }

                }
                else
                {
                    MessageBox.Show("Otele personel kayıt işlemini yapınız!");
                    return;

                }
            }
            else
            {
                MessageBox.Show("Lütfen Otel adı dahil olmak üzere tüm alanları doldurunuz.");
            }

        }

        private void dgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dgvPersonel.CurrentRow.Cells[0].Value.ToString();
            txtSoyad.Text = dgvPersonel.CurrentRow.Cells[1].Value.ToString();
            mskTC.Text = dgvPersonel.CurrentRow.Cells[2].Value.ToString();
            mskPersonelTelefon.Text = dgvPersonel.CurrentRow.Cells[3].Value.ToString();
            txtPersonelAdres.Text = dgvPersonel.CurrentRow.Cells[4].Value.ToString();
            cmbDepartman.Text = dgvPersonel.CurrentRow.Cells[5].Value.ToString();
            cmbPozisyon.Text = dgvPersonel.CurrentRow.Cells[6].Value.ToString();
            txtPersonelEposta.Text = dgvPersonel.CurrentRow.Cells[7].Value.ToString();
        }

        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] mutfak = new string[] { "Aşçıbaşı", "Aşçı", "Aşçı Yardımcısı", "Alakart Aşçısı", "Pastacı", "Sıcak Mezeci", "Soğuk Mezeci", "Izgara Ustası", "Kahvaltı Hazılama Elemanı", "Bulaşıkçı" };
            string[] barmen_garson = new string[] { "Restoran Müdürü", "Restoran Şefi", "Şef Garson", "Barmen", "Barmate", "Barista", "Garson", "Komi" };
            string[] kat_odaTemzilik = new string[] { "Kat Müdürü", "Kat Hizmetleri Şefi", "Kat Hizmetleri Elemanı" };
            string[] halklaIliski = new string[] { "Otel Karşılama Görevlisi", "Halkla İlişkiler Müdürü", "Halkla İlişkiler Meslek Elemanı" };
            string[] canKurtaran_havuz = new string[] { "Havuz Temizleme Görevlisi", "Havuz Teknikeri", "Cankurtaran" };
            if (cmbDepartman.SelectedIndex == 0)
            {
                cmbPozisyon.Items.Clear();
                cmbPozisyon.Items.AddRange(mutfak);
            }
            if (cmbDepartman.SelectedIndex == 1)
            {
                cmbPozisyon.Items.Clear();
                cmbPozisyon.Items.AddRange(barmen_garson);
            }
            if (cmbDepartman.SelectedIndex == 2)
            {
                cmbPozisyon.Items.Clear();
                cmbPozisyon.Items.AddRange(kat_odaTemzilik);
            }
            if (cmbDepartman.SelectedIndex == 3)
            {
                cmbPozisyon.Items.Clear();
                cmbPozisyon.Items.AddRange(halklaIliski);
            }
            if (cmbDepartman.SelectedIndex == 4)
            {
                cmbPozisyon.Items.Clear();
                cmbPozisyon.Items.AddRange(canKurtaran_havuz);
            }


        }

        private void btnOdaOtelAra_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Otel kayıt işlemini yapınız!");
                return;
            }

            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOdaOtelAdi.Text);
            if (dugum != null)
            {
                MessageBox.Show(dugum.veri.Ad + " Otel bulundu");
                grpOda.Enabled = true;
                btnOtelOdaEkle.Enabled= true;
            }
            else
            {
                MessageBox.Show(txtOtelAdi.Text + " Otel bulunamadı.");
            }
        }

        private void dgvOdaBilgileri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mskOdaNo.Text = dgvOdaBilgileri.CurrentRow.Cells[0].Value.ToString();
            mskOdaTel.Text= dgvOdaBilgileri.CurrentRow.Cells[1].Value.ToString();
            mskKisiSayisi.Text= dgvOdaBilgileri.CurrentRow.Cells[2].Value.ToString();
            cmbManzara.Text= dgvOdaBilgileri.CurrentRow.Cells[3].Value.ToString();
            cmbRezervasyon.Text= dgvOdaBilgileri.CurrentRow.Cells[4].Value.ToString();
            mskFiyat.Text= dgvOdaBilgileri.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnOtelOdaEkle_Click(object sender, EventArgs e)
        {
            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOdaOtelAdi.Text);
            if (dugum.veri.OdaSayisi - 1 >= dugum.veri.odalar.Size)
            {
                if (mskOdaNo.Text != "" && mskOdaTel.Text != "" && mskKisiSayisi.Text != "" && cmbManzara.Text != "" && cmbRezervasyon.Text != "" && mskFiyat.Text != "")
                {
                    try
                    {
                        OtelOdasi otelOdasi = new OtelOdasi()
                        {
                            OdaNo = Convert.ToInt32(mskOdaNo.Text),
                            TelefonNo = mskOdaTel.Text,
                            KisiSayisi = Convert.ToInt32(mskKisiSayisi.Text),
                            ManzaraBilgisi = cmbManzara.Text,
                            RezarvasyonDurumu = cmbRezervasyon.Text,
                            Fiyat = Convert.ToInt32(mskFiyat.Text)

                        };
                        dugum.veri.odalar.InsertFirst(otelOdasi);
                        tabloOda.Rows.Add(otelOdasi.OdaNo, otelOdasi.TelefonNo, otelOdasi.KisiSayisi, otelOdasi.ManzaraBilgisi, otelOdasi.RezarvasyonDurumu, otelOdasi.Fiyat);
                        dgvOdaBilgileri.DataSource = tabloOda;
                        RezervasyonOdaListele.Rows.Add(dugum.veri.Ad, otelOdasi.OdaNo, otelOdasi.TelefonNo, otelOdasi.KisiSayisi, otelOdasi.ManzaraBilgisi, otelOdasi.RezarvasyonDurumu, otelOdasi.Fiyat);
                        dgvRezervasyonOdaListesi.DataSource = RezervasyonOdaListele;
                        GuncelleRezervasyonOdaListele.Rows.Add(dugum.veri.Ad, otelOdasi.OdaNo, otelOdasi.TelefonNo, otelOdasi.KisiSayisi, otelOdasi.ManzaraBilgisi, otelOdasi.RezarvasyonDurumu, otelOdasi.Fiyat);
                        dgvGuncelleOdaListesi.DataSource = GuncelleRezervasyonOdaListele;
                        MessageBox.Show("Kayıt Tamamlandı.");
                        OdaOtelEkranHazirla();

                    }



                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }

                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurunuz!");
                }

            }
            else
            {
                MessageBox.Show("Daha fazla oda ekleyemezsiniz.");
            }
            
        }

        private void btnOtelListele_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Öncelikle otel kayıt işlemi yapınız.");
            }
            else
            {
                if (cmbOtelILListe.Text != "" && cmbOtelIlceListe.Text != "" && cmbYildizSayisiListe.Text != "")
                {
                    IkiliAramaAgac.InOrderDeneme(cmbOtelILListe.Text, cmbOtelIlceListe.Text, Convert.ToInt32(cmbYildizSayisiListe.Text));
                    rtbOtelListe.Text = IkiliAramaAgac.DugumleriYazdir();
                }
                else
                {
                    MessageBox.Show("Tüm alanları doldurunuz.");
                }
            }

        }

        private void btnOtelOdaGuncelle_Click(object sender, EventArgs e)
        {

            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(txtOdaOtelAdi.Text);
            if (mskOdaNo.Text != "" && txtOdaOtelAdi.Text != "")
            {
                OtelOdasi otelOdasi = new OtelOdasi();
                try
                {
                    int pozisyon = dugum.veri.odalar.FindPosition(Convert.ToInt32(mskOdaNo.Text));
                    dugum.veri.odalar.DeletePos(pozisyon);
                    foreach (DataGridViewRow row in dgvOdaBilgileri.SelectedRows)
                    {
                        dgvOdaBilgileri.Rows.Remove(row);
                    }

                    otelOdasi.OdaNo = Convert.ToInt32(mskOdaNo.Text);
                    otelOdasi.TelefonNo = mskOdaTel.Text;
                    otelOdasi.KisiSayisi = Convert.ToInt32(mskKisiSayisi.Text);
                    otelOdasi.ManzaraBilgisi = cmbManzara.Text;
                    otelOdasi.RezarvasyonDurumu = cmbRezervasyon.Text;
                    otelOdasi.Fiyat = Convert.ToInt32(mskFiyat.Text);
                    dugum.veri.odalar.InsertPos(pozisyon, otelOdasi);

                    tabloOda.Rows.Add(otelOdasi.OdaNo, otelOdasi.TelefonNo, otelOdasi.KisiSayisi, otelOdasi.ManzaraBilgisi, otelOdasi.RezarvasyonDurumu, otelOdasi.Fiyat);
                    dgvOdaBilgileri.DataSource = tabloOda;

                    MessageBox.Show("Oda güncelleme işlemi başarılı.");
                    OdaOtelEkranHazirla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("Güncellenecek oda için oda no ve otel adını giriniz.");
            }

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            frmAnaGiris frmAna = new frmAnaGiris();
            frmAna.Show();
            this.Hide();
        }

    

        private void btnAgacDerinligi_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Ağaç üzerinde dolaşmak için öncelikle ağacı oluşturmalısınız!");
            }
            else
            {
                txtAgacDerinligi.Text = IkiliAramaAgac.AgacDerinlikSayisi().ToString();
            }
        }

        private void btnElemanSayisi_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Ağaç üzerinde dolaşmak için öncelikle ağacı oluşturmalısınız!");
            }
            else
            {
                txtElemanSayisi.Text = IkiliAramaAgac.ElemanSayisi().ToString();
            }
        }

        private void btnGezinmeYap_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Ağaç üzerinde dolaşmak için öncelikle ağacı oluşturmalısınız!");
            }
            else
            {
                switch (cmbGezinmeSekli.SelectedIndex)
                {
                    case 0:
                        IkiliAramaAgac.PreOrder();
                        break;
                    case 1:
                        IkiliAramaAgac.InOrder();
                        break;
                    case 2:
                        IkiliAramaAgac.PostOrder();
                        break;
                    default:
                        break;
                }
                lstOtelListesi.Items.Clear();
                lstOtelListesi.Items.Add(IkiliAramaAgac.DugumleriYazdir());

            }
        }
 
        private void dgvRezervasyonOdaListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mskRandevuOdaNo.Text= dgvRezervasyonOdaListesi.CurrentRow.Cells[1].Value.ToString();
            mskRandevuKisiSayisi.Text= dgvRezervasyonOdaListesi.CurrentRow.Cells[3].Value.ToString();
            txtRezervasyonOdaFiyat.Text= dgvRezervasyonOdaListesi.CurrentRow.Cells[6].Value.ToString();
            txtRezervasyonOtelAdi.Text = dgvRezervasyonOdaListesi.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnToplamFiyat_Click(object sender, EventArgs e)
        {
            try
            {
                if (mskRandevuGunSayisi.Text != "")
                {
                    toplam = Convert.ToInt32(txtRezervasyonOdaFiyat.Text) * Convert.ToInt32(mskRandevuGunSayisi.Text);
                    txtRandevuToplamUcret.Text = toplam.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen gün sayısını giriniz.");
            }
          
        }

        private void btnOtelleriListele_Click(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Kayıtlı otel bulunmamaktadır!");
                return;
            }


            else
            {
                if ((cmbListelemeKriteri.SelectedIndex >= 0))
                {

                    if (cmbListelemeKriteri.SelectedIndex == 0)
                    {

                        if (cmbIsmeGore.SelectedIndex < 0)
                        {
                            MessageBox.Show("Listelemek istediğiniz otel ismini seciniz!");
                            cmbIsmeGore.Focus();
                        }

                        else
                        {
                            rtbOtelListele.Text = " ";
                            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(cmbIsmeGore.Text);
                            rtbOtelListele.Text = "Otel Adı:" + dugum.veri.Ad + " " + "İl:" + dugum.veri.BulunduguIl + " " + "İlçe:" + dugum.veri.BulunduguIlce + " " + "Adresi:" + dugum.veri.Adres + " " + "Telefonu:" + dugum.veri.TelefonNo + " " + "Eposta:" + dugum.veri.Eposta + " " + "Oda Sayısı:" + dugum.veri.OdaSayisi + " " + "Yıldız Sayısı:" + dugum.veri.YildizSayisi +" "+ "Puanı:"+dugum.veri.Puani+"\n";
                            cmbIsmeGore.Text = " ";


                        }


                    }

                    if (cmbListelemeKriteri.SelectedIndex == 1)
                    {

                        if (cmbOtelIl.SelectedIndex < 0 || cmbOtelIlce.SelectedIndex < 0)
                        {
                            MessageBox.Show("Aradığınız il-ilçe bilgilerini seçiniz!");
                            cmbOtelIl.Focus();
                        }
                        else
                        {
                            IkiliAramaAgac.InOrderListeleme(cmbOtelIl.Text, cmbOtelIlce.Text);
                            rtbOtelListele.Text = IkiliAramaAgac.DugumleriYazdir();
                            cmbOtelIl.Text = cmbOtelIlce.Text = "";

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen listeleme kriterini seçiniz!");
                    cmbListelemeKriteri.Focus();
                }
            }
        }


        private void btnGonder_Click(object sender, EventArgs e)
        {
            IkiliAramaAgacDugumu dugum = IkiliAramaAgac.Ara(cmbOtelListesi.Text);
            if (dugum != null)
            {
                if (txtYorumAd.Text != "" && cmbOtelListesi.Text != "" && txtYorumSoyad.Text != "" && txtYorumEposta.Text != "" && rtbYorum.Text != "")
                {
                    try
                    {
                        //int varMi = dugum.veri.yorumlar.FindPosition(txtYorumEposta.Text);
                        OtelYorum otelYorum = new OtelYorum();


                        if (dugum.veri.yorumlar.VarMi(txtYorumEposta.Text) == false)
                        {
                            otelYorum.YorumSahibiAd = txtYorumAd.Text;
                            otelYorum.YorumSahibiSoyad = txtYorumSoyad.Text;
                            otelYorum.YorumSahibiEposta = txtYorumEposta.Text;
                            otelYorum.Yorumu = rtbYorum.Text;
                            otelYorum.Puani = Convert.ToInt32(mtbYorumPuan.Text);
                            dugum.veri.yorumlar.InsertFirst(otelYorum);
                            MessageBox.Show("Yorumunuz Gönderildi!");
                           
                        }
                        else
                        {
                            otelYorum.YorumSahibiAd = txtYorumAd.Text;
                            otelYorum.YorumSahibiSoyad = txtYorumSoyad.Text;
                            otelYorum.YorumSahibiEposta = txtYorumEposta.Text;
                            otelYorum.Yorumu = rtbYorum.Text;
                            otelYorum.Puani = -1;
                            dugum.veri.yorumlar.InsertFirst(otelYorum);
                            MessageBox.Show("Yorumunuz Gönderildi!");
                            MessageBox.Show("Tekrar puan veremezsiniz.");
                        }

                        //TemizleYorum();

                        dugum.veri.Puani = 0;
                        float puan = dugum.veri.yorumlar.OtelPuaniHesapla();
                        dugum.veri.Puani = puan;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem Başarısız.Hata" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }
                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurun!");
                }
            }
            else
            {
                MessageBox.Show("Otel bulunamadı.");
            }

        }

        private void btnOtelListele_Click_1(object sender, EventArgs e)
        {
            if (IkiliAramaAgac == null)
            {
                MessageBox.Show("Öncelikle otel kayıt işlemi yapınız.");
            }
            else
            {
                if (cmbOtelILListe.Text != "" && cmbOtelIlceListe.Text != "" && cmbYildizSayisiListe.Text != "")
                {
                    IkiliAramaAgac.InOrderDeneme(cmbOtelILListe.Text, cmbOtelIlceListe.Text, Convert.ToInt32(cmbYildizSayisiListe.Text));
                    rtbOtelListe.Text = IkiliAramaAgac.DugumleriYazdir();
                }
                else
                {
                    MessageBox.Show("Tüm alanları doldurunuz.");
                }
            }
        }

        private void cmbListelemeKriteri_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbListelemeKriteri.SelectedIndex == 0)
            {
                grpIlveIlce.Visible = false;
                lblIsmeGore.Visible = cmbIsmeGore.Visible = true;

            }
            if (cmbListelemeKriteri.SelectedIndex == 1)
            {
                lblIsmeGore.Visible = cmbIsmeGore.Visible = false;
                grpIlveIlce.Location = new Point(50, 110);
                grpIlveIlce.Visible = true;
            }

        }

        private void btnYorumTemizle_Click(object sender, EventArgs e)
        {
            TemizleYorum();
        }

        private void btnRezervasyonAl_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtMusteriTC.Text!="" && txtMusteriAd.Text!=""&& txtMusteriSoyad.Text!=""&& txtMusteriAdres.Text!=""&& mskMusteriTel.Text!=""&& txtMusteriEposta.Text!=""&& txtRezervasyonOtelAdi.Text!=""&& mskRandevuOdaNo.Text!=""&& mskRandevuKisiSayisi.Text!=""&& mskRandevuGunSayisi.Text!=""&& txtRandevuToplamUcret.Text != "")
                {
                    RezervasyonMusteri musteri = new RezervasyonMusteri();
                    int musteriNo = 200 + j;
                    musteri.MusteriNo = musteriNo;
                    j++;
                    musteri.TCKimlikNo = txtMusteriTC.Text;
                    musteri.Ad = txtMusteriAd.Text;
                    musteri.Soyad = txtMusteriSoyad.Text;
                    musteri.Adres = txtMusteriAdres.Text;
                    musteri.TelefonNo = mskMusteriTel.Text;
                    musteri.Eposta = txtMusteriEposta.Text;
                    txtAdVeSoyad.Text = txtMusteriAd.Text+" "+txtMusteriSoyad.Text;
                    musteri.AdVeSoyad = txtAdVeSoyad.Text;
                    hashMusteriler.MusteriEkle(musteri.MusteriNo, musteri);

                    Rezervasyon rezervasyon = new Rezervasyon();
                    int rezervasyonNo = 250 + i;
                    rezervasyon.RezervasyonNo = rezervasyonNo;
                    i++;
                    rezervasyon.OtelAd = txtRezervasyonOtelAdi.Text;
                    rezervasyon.OdaNo = Convert.ToInt32(mskRandevuOdaNo.Text);
                    rezervasyon.KisiSayisi = Convert.ToInt32(mskRandevuKisiSayisi.Text);
                    rezervasyon.GunSayisi = Convert.ToInt32(mskRandevuGunSayisi.Text);
                    rezervasyon.ToplamUcret = Convert.ToInt32(txtRandevuToplamUcret.Text);
                    hashRezervasyonlar.RezervasyonEkle(rezervasyon.RezervasyonNo, rezervasyon);
                    heap.Insert(musteri);
                    MessageBox.Show("Kayıt işlemi başarılı");
                    MessageBox.Show("Müşteri Numaranız:" + musteriNo + " Rezervasyon Numaranız:" + rezervasyonNo);
                    RezervasyonAlEkranTemizleme();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik bilgi girdiniz lütfen kontrol ediniz.");
            }
           
        }
        private void RezervasyonAlEkranTemizleme()
        {
            txtMusteriTC.Text = "";
            txtMusteriAd.Text = "";
            txtMusteriSoyad.Text="";
            txtMusteriAdres.Text="";
            mskMusteriTel.Text="";
            txtMusteriEposta.Text="";
            txtRezervasyonOtelAdi.Text="";
            mskRandevuOdaNo.Text = "";
            mskRandevuKisiSayisi.Text = "";
            mskRandevuGunSayisi.Text = "";
            txtRandevuToplamUcret.Text = "";
        }

        private void btnGuncelleToplamFiyat_Click(object sender, EventArgs e)
        {
            try
            {
                if(mskGuncelleRezervasyonGunSayisi.Text != "")
                {
                    toplam = Convert.ToInt32(txtGuncelleOdaFiyat.Text) * Convert.ToInt32(mskGuncelleRezervasyonGunSayisi.Text);
                    txtGuncelleRezervasyonToplamUcret.Text = toplam.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen gün sayısını giriniz");
            }
            
        }

        private void btnGuncelleRezervasyonAra_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtGuncelleMusteriNo.Text!=""&& txtGuncelleRezervasyonNo.Text != "")
                {
                    hashMusteriler.MusteriGetir(Convert.ToInt32(txtGuncelleMusteriNo.Text));
                    hashRezervasyonlar.RezervasyonGetir(Convert.ToInt32(txtGuncelleRezervasyonNo.Text));
                    grpGuncelleMusteriBilgileri.Enabled = true;
                    grpGuncelleRezervasyonBilgileri.Enabled = true;

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Rezervasyon bulunamadı");
            }
        }

        private void dgvGuncelleOdaListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGuncelleRezervasyonOtelAd.Text = dgvGuncelleOdaListesi.CurrentRow.Cells[0].Value.ToString();
            mskGuncelleRezervasyonOdaNo.Text = dgvGuncelleOdaListesi.CurrentRow.Cells[1].Value.ToString();
            mskGuncelleRezervasyonKisiSayisi.Text = dgvGuncelleOdaListesi.CurrentRow.Cells[3].Value.ToString();
            txtGuncelleOdaFiyat.Text = dgvGuncelleOdaListesi.CurrentRow.Cells[6].Value.ToString();

        }

        private void btnRandevuGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                hashRezervasyonlar.RezervasyonKaldir(Convert.ToInt32(txtGuncelleRezervasyonNo.Text));
                hashMusteriler.MusteriKaldir(Convert.ToInt32(txtGuncelleMusteriNo.Text));
             
                if(txtGuncelleMusteriTC.Text!="" && txtGuncelleMusteriAd.Text!=""&& txtGuncelleMusteriSoyad.Text!=""&& txtGuncelleMusteriAdres.Text!=""&& mskGuncelleMusteriTel.Text!=""&& txtGuncelleMusteriEposta.Text!=""&& txtGuncelleRezervasyonOtelAd.Text!=""&& mskGuncelleRezervasyonOdaNo.Text!=""&& mskGuncelleRezervasyonKisiSayisi.Text!=""&& txtGuncelleRezervasyonToplamUcret.Text != "")
                {
                    RezervasyonMusteri musteri = new RezervasyonMusteri();
                    int musteriNo = 200 + j;
                    musteri.MusteriNo = musteriNo;
                    j++;
                    musteri.TCKimlikNo = txtGuncelleMusteriTC.Text;
                    musteri.Ad = txtGuncelleMusteriAd.Text;
                    musteri.Soyad = txtGuncelleMusteriSoyad.Text;
                    musteri.Adres = txtGuncelleMusteriAdres.Text;
                    musteri.TelefonNo = mskGuncelleMusteriTel.Text;
                    musteri.Eposta = txtGuncelleMusteriEposta.Text;
                    hashMusteriler.MusteriEkle(musteri.MusteriNo, musteri);

                    Rezervasyon rezervasyon = new Rezervasyon();
                    int rezervasyonNo = 250 + i;
                    rezervasyon.RezervasyonNo = rezervasyonNo;
                    i++;
                    rezervasyon.OtelAd = txtGuncelleRezervasyonOtelAd.Text;
                    rezervasyon.OdaNo = Convert.ToInt32(mskGuncelleRezervasyonOdaNo.Text);
                    rezervasyon.KisiSayisi = Convert.ToInt32(mskGuncelleRezervasyonKisiSayisi.Text);
                    rezervasyon.GunSayisi = Convert.ToInt32(mskGuncelleRezervasyonGunSayisi.Text);
                    rezervasyon.ToplamUcret = Convert.ToInt32(txtGuncelleRezervasyonToplamUcret.Text);
                    hashRezervasyonlar.RezervasyonEkle(rezervasyon.RezervasyonNo, rezervasyon);

                    MessageBox.Show("Guncelleme işlemi başarılı");
                }
              

            }
            catch (Exception)
            {
                MessageBox.Show("Eksik veya yanlış bilgi girdiniz.");
            }
        }

        private void btnRezervasyonSil_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSilRezervasyonNo.Text!="" && txtSilMusteriNo.Text != "")
                {
                    hashRezervasyonlar.RezervasyonKaldir(Convert.ToInt32(txtSilRezervasyonNo.Text));
                    hashMusteriler.MusteriKaldir(Convert.ToInt32(txtSilMusteriNo.Text));
                    MessageBox.Show("Rezervasyon Silme işlemi başarılı");
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik veya yanlış bilgi girdiniz.");
            }
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            List<RezervasyonMusteri> rezervasyonMusteris = heap.RezervasyonAl();
            HeapSort hs = new HeapSort(rezervasyonMusteris);
            object[] sorted = hs.Sort();
            lstMusteriListesi.Items.Clear();
            foreach (var item in sorted)
            {
                lstMusteriListesi.Items.Add(item.ToString()+ ",");
            }
        }

      
    }
}
