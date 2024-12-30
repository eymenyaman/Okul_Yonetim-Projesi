using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Projesi
{
    internal class Ogrenciler:Vatandas
    {

        #region Bilgiler
        public string adsoyad;
        public int Okulnumarası;
        public string Okuladı;
        public double not1;
        public double not2;
        public string şifre;
        #endregion

        // Öğrenci için kayıt işlemi
        internal static Ogrenciler Kayıt()
        {
            Ogrenciler s = new Ogrenciler();
            Console.WriteLine("Yeni Öğrenci Ad Soyad Giriniz");
            s.adsoyad = Console.ReadLine();
            Console.WriteLine("Yeni Öğrenci Okul Numarası Girin");
            s.Okulnumarası = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Okul Adı Girin");
            s.Okuladı = Console.ReadLine();
            Console.WriteLine("Yeni Öğrencinin Şifresini Girin");
            s.şifre = Console.ReadLine();
            return s;
        }

        // Öğrenci notlarını eklemek için metot
        public void NotEkle(double not1, double not2)
        {
            this.not1 = not1;
            this.not2 = not2;
        }

        // Öğrencinin notlarını hesaplayıp yazdırmak için metot
        public void NotHesapla()
        {
            double ortalama = (not1 + not2) / 2;
            string harfNotu = ortalama >= 85 ? "Pekiyi" :
                               ortalama >= 70 ? "İyi" :
                               ortalama >= 60 ? "Orta" :
                               ortalama >= 50 ? "Geçer" : "Tekrar";
            Console.WriteLine($"Ortalama: {ortalama}, Harf Notu: {harfNotu}");
        }

        // Öğrenci Listesi
        internal static void List(List<Ogrenciler> liste)
        {
            foreach (var item in liste)
            {
                Console.WriteLine($"{item.adsoyad}-{item.Okuladı}-{item.Okulnumarası}:");
            }
        }

        // Öğrenci Silme
        internal static string Delete(List<Ogrenciler> liste)
        {
            List(liste);
            Console.WriteLine("Silinecek Öğrenci Numarası:");
            int numara = Convert.ToInt32(Console.ReadLine());
            Ogrenciler ogrenci = liste.Where(t => t.Okulnumarası == numara).FirstOrDefault();

            if (ogrenci == null)
            {
                return "Öğrenci Bulunamadı";
            }

            liste.Remove(ogrenci);
            return "Öğrenci Silindi";
        }
    }
}