
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Serialization;

namespace Okul_Yönetim_Projesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci Listesi
            List<Ogrenciler> ogrencıler = new List<Ogrenciler>
            {
                new Ogrenciler() { adsoyad = "Eymen Yaman", Okulnumarası = 202, Okuladı = "İmam Hatip Lisesi",şifre = "123456" },
                new Ogrenciler() { adsoyad = "Buğlem Yaman", Okulnumarası = 4, Okuladı = "Merter Meslek Lisesi",şifre = "45" },
                new Ogrenciler() { adsoyad = "Ebrar Güneşli", Okulnumarası = 8, Okuladı = "Anadolu Lisesi",şifre = "45" }
            };

            List<Ogretmen> oğretmen = new List<Ogretmen>
            {
                new Ogretmen() { id = 0, SorumluSinif = "7-B", KullaniciAdi = "caglayılmaz", şifre = "12345"  },
                
            };


            while (true)
                {
                    Console.WriteLine("1 Öğrenci Girişi");
                    Console.WriteLine("2 Öğretmen Girişi");
                    Console.WriteLine("3 Yönetici Girişi");
                    string secim = Console.ReadLine();

                    if (secim == "1")
                    {
                    Console.WriteLine("Öğrenci Numaranızı Girin");
                    int ogrencınumarasıgiris = Convert.ToInt32(Console.ReadLine());

                    var ogrenci = ogrencıler.FirstOrDefault(o => o.Okulnumarası == ogrencınumarasıgiris);

                    if(ogrenci!=null)
                    {
                        Console.WriteLine("Şifre Giriniz");
                        string sıfre = Console.ReadLine();

                        if(ogrenci.şifre==sıfre)
                        {
                            Console.WriteLine($"Hoşgeldiniz, {ogrenci.adsoyad}");
                            Console.WriteLine("1- Notlarınızı Görüntüle");
                            Console.WriteLine("2- Çıkış");

                            int secimOgrenci = Convert.ToInt32(Console.ReadLine());

                            if (secimOgrenci == 1)
                            {
                                // Öğrencinin notlarını göster
                                ogrenci.NotHesapla();
                                Console.WriteLine($"Notları görebilmeniz için öğretmenin adı: {oğretmen[0].adsoyad}");
                            }
                            else if(secimOgrenci == 2)
                            {
                                break;

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Şifre Yanlış ");
                    }

                }
                    else if (secim == "2")
                    {
                        Console.WriteLine("Öğretmen Kullanıcı Adını Giriniz");
                        string ogretmenkullanici = Console.ReadLine();
                        Console.WriteLine("Öğretmen Şifre Giriniz");
                        string ogretmensifre = Console.ReadLine();

                    var ogretmen = oğretmen.Find(i => i.KullaniciAdi == ogretmenkullanici);

                    if (ogretmen != null && ogretmen.şifre == ogretmensifre)
                        {
                            Console.WriteLine($"Giriş Başarılı {ogretmen.adsoyad}. Hoşgeldiniz");

                            while (true)
                            {
                                Console.WriteLine("1-Öğrencilerin Dersine Not Ekle");
                                Console.WriteLine("2- Haftalık Ders Programını Görüntüle ");
                                int öğretmensecim = Convert.ToInt32(Console.ReadLine());

                                if (öğretmensecim == 1)
                                {
                                    Console.WriteLine("1- Lise Öğrencileri İçin");
                                    Console.WriteLine("2- Lisans Öğrencileri İçin");
                                    int lisansllise = Convert.ToInt32(Console.ReadLine());

                                    if (lisansllise == 1)
                                    {
                                        // Lise öğrencilerini listeleme
                                        foreach (var ogrenci in ogrencıler)
                                        {
                                            Console.WriteLine($"Ad Soyad: {ogrenci.adsoyad}, Okul Numarası: {ogrenci.Okulnumarası}, Okul Adı: {ogrenci.Okuladı}");
                                        }

                                        Console.WriteLine("Hangi öğrenciyi seçmek istiyorsunuz? Lütfen öğrenci numarasını girin:");
                                        int numaralise = Convert.ToInt32(Console.ReadLine());

                                        var secilenOgrenci = ogrencıler.FirstOrDefault(d => d.Okulnumarası == numaralise);

                                        if (secilenOgrenci != null)
                                        {
                                            Console.WriteLine("Ne yapmak istiyorsunuz?");
                                            Console.WriteLine("1- Not Ekle");
                                            Console.WriteLine("2- Öğrenciyi Sil");
                                            int islem = Convert.ToInt32(Console.ReadLine());

                                            if (islem == 1)
                                            {
                                                // Notları ekleyelim
                                                Console.WriteLine($"{secilenOgrenci.adsoyad} için notları girin.");
                                                Console.Write("Not 1: ");
                                                double not1 = Convert.ToDouble(Console.ReadLine());
                                                Console.Write("Not 2: ");
                                                double not2 = Convert.ToDouble(Console.ReadLine());

                                                secilenOgrenci.NotEkle(not1, not2);
                                                secilenOgrenci.NotHesapla();

                                            Console.WriteLine("Not Başarıyla Eklenmiştir");
                                            Console.Clear();
                                            break;
                                            


                                        }
                                            else if(islem==2)
                                        {
                                            Console.WriteLine("Öğrenci Silmek Bakımda ");
                                            break;                                        
                                        }
                                    }
                                       
                                        else
                                        {
                                            Console.WriteLine("Öğrenci bulunamadı.");
                                        }
                                    }
                                    else if(lisansllise==2)
                                {
                                    Console.WriteLine("Ders Programı Listeleme Şu An Bakımda");
                                }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Kullanıcı adı veya şifre hatalı!");
                        }
                    }
                    else if (secim == "3")
                    {
                    int hak = 3;
                    string yonetıcışifre = "ab18";
                    while (hak>0)
                    {

                        Console.WriteLine("Yönetici Şifrenizi Girin");
                        string yonetıcı = Console.ReadLine();
                        hak--;

                        if(yonetıcı==yonetıcışifre)
                        {
                            Console.WriteLine("Giriş Başarılı");
                            break;
                        }
                        else if(hak==0)
                        {
                            Console.WriteLine("Hakkınız Bitti");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Şifre Yanlış Lütfen Tekrar Deneyiniz.");
                        }

                    }

                    while (true)
                    {
                        Console.WriteLine("1- Öğrenci Kayıt");
                        Console.WriteLine("2- Öğrenci Silmek");
                        Console.WriteLine("3- Öğretmen Kayıt");
                        Console.WriteLine("4- Öğretmen Silmek");
                        Console.WriteLine("5- Çıkış");
                        int yonetıcı = Convert.ToInt32(Console.ReadLine());
                        if(yonetıcı==1)
                        {
                            ogrencıler.Add(Ogrenciler.Kayıt());
                            Console.WriteLine("Öğrenci Başarıyla Kayıt Olunmuştur");
                        }
                        else if(yonetıcı==2)
                        {
                            Console.WriteLine(Ogrenciler.Delete(ogrencıler));
                        }
                        else if(yonetıcı==3)
                        {
                            oğretmen.Add(Ogretmen.Kayıt());
                        }
                        else if(yonetıcı==4)
                        {
                            Console.WriteLine(Ogretmen.Delete(oğretmen));
                        }
                        else if(yonetıcı==5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz İşlem");
                        }
                    }


                    }
                }
            }
        }
    }
