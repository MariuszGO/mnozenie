using System.IO;
using System.Threading.Tasks;

namespace mnozenie
{
    internal class Program
    {
        public int n;
        Program(int n)
        {
            this.n = n;
        }

    public void losowanie(Int128 [,] a, Int128[,] b, int min, int max) 
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = rnd.Next(min, max);
                    b[i, j] = rnd.Next(min, max);
                }
            }
        }
   public void zapiszPliku(Int128[,] a, string nazwaPliku) //zapis do pliku
        {
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                for (int i = 0; i < this.n; i++)
                {
                    for (int j = 0; j < this.n; j++)
                    {
                        sw.Write(i + "," + j + " "  +a[i, j] + " ");
                    }
                    sw.WriteLine("end");
                }
            }
        }
    public void wyswietlanie(Int128[,] a)
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("*******************************************");
        }

    public void WczytajDoTablicy(Int128[,] tablica, string sciezka)
        {
            if (!File.Exists(sciezka))
                Console.WriteLine("Błąd: Plik nie został znaleziony.");

            string[] linie = File.ReadAllLines(sciezka);
            Console.Write("x" +linie);

            foreach (var linia in linie)
            {
                var czesci = linia.Split(' ', StringSplitOptions.RemoveEmptyEntries);//podział
                // czesci[0] = indeksy, czesci[1] = wartosc
                for (int i = 0; i < czesci.Length - 1; i += 2) // - 1 pomija end
                {
                    if (czesci[i] == "end") break; //przerywa jezeli end

                    var indeksy = czesci[i].Split(','); //dzielimy indeksy
                    if (indeksy.Length != 2) continue;  //jezeli nie ma 2 indeksów to pomijamy

                    int.TryParse(indeksy[0], out int x);
                    int.TryParse(indeksy[1], out int y);
                    int.TryParse(czesci[i + 1], out int wartosc);

                    tablica[x, y] = wartosc;
                    Console.WriteLine("Wczytano: " + x + "," + y + " " + tablica[x,y]);
                }
            }
        }           
    public void mnozenie(Int128[,] a, Int128[,] b, Int128[,] c) 
        {
            for (int i = 0; i < this.n; i++)
            {
                Console.WriteLine("Wykonano " + i + " iteracji z " + this.n + " iteracji"); //wyświetlanie postępu
                for (int j = 0; j < this.n; j++) //pętla
                     {
                        c[i, j] = 0;
                        for (int k = 0; k < this.n; k++)
                            {
                                c[i, j] += a[i, k] * b[k, j];
                            }
                     }
            }
        } //end of mnozenie
        public void mnozenieRownolegle(Int128[,] a, Int128[,] b, Int128[,] c)
            {
                Parallel.For(0, this.n, i =>
                     {
                     Console.WriteLine("Wykonano " + i + " iteracji z " + this.n + " iteracji"); //wyświetlanie postępu
                    
                     for (int j = 0; j < this.n; j++)
                         {
                            c[i, j] = 0;
                   
                             for (int k = 0; k < this.n; k++)
                                {
                                    c[i, j] += a[i, k] * b[k, j];
                                }
                         }
                     });
            }
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj rozmiar macierzy: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Program obiekt = new Program(n);

            Int128[,] a = new Int128[obiekt.n, obiekt.n];
            Int128[,] b = new Int128[obiekt.n, obiekt.n];
            Int128[,] c = new Int128[obiekt.n, obiekt.n];

            obiekt.losowanie(a,b,-5000,5000);
            // obiekt.wyswietlanie(a);
            // obiekt.wyswietlanie(b);
            //obiekt.mnozenie(a, b, c);
           // obiekt.mnozenieRownolegle(a, b, c);
            // obiekt.wyswietlanie(c);
            obiekt.zapiszPliku(a, "a.txt");
            obiekt.zapiszPliku(b, "b.txt");
            obiekt.zapiszPliku(c, "c.txt");
            obiekt.WczytajDoTablicy(a, "a.txt");

        } //end of main
    } //end of class Program
}// end namespace
