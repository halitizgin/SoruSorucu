using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        long gsayi1 = 0;
        long gsayi2 = 0;
        string gislem = "";
        int gpuan = 0;
        int soru = 0;
        int gsoru = 0;
        int dsayi = 0;
        int ysayi = 0;
        bool durum = false;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kalan = Convert.ToInt32(label2.Text);
            int eklenecek = 10;
            long sonuc = 0;
            if (gsayi1 == 0 && gsayi2 == 0 && gislem == "")
            {
                MessageBox.Show("Soru cevaplayamazsınız. Hata Bulundu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gsoru++;
                durum = false;
                if (gislem == "")
                {
                    sonuc = gsayi1 + gsayi2;
                }
                else
                {
                    sonuc = gsayi1 - gsayi2;
                }
                long bildirim_sonuc = sonuc;
                if (Convert.ToInt64(textBox1.Text) == sonuc)
                {
                    dsayi++;
                    soru++;
                    timer1.Enabled = false;
                    DateTime tarih = DateTime.Now;
                    int bildirim_kalan = kalan;
                    long bildirim_gsayi1 = gsayi1;
                    long bildirim_gsayi2 = gsayi2;
                    string bildirim_gislem = gislem;
                    label2.Text = "0";
                    gsayi1 = 0;
                    gsayi2 = 0;
                    gislem = "";
                    label1.Text = "İşlem";
                    textBox1.Text = "";
                    if (kalan > 0 && kalan < 10)
                    {
                        eklenecek = 5;
                    }
                    else if (kalan >= 10 && kalan < 20)
                    {
                        eklenecek = 10;
                    }
                    else if (kalan >= 20 && kalan < 30)
                    {
                        eklenecek = 15;
                    }
                    else if (kalan >= 30 && kalan <= 35)
                    {
                        eklenecek = 25;
                    }
                    else if (kalan >= 35 && kalan <= 40)
                    {
                        eklenecek = 40;
                    }
                    else
                    {
                        MessageBox.Show("Puan eklemede bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    gpuan += eklenecek;
                    int bildirim_eklenecek = eklenecek;
                    label3.Text = "Puanınız: " + gpuan;

                    if (richTextBox1.Text != "")
                    {
                        richTextBox1.Text = richTextBox1.Text + "\n" + soru + ". İşlem: \"" + bildirim_gsayi1 + " " + bildirim_gislem + " " + bildirim_gsayi2 + " = " + bildirim_sonuc + "\" - " + bildirim_kalan + " saniye kala, doğru cevaba " + bildirim_eklenecek + " puan verildi. | Tarih ve Saat: " + tarih;
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + soru + ". İşlem: \"" + bildirim_gsayi1 + " " + bildirim_gislem + " " + bildirim_gsayi2 + " = " + bildirim_sonuc + "\" - " + bildirim_kalan + " saniye kala, doğru cevaba " + bildirim_eklenecek + " puan verildi. | Tarih ve Saat: " + tarih;
                    }

                    MessageBox.Show("Verdiğiniz cevap doğru.", "Doğru", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (gsoru == 20)
                    {
                        double yuzde = ((double)dsayi / 20) * 100;
                        MessageBox.Show("20 sorunuzu doldurdunuz.\n" + label3.Text + "\nDoğru Sayısı: " + dsayi + "\nYanlış Sayısı: " + ysayi + "\nBaşarı Yüzdeniz: " + "%" + yuzde, "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gpuan = 0;
                        dsayi = 0;
                        ysayi = 0;
                        durum = false;
                        soru = 0;
                        gsoru = 0;
                        label3.Text = "Puanınız: 0";
                        label2.Text = "0";
                    }
                }
                else
                {
                    ysayi++;
                    soru++;
                    timer1.Enabled = false;
                    DateTime tarih = DateTime.Now;
                    int bildirim_kalan = kalan;
                    long bildirim_gsayi1 = gsayi1;
                    long bildirim_gsayi2 = gsayi2;
                    string bildirim_gislem = gislem;
                    label2.Text = "0";
                    gsayi1 = 0;
                    gsayi2 = 0;
                    gislem = "";
                    label1.Text = "İşlem";
                    textBox1.Text = "";
                    gpuan -= 10;
                    label3.Text = "Puanınız: " + gpuan;
                    if (richTextBox1.Text != "")
                        richTextBox1.Text = richTextBox1.Text + "\n" + soru + ". İşlem: \"" + bildirim_gsayi1 + " " + bildirim_gislem + " " + bildirim_gsayi2 + " = " + bildirim_sonuc + "\" - " + bildirim_kalan + " saniye kala, yanlış cevaba 10 puan kesildi. | Tarih ve Saat: " + tarih;
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + soru + ". İşlem: \"" + bildirim_gsayi1 + " " + bildirim_gislem + " " + bildirim_gsayi2 + " = " + bildirim_sonuc + "\" - " + bildirim_kalan + " saniye kala, yanlış cevaba 10 puan kesildi. | Tarih ve Saat: " + tarih;
                    }
                    MessageBox.Show("Verdiğiniz cevap yanlış.", "Yanlış", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Bilemediğiniz işlem:\n" + bildirim_gsayi1 + " " + bildirim_gislem + " " + bildirim_gsayi2 + " = " + bildirim_sonuc, "Bilgi");
                    if (gsoru == 20)
                    {
                        double yuzde = ((double)dsayi / 20) * 100;
                        MessageBox.Show("20 sorunuzu doldurdunuz.\n" + label3.Text + "\nDoğru Sayısı: " + dsayi + "\nYanlış Sayısı: " + ysayi + "\nBaşarı Yüzdeniz: " + "%" + yuzde, "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gpuan = 0;
                        dsayi = 0;
                        ysayi = 0;
                        durum = false;
                        soru = 0;
                        gsoru = 0;
                        label3.Text = "Puanınız: 0";
                        label2.Text = "0";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (durum == true)
            {
                MessageBox.Show("Soru zaten sorulmuş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                durum = true;
                string islem = "";
                Random rsayi = new Random();

                int sayi1 = rsayi.Next(1, 100);
                int sayi2 = rsayi.Next(1, 100);
                gsayi1 = sayi1;
                gsayi2 = sayi2;
                int nIslem = rsayi.Next(1, 100);
                if (nIslem % 2 == 0)
                {
                    islem = "+";
                }
                else
                {
                    islem = "-";
                }

                gislem = islem;
                label1.Text = sayi1 + " " + islem + " " + sayi2 + " = ";
                timer1.Enabled = true;
                label2.Text = "40";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int kalan = Convert.ToInt32(label2.Text);
            kalan--;
            if (kalan == 0)
            {
                timer1.Enabled = false;
                durum = false;
                gpuan -= 5;
                DateTime tarih = DateTime.Now;
                label3.Text = "Puanınız: " + gpuan;
                long sonuc = 0;
                if (gislem == "+")
                {
                    sonuc = gsayi1 + gsayi2;
                }
                else if (gislem == "-")
                {
                    sonuc = gsayi1 - gsayi2;
                }

                if (richTextBox1.Text != "")
                {
                    richTextBox1.Text = richTextBox1.Text + "\n" + "İşlem: \"" + gsayi1 + " " + gislem + " " + gsayi2 + " = " + sonuc + "\" - süre doldu, kullanıcıya 5 puan kesildi. | Tarih ve Saat: " + tarih;
                }
                else
                {
                    richTextBox1.Text = richTextBox1.Text + "İşlem: \"" + gsayi1 + " " + gislem + " " + gsayi2 + " = " + sonuc + "\" - süre doldu, kullanıcıya 5 puan kesildi. | Tarih ve Saat: " + tarih;
                }
                MessageBox.Show("Süreniz doldu.", "Süre Doldu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            label2.Text = kalan.ToString();
        }
    }
}
