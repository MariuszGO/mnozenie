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

        public void mnozenie(Int128[,] a, Int128[,] b, Int128[,] c) {

            for (int i = 0; i < this.n; i++)
            {
                Console.WriteLine("Wykonano " + i + " iteracji z " + this.n + " iteracji");
                for (int j = 0; j < this.n; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < this.n; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }


                }

            static void Main(string[] args)
        {
          //  int n = 10;

            Program obiekt = new Program(6000);

            Int128[,] a = new Int128[obiekt.n, obiekt.n];
            Int128[,] b = new Int128[obiekt.n, obiekt.n];
            Int128[,] c = new Int128[obiekt.n, obiekt.n];

            obiekt.losowanie(a,b,1,100);
           // obiekt.wyswietlanie(a);
           // obiekt.wyswietlanie(b);
            obiekt.mnozenie(a, b, c);
           // obiekt.wyswietlanie(c);


        }
    }
}
