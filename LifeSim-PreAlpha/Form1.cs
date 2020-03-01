using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeSim
{
    public partial class Form1 : Form
    {
        int yas = 1;
        int mevsim = 0;
        string egitim = "Yok";
        int para = 0;
        bool universitedurumu = false;
        Ev ev = new Ev("Evsiz", -4, -5, 50000000);
        Ev apartman = new Ev("Apartman", 0, 2, 80000);
        Ev villa = new Ev("Villa", 2, 4, 400000);
        Ev sato = new Ev("Şato", 10, 8, 999999);
        Araba araba = new Araba("Yok", -2, 0);
        Araba sedan = new Araba("Sedan", 4, 50000);
        Araba spor = new Araba("Spor Araba", 8, 700000);
        Meslek m = new Meslek("İşsiz", 0, 0);
        Meslek Taksici = new Meslek("Taksici", 2020, 3);
        Meslek Kasiyer = new Meslek("Kasiyer", 2020, 4);
        Meslek Dilenci = new Meslek("Dilenci", 0, 3);
        Meslek Muzisyen = new Meslek("Müzisyen", 3500, 8);
        Meslek Yazilimci = new Meslek("Yazılımcı", 4000, 9);
        Meslek Ressam = new Meslek("Ressam", 3000, 8);
        Meslek Doktor = new Meslek("Doktor", 5400, 10);
        Meslek Yazar = new Meslek("Yazar", 3000, 8);
        int saglik = 100;
        int akilsagligi = 100;

        public Araba Jeep { get; set; } = new Araba("Jeep", 6, 300000);

        public Form1()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            Meslek meslek = new Meslek("İşsiz", 2, 0);
            meslek = m;
            Meslek issiz = new Meslek("İşsiz", 4, 0);
            Ev evsiz = new Ev("Evsiz", -2, -8, 0);
            evsiz = ev;
            Araba arabasiz = new Araba("Yok", -1, 0);
            arabasiz = araba;
            Random rnd = new Random();
            int cinsiyetDegeri = rnd.Next(0, 2);
            string[] ulkeler = { "Türkiye", "ABD", "Çin", "Rusya", "Japonya", "Hindistan" };
            int ulkeNo = rnd.Next(0, ulkeler.Length);
            Insan insan = new Insan("", 50000, yas, m, cinsiyetDegeri, false, ulkeler[ulkeNo], ev, araba);
            yas = insan.yas;
            para = insan.Para;
            ev = insan.Ev;
            araba = insan.Araba;
            lblPara.Text = para.ToString() + "₺";
            if (insan.Cinsiyet == 1)
            {
                string[] isimlerErkek = { "Aydın Seçer" };
                int isimNo = rnd.Next(0, isimlerErkek.Length);
                insan.Ad = isimlerErkek[isimNo];
                picErkek.Show();
                picKadın.Hide();
                lblCinsiyet.Text = "Erkek";
            }
            else
            {
                string[] isimlerKadın = { "Müberra Demir", "Zeliha Kaya", "Cansu Tezel", "Elham Pashei", "Eyşan Tezcan", "Ayşe Fatma Hayriye", "Sedanur Yamaç" };
                int isimNo = rnd.Next(0, isimlerKadın.Length);
                insan.Ad = isimlerKadın[isimNo];
                picErkek.Hide();
                picKadın.Show();
                lblCinsiyet.Text = "Kadın";
            }
            lblYas.Text = insan.Yas.ToString();
            lblIsım.Text = insan.Ad;
            lblMaas.Text = insan.Meslek.Maas.ToString();
            lblMeslek.Text = insan.Meslek.Meslekismi;
            lblUlke.Text = insan.Ulke;
            lblEgitim.Text = egitim;
            lblEv.Text = ev.Tür;
            lblAraba.Text = araba.Tür;
            lblHealthValue.Text ="%"+ saglik.ToString();
            lblZihin.Text = "%"+akilsagligi.ToString();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            //Random olaylar
            Random rnd = new Random();
            int olay = rnd.Next(1, 150);
            //Olumsuz olaylar
            if (olay == 1)
            {
                MessageBox.Show("Kanser oldun! \n Sağlık:-20,Akıl Sağlığı:-20", "Olay");
                progressBar1.Value = progressBar1.Value - 20;
                if (progressBar2.Value - 20 < 0)
                {
                    MessageBox.Show("Araba kazasında öldün!");
                    this.Close();
                }
                progressBar2.Value = progressBar2.Value - 20;
                lblHealthValue.Text = "%" + progressBar1.Value.ToString();
                lblZihin.Text = "%" + progressBar2.Value.ToString();
            }
            if (olay == 2)
            {
                MessageBox.Show("Yakın bir arkadaşın öldü.. \nAkıl Sağlığı:-15", "Olay");
                progressBar2.Value = progressBar2.Value - 15;
                lblZihin.Text = "%"+progressBar2.Value.ToString();
            }
            if (olay == 3)
            {
                MessageBox.Show("Uykunda kalp krizi geçirdin.\n..", "Olay");
                this.Close();
            }
            if (olay == 4 && m.Maas != 0)
            {
                MessageBox.Show("Patronun performansını beğenmedi..\nMaaş:-500", "Olay");
                m.Maas -= 500;
                lblMaas.Text = m.Maas.ToString();
            }
            if (olay == 5 && araba.Tür != "Yok")
            {
                MessageBox.Show("Araba ile kaza yaptın..Artık araban yok!\n Sağlık:-10", "Olay");
                araba.Fiyat = 0;
                araba.Tür = "Yok";
                progressBar1.Value = progressBar1.Value - 10;
                lblHealthValue.Text = "%" + progressBar1.Value.ToString();
                lblAraba.Text = araba.Tür;
            }
            //Olumlu Olaylar
            if (olay == 1)
            {
                MessageBox.Show("Piyango kazandın! \n Para:+75k₺", "Olay");
                para += 75000;
                lblPara.Text = para.ToString()+"₺";
            }
            if (olay == 2 && m.Maas != 0)
            {
                MessageBox.Show("Terfi aldın..\nMaaş:+500₺");
                m.Maas += 500;
                lblMaas.Text = m.Maas.ToString();
            }
            if (olay == 3)
            {
                MessageBox.Show("");
            }
            mevsim += 1;
            //Para işlemleri
            para += m.Maas * 3;
            lblPara.Text = para.ToString() + "₺";
            if (para <= -500000)
            {
                MessageBox.Show("Çok fazla borcun olduğu için intihar ettin!");
                this.Close();
            }
            //Her yıl olacak şeyler
            if (mevsim == 4)
            {
                lblPara.Text = para.ToString() + "₺";
                //Akıl Sağlığı İşlemleri
                if (progressBar2.Value - m.Akilsagligi + ev.Zihin + araba.Zihin > 100)
                {
                    progressBar2.Value = 100;
                }
                else if (progressBar2.Value - m.Akilsagligi + ev.Zihin + araba.Zihin <= 0)
                {
                    progressBar2.Value = 0;
                    MessageBox.Show("Öldünüz..");
                    this.Close();
                }
                else
                {
                    progressBar2.Value = progressBar2.Value - m.Akilsagligi + ev.Zihin + araba.Zihin;
                    lblZihin.Text = "%" + progressBar2.Value.ToString();
                }
                //Can işlemleri
                if (progressBar1.Value + ev.Can > 100)
                {
                    progressBar1.Value = 100;
                    lblZihin.Text = "%" + progressBar1.Value.ToString();
                }
                else if (progressBar1.Value + ev.Can <= 0)
                {
                    progressBar1.Value = 0;
                    MessageBox.Show("Öldünüz..");
                    this.Close();
                }
                else
                {
                    progressBar1.Value = progressBar1.Value + ev.Can;
                    lblHealthValue.Text = "%" + progressBar1.Value.ToString();
                }
                //Rütbe İşlemleri
                if (m.Deneyim == 0)
                {
                    lblRutbe.Text = "Çaylak " + m.Meslekismi;
                    lblMaas.Text = m.Maas.ToString();
                }
                if (m.Deneyim == 7)
                {
                    lblRutbe.Text = "İyi " + m.Meslekismi;
                    m.Maas = m.Maas * 2;
                    lblMaas.Text = m.Maas.ToString();
                }
                if (m.Deneyim == 12)
                {
                    lblRutbe.Text = "Uzman " + m.Meslekismi;
                    m.Maas += m.Maas * 2;
                    lblMaas.Text = m.Maas.ToString();
                }
                yas += 1;
                mevsim = 0;
                lblYas.Text = yas.ToString();
                //Meslek işlemleri
                m.Deneyim += 1;
            }
            /*
            if (yas == 1 && mevsim == 1)
            {

                MessageBox.Show("Sol üstte can ve akıl sağlığı göstergeleri bulunur.Canın 0 a düşerse ölürsün...", "Bilgi", MessageBoxButtons.OK);
            }
            if (yas == 1 && mevsim == 3)
            {

                MessageBox.Show("Profil sekmesinden kendin hakkında bilgileri edinebilirsin...", "Bilgi", MessageBoxButtons.OK);
            }
            */
            if (yas == 15 && mevsim == 0)
            {
                MessageBox.Show("Artık yarı zamanlı işlerde çalışabilirsin!");
            }
        }

        //GroupBox İşlemleri
        private void picProfil_Click(object sender, EventArgs e)
        {
            picProfil.BackColor = Color.OrangeRed;
            grpMeslek.Hide(); picIs.BackColor = Color.Transparent;
            grpProfil.Show();
            grpEgitim.Hide(); picEgitim.BackColor = Color.Transparent;
            grpMarket.Hide(); picMarket.BackColor = Color.Transparent;
        }
        private void picIs_Click(object sender, EventArgs e)
        {
            picIs.BackColor = Color.OrangeRed;
            grpProfil.Hide(); picProfil.BackColor = Color.Transparent;
            grpMeslek.Show();
            grpEgitim.Hide(); picEgitim.BackColor = Color.Transparent;
            grpMarket.Hide(); picMarket.BackColor = Color.Transparent;
        }
        private void picEgitim_Click(object sender, EventArgs e)
        {
            picEgitim.BackColor = Color.OrangeRed;
            grpProfil.Hide(); picProfil.BackColor = Color.Transparent;
            grpMeslek.Hide(); picIs.BackColor = Color.Transparent;
            grpMarket.Hide(); picMarket.BackColor = Color.Transparent;
            grpEgitim.Show();
        }
        private void picMarket_Click_1(object sender, EventArgs e)
        {
            picMarket.BackColor = Color.OrangeRed;
            grpProfil.Hide(); picProfil.BackColor = Color.Transparent;
            grpMeslek.Hide(); picIs.BackColor = Color.Transparent;
            grpEgitim.Hide(); picEgitim.BackColor = Color.Transparent;
            grpMarket.Show();
        }
        private void picBanka_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yakında...");
        }
        private void picSosyal_Click_1(object sender,EventArgs e)
        {
            MessageBox.Show("Yakında..");
        }
        //Meslek İşlemleri
        private void taksiciBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(m, Taksici, yas) == true)
            {
                lblMeslek.Text = Taksici.Meslekismi;
                lblMaas.Text = Taksici.Maas.ToString() + "₺";
            }
        }

        private void kasiyerBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(m, Kasiyer, yas) == true)
            {
                lblMeslek.Text = Kasiyer.Meslekismi;
                lblMaas.Text = Kasiyer.Maas.ToString() + "₺";
            }
        }

        private void dilenciBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(m, Dilenci, yas) == true)
            {
                lblMeslek.Text = Dilenci.Meslekismi;
                lblMaas.Text = Dilenci.Maas.ToString() + "₺";
            }
        }

        private void muzisyenBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(universitedurumu, m, Muzisyen, yas) == true)
            {
                lblMeslek.Text = Muzisyen.Meslekismi;
                lblMaas.Text = Muzisyen.Maas.ToString() + "₺";
            }
        }

        private void yazilimciBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(universitedurumu, m, Yazilimci, yas) == true)
            {
                lblMeslek.Text = Yazilimci.Meslekismi;
                lblMaas.Text = Yazilimci.Maas.ToString() + "₺";
            }
        }

        private void ressamBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(universitedurumu, m, Ressam, yas) == true)
            {
                lblMeslek.Text = Ressam.Meslekismi;
                lblMaas.Text = Ressam.Maas.ToString() + "₺";
            }
        }

        private void doktorBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(universitedurumu, m, Doktor, yas) == true)
            {
                lblMeslek.Text = Doktor.Meslekismi;
                lblMaas.Text = Doktor.Maas.ToString() + "₺";
            }
        }

        private void yazarBasvur_Click(object sender, EventArgs e)
        {
            if (meslekDegistir(universitedurumu, m, Yazar, yas) == true)
            {
                lblMeslek.Text = Yazar.Meslekismi;
                lblMaas.Text = Yazar.Maas.ToString() + "₺";

            }
        }
        static bool meslekDegistir(Meslek meski, Meslek myeni, int yas)
        {
            if (yas < 15)
            {
                MessageBox.Show("Henüz yarı zamanlı bir işte çalışacak kadar büyümedin!");
                return false;
            }
            else
            {
                meski.Meslekismi = myeni.Meslekismi;
                meski.Maas = myeni.Maas;
                meski.Akilsagligi = myeni.Akilsagligi;
                meski.Deneyim = 0;
                return true;
            }
        }
        static bool meslekDegistir(bool universitedurumu, Meslek meski, Meslek myeni, int yas)
        {
            if (yas < 20)
            {
                MessageBox.Show("Henüz tam zamanlı bir işte çalışacak kadar büyümedin!");
                return false;
            }
            else
            {
                if (universitedurumu == true)
                {
                    meski.Meslekismi = myeni.Meslekismi;
                    meski.Maas = myeni.Maas;
                    meski.Akilsagligi = myeni.Akilsagligi;
                    meski.Deneyim = 0;
                    return true;
                }
                else
                {
                    MessageBox.Show("Bu mesleği yapabilmek için üniversiteyi bitirmelisin");
                    return false;
                }
            }
        }
        //Eğitim İşlemleri
        private void btnUni_Click(object sender, EventArgs e)
        {
            if (egitim != "Lise" && egitim != "Üniversite")
            {
                MessageBox.Show("Üniversite okuyabilmek için önce liseyi bitirmelisin");
            }
            else if (egitim == "Lise" && para > 40000 && akilsagligi > 70)
            {
                egitim = "Üniversite";
                lblEgitim.Text = egitim;
                para -= 40000;
                akilsagligi -= 10;
                lblPara.Text = para.ToString() + "₺";
                universitedurumu = true;
            }
        }
        private void btnIlkokul_Click_1(object sender, EventArgs e)
        {
            if (yas < 7)
            {
                MessageBox.Show("Henüz 7 yaşına gelmedin..");
            }
            else if (egitim == "İlkokul" || egitim == "Lise" || egitim == "Üniversite")
            {
                MessageBox.Show("İlkokulu zaten okudun!");
            }
            else
            {
                egitim = "İlkokul";
                lblEgitim.Text = egitim;
                yas += 8;
                lblYas.Text = yas.ToString();
            }
        }
        private void btnLise_Click(object sender, EventArgs e)
        {
            if (egitim != "İlkokul" && egitim != "Üniversite")
            {
                MessageBox.Show("Liseyi okuyabilmek için önce İlkokul'u bitirmen gerekli!");
            }
            else if (egitim == "Lise" || egitim == "Üniversite")
            {
                MessageBox.Show("Liseyi zaten okudun!");
            }
            else
            {
                egitim = "Lise";
                lblEgitim.Text = egitim;
                yas += 4;
                lblYas.Text = yas.ToString();
            }
        }
        //Ev İşlemleri
        public void btnKiralaApt_Click(object sender, EventArgs e)
        {
            if (evdegistir(ev, apartman, yas, para) == true)
            {
                evdegistir(ev, apartman);
                lblEv.Text = ev.Tür;
                btnKiralaApt.BackColor = Color.DarkOrange;
                btnKiralaSato.BackColor = Color.Transparent;
                btnKiralaVilla.BackColor = Color.Transparent;
                para -= 80000;
                lblPara.Text = para.ToString() + "₺";
            }
            else
            {

            }
        }
        private void btnKiralaVilla_Click(object sender, EventArgs e)
        {
            if (evdegistir(ev, villa, yas, para) == true)
            {
                evdegistir(ev, villa);
                lblEv.Text = ev.Tür;
                btnKiralaApt.BackColor = Color.Transparent;
                btnKiralaSato.BackColor = Color.Transparent;
                btnKiralaVilla.BackColor = Color.DarkOrange;
                para -= 400000;
                lblPara.Text = para.ToString() + "₺";
            }
            else
            {

            }
        }

        private void btnKiralaSato_Click(object sender, EventArgs e)
        {
            if (evdegistir(ev, sato, yas, para) == true)
            {
                evdegistir(ev, sato);
                lblEv.Text = ev.Tür;
                btnKiralaApt.BackColor = Color.Transparent;
                btnKiralaSato.BackColor = Color.DarkOrange;
                btnKiralaVilla.BackColor = Color.Transparent;
                para -= 1000000;
                lblPara.Text = para.ToString() + "₺";
            }
        }
        public static bool evdegistir(Ev eskiev, Ev yeniev, int yas, int para)
        {
            if (yas < 5)
            {
                MessageBox.Show("Henüz bir ev alacak kadar büyümedin!");
                return false;
            }
            else if (para - yeniev.Fiyat<0)
            {
                MessageBox.Show("Bu evi kiralayacak kadar paranız yok");
                return false;
            }
            else if(para-yeniev.Fiyat>=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void evdegistir(Ev eskiev, Ev yeniev)
        {
            eskiev.Tür = yeniev.Tür;
            eskiev.Fiyat = yeniev.Fiyat;
            eskiev.Can = yeniev.Can;
            eskiev.Zihin = yeniev.Zihin;
        }
        //Araba İşlemleri
        public static bool arabaKontrol(Araba yeniaraba, int para)
        {
            if (para-yeniaraba.Fiyat>=0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Yeterli paranız yok!");
                return false;
            }
        }
        public static void arabadegistir(Araba eskiaraba, Araba yeniaraba)
        {
            eskiaraba.Tür = yeniaraba.Tür;
            eskiaraba.Fiyat = yeniaraba.Fiyat;
            eskiaraba.Zihin = yeniaraba.Zihin;
        }
        private void btnJeepAl_Click(object sender, EventArgs e)
        {
            bool b = arabaKontrol(Jeep, para);
            if (b == true)
            {
                arabadegistir(araba, Jeep);
                para -= 100000;
                lblPara.Text = para.ToString() + "₺";
                lblAraba.Text = araba.Tür;
                btnSedanAl.BackColor = Color.Transparent;
                btnSporAl.BackColor = Color.Transparent;
                btnJeepAl.BackColor = Color.DarkOrange;
            }
        }
        private void btnSporAl_Click(object sender, EventArgs e)
        {
            if (arabaKontrol(spor, para) == true)
            {
                arabadegistir(araba, spor);
                para -= 400000;
                lblPara.Text = para.ToString() + "₺";
                lblAraba.Text = araba.Tür;
                btnSedanAl.BackColor = Color.Transparent;
                btnSporAl.BackColor = Color.DarkOrange;
                btnJeepAl.BackColor = Color.Transparent;
            }
        }

        private void btnSedanAl_Click(object sender, EventArgs e)
        {
            if (arabaKontrol(spor, para) == true)
            {
                arabadegistir(araba, spor);
                para -= 30000;
                lblPara.Text = para.ToString() + "₺";
                lblAraba.Text = araba.Tür;
                btnSedanAl.BackColor = Color.DarkOrange;
                btnSporAl.BackColor = Color.Transparent;
                btnJeepAl.BackColor = Color.Transparent;
            }
        }


    }
}
