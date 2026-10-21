using System;

namespace KerangkaGame
{
    class Karakter
    {
        public int total, power;

        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }
        public int posisiSaatIni { get; private set; }

        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.posisiSaatIni = 0; // Posisi awal otomatis mulai dari 0
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("===> Mulai Serangan <===");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int jumlahSerangan)
        {
            kesehatan -= jumlahSerangan;
            Console.WriteLine($"{nama} diserang dengan {jumlahSerangan} sisa kesehatannya {kesehatan}");
        }

        public void Healing()
        {
            if (kesehatan <= 0)
            {
                Console.WriteLine($"{nama} sudah mati dan tidak bisa disembuhkan.");
                return;
            }

            Console.Write("Apakah mau disembuhkan? (Yes/No): ");
            string jawaban = Console.ReadLine().ToLower();

            if (jawaban == "yes")
            {
                kesehatan += 20;
                Console.WriteLine($"{nama} disembuhkan dengan penambahan 20. Kesehatan sekarang: {kesehatan}");
            }
            else if (jawaban == "no")
            {
                Console.WriteLine($"{nama} tidak disembuhkan.");
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }
        }

        public void Aksi(int posisiBaru)
        {
            int posisiAwal = this.posisiSaatIni;
            this.posisiSaatIni = posisiBaru;
            int jarak = posisiBaru - posisiAwal;

            Console.WriteLine($"\n{nama} berpindah dari posisi {posisiAwal} ke posisi {posisiBaru} (Berpindah {jarak} langkah).");
        }

        public void getData()
        {
            Console.WriteLine($"Karakter : {nama}");
            Console.WriteLine($"Kesehatan : {kesehatan}");
            Console.WriteLine($"senjata : {senjata}");
            Console.WriteLine($"Posisi Sekarang : {posisiSaatIni}");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Hadit", 100, 10);
            Karakter musuh1 = new Karakter("kosmos", 80, 50);

            player1.Serang(musuh1);
            musuh1.Serang(player1);
            player1.Healing();

            Console.WriteLine("\nMana yang Kamu Pilih?");
            Console.WriteLine("1. perpindahan angka Manual");
            Console.WriteLine("2. perpindahan menggunakan keyboard/Arraw");
            Console.Write("Pilihanmu: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                Console.Write("\nMasukkan posisi tujuan/baru untuk " + player1.nama + ": ");
                if (int.TryParse(Console.ReadLine(), out int posisiTujuan))
                {
                    player1.Aksi(posisiTujuan);
                }
                else
                {
                    Console.WriteLine("Input tidak valid, harap masukkan angka!");
                }
            }
            else if (pilihan == "2")
            {
                Console.WriteLine("\nGunakan Panah Kanan (maju +2), Panah Kiri (mundur -1), atau Escape (keluar).");
                bool sedangBermain = true;
                while (sedangBermain)
                {
                   ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        player1.Aksi(player1.posisiSaatIni + 2);
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        player1.Aksi(player1.posisiSaatIni - 1);
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("\nPermainan berhenti.");
                        sedangBermain = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid!");
            }
        }
    }
}