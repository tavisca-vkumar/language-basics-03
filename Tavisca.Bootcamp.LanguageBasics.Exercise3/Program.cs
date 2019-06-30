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
        private static List<int> Maxm(int[] arr, List<int> indexes)
        {
            int maxm = arr[indexes[0]];
            List<int> temp = new List<int>();

            for(int i=0; i< indexes.Count; i++)
            {
                if (arr[indexes[i]] > maxm)
                    maxm = arr[indexes[i]];
            }
            for(int i = 0; i < indexes.Count; i++)
            {
                if (arr[indexes[i]] == maxm)
                    temp.Add(indexes[i]);
            }
            
            return temp;
        }
        private static List<int> Minm(int[] arr, List<int> indexes)
        {
            int minm = arr[indexes[0]];
            List<int> temp = new List<int>();

            for (int i = 0; i < indexes.Count; i++)
            {
                if (arr[indexes[i]] < minm)
                    minm = arr[indexes[i]];
            }
            for (int i = 0; i < indexes.Count; i++)
            {
                if (arr[indexes[i]] == minm)
                    temp.Add(indexes[i]);
            }
            
            return temp;
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            List<int> indexes = new List<int>();
            int[] ans = new int[dietPlans.Length];
            int[] total = new int[protein.Length];

            for(int i=0; i<protein.Length; i++)
                total[i] = 5*protein[i] + 5*carbs[i] + 9*fat[i];

            for(int i=0; i<dietPlans.Length; i++)
            {
                indexes.Clear();
                for (int x = 0; x < protein.Length; x++)
                    indexes.Add(x);

                for(int j=0; j<dietPlans[i].Length; j++)
                {
                    //Console.WriteLine("--{0}---", dietPlans[i][j]);
                    switch (dietPlans[i][j])
                    {
                       
                        case 'T':
                            indexes = Maxm(total, indexes);
                            break;
                        case 't':
                            indexes = Minm(total, indexes);
                            //Console.WriteLine("{0} -- ",indexes[0] );
                            break;
                        case 'P':
                            indexes = Maxm(protein, indexes);
                            break;
                        case 'p':
                            indexes = Minm(protein, indexes);
                            break;
                        case 'C':
                            indexes = Maxm(carbs, indexes);
                            break;
                        case 'c':
                            indexes = Minm(carbs, indexes);
                            break;
                        case 'F':
                            indexes = Maxm(fat, indexes);
                            break;
                        case 'f':
                            indexes = Minm(fat, indexes);
                            break;
                    }
                    if (indexes.Count == 1)
                        break;
                }
                ans[i] = indexes[0];
                
            }
            return ans;
            
        }
    }
}
