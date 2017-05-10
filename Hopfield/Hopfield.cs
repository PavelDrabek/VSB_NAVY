using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield
{
    public class Hopfield
    {
        private double[][] weights;

        public Hopfield(int[][] trainSet)
        {
            InitWeights(trainSet[0].Length);
            Train(trainSet);
        }

        private void InitWeights(int size)
        {
            weights = new double[size][];
            for (int y = 0; y < weights.Length; y++)
            {
                weights[y] = new double[size];
                for (int x = 0; x < weights[y].Length; x++)
                {
                    weights[y][x] = 0;
                }
            }
        }

        public int[] Fix(int[] corrupted)
        {
            int[] result = new int[corrupted.Length];

            int[] pole = GetRandomIndexArray(35);
            for (int i = 0; i < pole.Length; i++) {
                result[i] = Calculate(corrupted, i);
            }

            return result;
        }

        public void Train(int[][] trainSet)
        {
            for (int i = 0; i < weights.Length; i++) {
                for (int j = 0; j < weights[i].Length; j++) {
                    double total = 0;
                    for(int l = 0; l < trainSet.Length; l++) {
                        total += trainSet[l][i] * trainSet[l][j];
                    }
                    weights[i][j] = (1.0 / trainSet.Length) * total;
                }
            }
        }

        private int Calculate(int[] corrupted, int neuronIndex)
        {
            double sum = 0;
            for (int i = 0; i < weights[neuronIndex].Length; i++) {
                sum += weights[neuronIndex][i] * corrupted[i];
            }
            return BinaryTF(sum);
        }

        private int[] GetRandomIndexArray(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++) {
                array[i] = i;
            }
            return array.OrderBy(x => rnd.Next()).ToArray();
        }

        private int BinaryTF(double value)
        {
            return value > 0 ? 1 : -1;
        }

        private double Calculate()
        {
            return 0;
        }

        public void Print()
        {
            for (int i = 0; i < weights.Length; i++) {
                for (int j = 0; j < weights[i].Length; j++) {
                    Console.Write(weights[i][j] + " ");
                }
                Console.Write("\n");
            }
        }
        public void Print(int[] letter)
        {
            for (int j = 0; j < 7; j++) {
                for (int i = 0; i < 5; i++) {
                    char c = letter[j * 5 + i] > 0 ? '*' : ' ';
                    Console.Write(c);
                }
                Console.Write("\n");
            }
        }

        public void Print(int[] letter1, int[] letter2)
        {
            for (int j = 0; j < 7; j++) {
                Console.Write("  ");
                for (int i = 0; i < 5; i++) {
                    char c = letter1[j * 5 + i] > 0 ? '*' : ' ';
                    Console.Write(c + " ");
                }
                Console.Write("    ");
                for (int i = 0; i < 5; i++) {
                    char c = letter2[j * 5 + i] > 0 ? '*' : ' ';
                    Console.Write(c + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
