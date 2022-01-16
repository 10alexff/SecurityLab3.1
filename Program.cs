using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_1 
{
    public class Program
    {
        public static void Main(string[] args)
        {
			int[] x = new int[3] { -428720726, 2053624065, 974386796 };
			int m = (int)(Math.Pow(2, 32));
			double a = find_a(x,m);
			// Console.WriteLine(a); // знайшовши а 
			double c = find_c(x, a, m);
			// Console.WriteLine(c); // знайшовши с - можемо отримати наступне "рандомне" значення 
			double xNext = LCG(x[2], a, c, m); // результат - наступне значення
			Console.WriteLine(xNext);

			//Perevirka();

		}

		public static double LCG(int x, double a, double c, int m)
		{
			return (x * a + c) % m;
		}
		public static double find_c(int[] x, double a, int m)
		{
			double c = (x[1] - x[0] * a) % m;
			return c;
		}


		public static double find_a(int [] x,int m) 
		{
			int inverse_m = Inverse(x[1] - x[0], m);
			double a = (x[2] = x[1]) * inverse_m % m;
			return a;
		}

		public static int Inverse(int a, int m)
		{
			int[] masiv = egcd(a, m);
			return masiv[2] % m;
		}
		public static int[] egcd(int a, int b) 
		{
			int[] mas = new int[3];
			if (a == 0) { mas[0] = b; mas[1] = 0; mas[2] = 1; return mas; }
			else {
				var mas1 = egcd(b % a, a);
				mas[0] = mas1[0];
				mas[1] = mas1[2]-(b / a) * mas1[1];
				mas[2] = mas1[1];
				return mas;
			}
		}

		public static void Perevirka()
		{
			int[] y = new int[6] { -1517823580, 101734579, -1206532490, -1541207203, -1529703144, 299898263 };
			int m2 = (int)(Math.Pow(2, 32));
			double c2 = 1013904223;
			double a2 = 1664525;
			double f2 = LCG(1818388024, a2, c2, m2);

			for (int a = 0; a < m2; a++)
			{
				var x1 = (y[0] * a + c2) % m2;
				if (x1 != y[1])
				{
					continue;
				}
				var x2 = (y[3] * a + c2) % m2;
				var x3 = (y[4] * a + c2) % m2;
				var x4 = (y[5] * a + c2) % m2;

				if ((x2 == y[2]) && (x3 == y[3]) && (x4 == y[4]))
				{
					Console.WriteLine(m2 + "  " + a2 + "  " + c2);
				}
			}
		}

	}
}