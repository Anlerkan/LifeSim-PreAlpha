using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSim
{
    public class Insan
    {
        string ad;
        internal int yas = 1;
        int para = 0;
        Meslek meslek;
        int cinsiyet;
        bool medeniDurum;
        string ulke;
        Ev ev;
        Araba araba;
        public Insan()
        {

        }
        public Insan(string ad,int para,int yas,Meslek meslek,int cinsiyet,bool medeniDurum,string ulke,Ev ev,Araba araba)
        {
            this.ad = ad;
            this.para = para;
            this.yas = yas;
            this.meslek = meslek;
            this.cinsiyet = cinsiyet;
            this.medeniDurum = medeniDurum;
            this.ulke = ulke;
            this.ev = ev;
            this.araba = araba;
        }
        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }
        public int Yas
        {
            get { return yas; }
            set { yas = value; }
        }
        public Meslek Meslek
        {
            get { return meslek; }
            set { meslek = value; }
        }
        public Ev Ev
        {
            get { return ev; }
            set { ev = value; }
        }
        public Araba Araba
        {
            get { return araba; }
            set { araba = value; }
        }
        public int Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }
        public bool MedeniDurum
        {
            get { return medeniDurum; }
            set { medeniDurum = value; }
        }
        public string Ulke
        {
            get { return ulke; }
            set { ulke = value; }
        }
        public int Para
        {
            get { return para; }
            set { para = value; }
        }
        public void medeniDurumDegistir()
        {
            if (medeniDurum == true)
            {
                medeniDurum = false;
            }
            else
            {   
                medeniDurum = true;
            }
        }
        public void meslekDegistir(Meslek m)
        {
            this.meslek = m;
        }
        public void evDegistir(Ev yeniev)
        {
            this.ev = yeniev;
        }
        public void maasArttir(int artmaMiktari)
        {
            this.meslek.Maas += artmaMiktari;
        }
        public void paraArttir(int artmaMiktari)
        {
            this.para += artmaMiktari;
        }
    }
    public class Meslek
    {
        public Meslek(string meslekismi,int maas)
        {
            this.meslekismi = meslekismi;
            this.maas = maas;
        }
        public Meslek(string meslekismi, int maas,int akilsagligi)
        {
            this.meslekismi = meslekismi;
            this.maas = maas;
            this.akilsagligi = akilsagligi;
            
        }
        int akilsagligi;
        int deneyim = 0;
        string meslekismi;
        int maas;
        public int Maas
        {
            get { return maas; }
            set { maas = value; }
        }
        public int Akilsagligi
        {
            get { return akilsagligi; }
            set { akilsagligi = value; }
        }
        public string Meslekismi
        {
            get { return meslekismi; }
            set { meslekismi = value; }
        }
        public int Deneyim
        {
            get { return deneyim; }
            set { deneyim = value; }
        }
    }
    public class Ev
    {
        string tür;
        int can;
        int zihin;
        int fiyat;
        public Ev(string tür,int can,int zihin,int fiyat)
        {
            this.tür = tür;
            this.can = can;
            this.zihin = zihin;
        }
        public string Tür
        {
            get { return tür; }
            set { tür = value; }
        }
        public int Can
        {
            get { return can; }
            set { can = value; }
        }
        public int Zihin
        {
            get { return zihin; }
            set { zihin = value; }
        }
        public int Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; }
        }
    }
    public class Araba
    {
        string tür;
        int zihin;
        public int fiyat;
        public Araba(string tür, int zihin,int fiyat)
        {
            this.tür = tür;
            this.zihin = zihin;
        }
        public string Tür
        {
            get { return tür; }
            set { tür = value; }
        }

        public int Zihin
        {
            get { return zihin; }
            set { zihin = value; }
        }
        public int Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; }
        }
    }
}
