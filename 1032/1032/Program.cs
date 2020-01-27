using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1032
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			int[] a = new int[10022];
			int[] sum = new int[10022];
			int[] f = new int[10022];

			for (int i = 0; i < 10022; i++)
			{
				sum[i] = 0;
				f[i] = 0;
			}

			n = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i <= n; i++)
				a[i] = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			for (int i = 1; i <= n; ++i)
			{
				sum[i] = (a[i] + sum[i - 1]) % n;
				if (f[sum[i]] > 0 || (sum[i] == 0))
				{
					Console.WriteLine(i - f[sum[i]]);
					for (int j = f[sum[i]] + 1; j <= i; ++j)
						Console.WriteLine(a[j]); 
					break;
				}
				f[sum[i]] = i;
			}
		//	Console.ReadKey();
		}
	}
}
