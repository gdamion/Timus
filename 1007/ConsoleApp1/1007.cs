
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timus1007App
{
    class Info
    {
        public int N;
        public int M;
        public List<List<bool>> Words;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Info In = new Info();
            In.Words = new List<List<bool>>();

            Parse(In);
            Algorythm(In);
            Console.Clear();
            Print_res(In);
        }

        static void Parse(Info In)
        {
            int M = -1;

            while (true)
            {
                string str = Console.ReadLine();
                if (str == null)
                    break;
                if (M == -1)
                {
                    int i = -1;
                    int gotcha = 0;

                    while (++i < str.Length)
                    {
                        if ((str[i] < '0' || str[i] > '9') && str[i] != ' ')
                            Error();
                        if (str[i] >= '0' && str[i] <= '9' && gotcha == 0)
                            gotcha = 1;
                        else if (str[i] == ' ' && gotcha == 1)
                            gotcha = 2;
                        else if ((str[i] >= '0' && str[i] <= '9') && gotcha == 2)
                            Error();

                    }
                    double N_buf = double.Parse(str);
                    int N_buf_int = (int)N_buf;
                    if (N_buf < 4 || N_buf > 1000 || (N_buf - (double)(N_buf_int) != 0))
                        Error();
                    In.N = N_buf_int;
                }
                else
                {
                    List<bool> code_str = new List<bool>();
                    int i = 0;

                    while (i < str.Length)
                    {
                        if (str[i] == '0')
                            code_str.Add(false);
                        else if (str[i] == '1')
                            code_str.Add(true);
                        else if (str[i] == ' ')
                        {
                            i++;
                            continue;
                        }
                        else
                            Error();
                        i++;
                    }
                    In.Words.Add(code_str);
                }
                M++;
            }
            In.M = M;
        }

        static void Algorythm(Info In)
        {
            foreach (List<bool> word in In.Words)
            {
                int N_real = word.Count;
                int sum = one_sum(word);

                if (is_ok(N_real, sum) && N_real == In.N)
                    continue;
                else if (N_real < In.N)
                    case_1(word, N_real, In);
                else if (N_real > In.N)
                    case_2(word, N_real, In);
                else if (N_real == In.N)
                    case_3(word, N_real, In);
                else
                    Error();
            }
        }

        static void case_1(List<bool> word, int N_real, Info In)
        {
            for (int i = 0; i <= N_real; i++)
            {
                int sum;

                word.Insert(i, true);

                sum = one_sum(word);
                if (is_ok(In.N, sum))
                    return;
                word.RemoveAt(i);

                word.Insert(i, false);
                sum = one_sum(word);
                if (is_ok(In.N, sum))
                    return;
                word.RemoveAt(i);

            }
        }

        static void case_2(List<bool> word, int N_real, Info In)
        {
            for (int i = 0; i < N_real; i++)
            {
                int sum;
                bool el;

                el = word[i];
                word.RemoveAt(i);

                sum = one_sum(word);
                if (is_ok(In.N, sum))
                    return;
                word.Insert(i, el);

            }
        }

        static void case_3(List<bool> word, int N_real, Info In)
        {
            for (int i = 0; i < N_real; i++)
            {
                int sum;
                if (word[i] == true)
                {
                    word.RemoveAt(i);
                    word.Insert(i, false);

                    sum = one_sum(word);
                    if (is_ok(In.N, sum))
                        return;
                    word.RemoveAt(i);
                    word.Insert(i, true);
                }
            }
        }

        static bool is_ok(int N, int sum)
        {
            if ((sum % (N + 1)) == 0)
                return true;
            else
                return false;
        }

        static int one_sum(List<bool> word)
        {
            int sum = 0;

            for (int i = 0; i < word.Count; i++)
            {
                if (word[i] == true)
                    sum += i + 1;
            }
            return sum;
        }

        static void Print_res(Info In)
        {
            foreach (List<bool> word in In.Words)
            {
                foreach (bool letter in word)
                    Console.Write(Convert.ToInt16(letter));
                Console.WriteLine();
            }
        }

        static void Error()
        {
           // Console.WriteLine("Error occured! Terminating program session!");
            //Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
