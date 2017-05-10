using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] letters = { Letter.A, Letter.C, Letter.S };
            int[][] corrupted = { Letter.Ax, Letter.Cx, Letter.Sx };

            Hopfield hopfield = new Hopfield(letters);

            for (int i = 0; i < letters.Length; i++)
            {
                Console.WriteLine("  Input    Output");
                int[] fix = hopfield.Fix(corrupted[i]);
                hopfield.Print(corrupted[i], fix);
            }

            Console.ReadKey();
        }
    }
}
