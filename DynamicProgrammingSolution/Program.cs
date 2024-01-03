namespace DynamicProgrammingSolution
{
    public class Program
    {
        static void Main()
        {
            int[] balls3 = { 11, 12, 13, 14, 15, 16, 16, 18 };
            int k3 = 2;
            Console.WriteLine(CalculateTicketPrice(balls3, k3)); // Output: 14.142857142857142
        }

        static double CalculateTicketPrice(int[] balls, int k)
        {
            int totalBalls = balls.Length;
            k = Math.Min(k, totalBalls);

            // Generate all possible combinations of k balls
            var combinations = GetCombinations(balls, k);

            double sum = combinations.Sum(combination => combination.Max());

            double expectedValue = sum / combinations.Count();

            return expectedValue;
        }

        static List<List<int>> GetCombinations(int[] array, int k)
        {
            List<List<int>> result = new List<List<int>>();
            HashSet<string> uniqueCombinations = new HashSet<string>();

            GenerateCombinations(array, k, 0, new List<int>(), result, uniqueCombinations);

            return result;
        }

        static void GenerateCombinations(int[] array, int k, int start, List<int> current, List<List<int>> result, HashSet<string> uniqueCombinations)
        {
            if (current.Count == k)
            {
                // Convert the combination to a string for uniqueness check
                string combinationString = string.Join(",", current.OrderBy(x => x));

                // Check if the combination is unique
                if (uniqueCombinations.Add(combinationString))
                {
                    result.Add(new List<int>(current));
                }

                return;
            }

            for (int i = start; i < array.Length; i++)
            {
                current.Add(array[i]);
                GenerateCombinations(array, k, i + 1, current, result, uniqueCombinations);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
