using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Projesi
{
    internal class Ogretmen : Vatandas
    {
        //static Dictionary<string, string> ogretmenVerileri = new Dictionary<string, string>();

        #region Bilğiler
        public int id;
        public string SorumluSinif;
        private long tc;
        public string şifre;
        public string KullaniciAdi;


        public long _tc
        {
            get { return tc; }
            set
            {
                if (value.ToString().Length == 11)
                {
                    Console.WriteLine("Ögretmen Başarılı Şekilde Kayıt Olmuştur");

                }
                else
                {
                    Console.WriteLine("Ögretmenin Tc Si 11 Haneli Değildir");
                }
            }
        }


        public DateTime sgkgiristarihi;


        public Ogretmen()
        {
            sgkgiristarihi = DateTime.Now;
        }
        #endregion


        internal static Ogretmen Kayıt()
        {
            Ogretmen s = new Ogretmen();
            Console.WriteLine("Yeni Öğretmenin Adı Ve Soyadını Giriniz");
            s.adsoyad = Console.ReadLine();
            Console.WriteLine("Yeni Öğretmenin İd Girin");
            s.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yeni Öğretmenin Sorumlu Alınacak Sınıfı");
            s.SorumluSinif = Console.ReadLine();
            Console.WriteLine("Yeni Öğretmenin 11 Haneli Tc Kimlik Numarasını Giriniz");
            s._tc = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Yeni Öğretmenin Yeni Kullanıcı Adını Giriniz");
            s.KullaniciAdi = Console.ReadLine();
            Console.WriteLine("Yeni Öğretmenin Yeni Şifresini Giriniz");
            s.şifre = Console.ReadLine(); 


            return s;
           
        }

        internal static void List(List<Ogretmen> liste)
        {

            foreach (var item in liste)
            {
                Console.WriteLine($"{item.id}-{item.SorumluSinif}-{item.adsoyad}:");
            }


        }

        internal static string Delete(List<Ogretmen> liste)
        {
            List(liste);
            Console.WriteLine("Silinecek Ögrenci  Numarası:");
            int idd = Convert.ToInt32(Console.ReadLine());


            Ogretmen ogrett = liste.Where(t => t.id == idd).FirstOrDefault();


            //Öğretmen Bulunamadı İse
            if (ogrett == null)
            {
                return "Öğretmen Bulunamadı";
            }

            // Öğretmen Bulundu İse Ögrenci Silindi
            liste.Remove(ogrett);
            return "Öğretmen Silindi";
        }




    }
}

