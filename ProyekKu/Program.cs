//game
//genre : fighting
//Karakter : nama, kesehatan

using System;
namespace KerangkaGame
{
    class Karakter
    {
        //public string nama, kesehatan, senjata;
        public int totalsenjata, power;
        //enskaplusasi

        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }
        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
        }

        public void serang(Karakter target)
        {
           Console.WriteLine("==> mulai serangan"); 
           target.terimaserangan(this.senjata);
        }

        public void terimaserangan(int jumlahSerangan)
        {
           kesehatan -= jumlahSerangan; 
           Console.WriteLine($"{nama} diserang dengan {jumlahSerangan}.sisa kesehatan{kesehatan}");
        }

        //public void setData(string namaBaru, string statusSehat, string senjata, int totalsenjata, int power)
        //{
        //    this.nama = namaBaru;
        //    this.kesehatan = statusSehat;
        //    this.senjata = senjata;
        //    this.totalsenjata = totalsenjata;
        //    this.power = power;
        //}

        //public void getData()
        //{
        //    Console.WriteLine(nama);
        //    Console.WriteLine(kesehatan);
        //    Console.WriteLine(senjata);
        //    Console.WriteLine(totalsenjata);
        //    Console.WriteLine(power);
        //    Console.WriteLine();
        //}

        public void getData()
        {
            Console.WriteLine($"Karakter {nama}");
        }
    }


    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Haditya", 100, 10);//player utama
            Karakter musuh = new Karakter("aditya",100,100);

            //interasksi
            player1.serang(musuh);
            musuh.serang(player1);
            

            

            //List<Karakter> daftarHero = new List<Karakter>(); //array menyimpan pahlawan
            //Karakter player1 = new Karakter();
            //player1.setData("Archer", "Sehat", "Katana", 1, 10);
            //// player1.getData();

            //Karakter player2 = new Karakter();
            //player2.setData("Ford", "Kritis", "m4", 2, 50);
            //// player2.getData();

            ////objek baru musuh
            //Karakter musuh = new Karakter();
            //musuh.setData("Bjorka", "Sehat", "Tangkos", 10, 90);
            //musuh.getData();

            //daftarHero.Add(player1);
            //daftarHero.Add(player2);

            ////menampilkan data dari array, foreach
            //foreach (Karakter player in daftarHero)
            //{
            //    player.getData();
            //}
        }
    }
}