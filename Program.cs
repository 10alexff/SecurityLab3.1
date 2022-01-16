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

			   // Console.WriteLine(c); // знайшовши с - можемо отримати наступне "рандомне" значення 
			 // результат - наступне значення

			//Perevirka();

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


	}
}