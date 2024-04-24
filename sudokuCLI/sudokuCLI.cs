using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }
        public double KitöltveArány
        {
            get
            {
                int kitöltöttMező = Kezdo.Count(x => x != '0');
                return (double)kitöltöttMező / Kezdo.Length;
            }
        }


        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
    internal class sudokuCLI
    {
        
        static void Main(string[] args)
        {
            List<Feladvany> feladványok = new List<Feladvany>();
            File.ReadAllLines("feladvanyok.txt").ToList().ForEach(x => feladványok.Add(new Feladvany(x)));

            Console.WriteLine("3. feladat: Beolvasva {0} állomány",feladványok.Count);
            int inputMéret = 0;
            do
            {
                Console.Write("Kérem a feladvány méretét [4..9]: ");
                inputMéret = int.Parse(Console.ReadLine());

            } while (inputMéret < 4 || inputMéret > 9);

            Console.WriteLine("{0}x{1} méretű feladványból {2} darab van tárolva", inputMéret,inputMéret, feladványok.Count(x => x.Meret == inputMéret));




            Console.WriteLine("5. feladat: A kiválasztott feladvány:");
            Random rnd = new Random();
            //rnd.Next(0, feladványok.Where(x => x.Meret == inputMéret).ToList().Count()-1);

            Feladvany sorsoltFeladvány = feladványok.Where(x => x.Meret == inputMéret).ToList()[rnd.Next(0, feladványok.Where(x => x.Meret == inputMéret).ToList().Count() - 1)];
            Console.WriteLine("{0}", sorsoltFeladvány.Kezdo);

            Console.WriteLine("6. feladat: Feladvány kitöltöttsége {0:P2}", sorsoltFeladvány.KitöltveArány);


            Console.WriteLine("7. feladat: A feladvány kirajzolva:");
            sorsoltFeladvány.Kirajzol();

            List<string> adottMéretűek = new List<string>();

            foreach (var item in feladványok)
            {
                if (item.Meret == inputMéret)
                    adottMéretűek.Add(item.Kezdo);
            }

            File.WriteAllLines($"sudoku{inputMéret}.txt", adottMéretűek);

            Console.WriteLine($"8. feladat: sudoku{inputMéret}.txt állomány {adottMéretűek.Count} darab feladvánnyal létrehozva");
            Console.ReadKey();
        }
    }
}
