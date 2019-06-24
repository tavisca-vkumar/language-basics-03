using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static List<int> Maxm(int[] arr, List<int> count)
        {
            int maxm = arr[count[0]];
            List<int> temp = new List<int>();

            for(int i=0; i< count.Count; i++)
            {
                if (arr[count[i]] > maxm)
                    maxm = arr[count[i]];
            }
            for(int i = 0; i < count.Count; i++)
            {
                if (arr[count[i]] == maxm)
                    temp.Add(count[i]);
            }
            
            return temp;
        }
        public static List<int> Minm(int[] arr, List<int> count)
        {
            int minm = arr[count[0]];
            List<int> temp = new List<int>();

            for (int i = 0; i < count.Count; i++)
            {
                if (arr[count[i]] < minm)
                    minm = arr[count[i]];
            }
            for (int i = 0; i < count.Count; i++)
            {
                if (arr[count[i]] == minm)
                    temp.Add(count[i]);
            }
            
            return temp;
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            List<int> count = new List<int>();
            int[] ans = new int[dietPlans.Length];
            int[] total = new int[protein.Length];

            for(int i=0; i<protein.Length; i++)
                total[i] = 5*protein[i] + 5*carbs[i] + 9*fat[i];

            for(int i=0; i<dietPlans.Length; i++)
            {
                count.Clear();
                for (int x = 0; x < protein.Length; x++)
                    count.Add(x);

                for(int j=0; j<dietPlans[i].Length; j++)
                {
                    //Console.WriteLine("--{0}---", dietPlans[i][j]);
                    switch (dietPlans[i][j])
                    {
                       
                        case 'T':
                            count = Maxm(total, count);
                            break;
                        case 't':
                            count = Minm(total, count);
                            //Console.WriteLine("{0} -- ",count[0] );
                            break;
                        case 'P':
                            count = Maxm(protein, count);
                            break;
                        case 'p':
                            count = Minm(protein, count);
                            break;
                        case 'C':
                            count = Maxm(carbs, count);
                            break;
                        case 'c':
                            count = Minm(carbs, count);
                            break;
                        case 'F':
                            count = Maxm(fat, count);
                            break;
                        case 'f':
                            count = Minm(fat, count);
                            break;
                    }
                    if (count.Count == 1)
                        break;
                }
                ans[i] = count[0];
                
            }
            return ans;
            throw new NotImplementedException();
        }
    }
}
