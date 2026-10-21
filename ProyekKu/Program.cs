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
            this.posisiSaatIni = 0;
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
            this.posisiSaatIni = posisiBaru;
            Console.WriteLine("Posisi sekarang: " + posisiSaatIni);
        }

        public void getData()
        {
            Console.WriteLine($"Karakter : {nama}");
            Console.WriteLine($"Kesehatan : {kesehatan}");
            Console.WriteLine($"Senjata : {senjata}");
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

            Console.WriteLine("\n=== DATA KARAKTER ===");
            player1.getData();

            Console.WriteLine("\n=== MEMBACA TOMBOL KEYBOARD ===");
            Console.WriteLine("Panah kanan (->) : Menambah posisi 2");
            Console.WriteLine("Panah kiri (<-)  : Mengurangi posisi 1");
            Console.WriteLine("Esc               : Permainan berhenti");
            Console.WriteLine("Posisi awal: " + player1.posisiSaatIni);

            bool bermain = true;

            while (bermain)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true);

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    player1.Aksi(player1.posisiSaatIni + 2);
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    player1.Aksi(player1.posisiSaatIni - 1);
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    bermain = false;
                    Console.WriteLine("Permainan berhenti!");
                }
            }

            Console.WriteLine("\n=== PERMAINAN SELESAI ===");
            player1.getData();
        }
    }
}//ceneh