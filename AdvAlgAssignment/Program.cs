namespace AdvAlgAssignment
{
    public class Program
    {
        static void Main()
        {
            //Example usage
            int[] balls1 = { 10, 10, 10, 10, 10, 10, 10 };
            int k1 = 3;

            Console.WriteLine($"Result { CalculateTicketPrice(balls1, k1) } \n"); // Output: 10.0

            int[] balls2 = { 10, 50, 40, 20, 30 };
            int k2 = 5;

            Console.WriteLine($"Result { CalculateTicketPrice(balls2, k2) } \n"); // Output: 50

            int[] balls3 = { 11, 12, 13, 14, 15, 16, 18 };
            int k3 = 1;

            Console.WriteLine($"Result { CalculateTicketPrice(balls3, k3)} \n"); // Output: 14.142857142857142
        }

        static double CalculateTicketPrice(int[] balls, int k)
        {
            int totalBalls = balls.Length;
            k = Math.Min(k, totalBalls);

            // Generate all possible combinations of k balls
            List<List<int>>? combinations = GenerateCombinations(balls, k);

            foreach (var item in combinations)
            {
                Console.WriteLine($"Combinations for element {combinations.IndexOf(item)}");
                foreach (var i in item)
                {
                    Console.Write($" {i} ");
                }
                Console.WriteLine();
            }

            // Calculate the maximum prize for each combination
            double sum = combinations.Sum(combination => combination.Max());

            Console.WriteLine($"Sum of combinations: { sum }");
            Console.WriteLine($"Combinations count: { combinations.Count()}");

            double expectedValue = sum / combinations.Count();

            return expectedValue;
        }

        static List<List<T>> GenerateCombinations<T>(T[] elements, int k)
        {
            List<List<T>> result = new List<List<T>>();
            GenerateCombinationsHelper(elements, k, 0, new List<T>(), result);
            return result;
        }

        static void GenerateCombinationsHelper<T>(T[] elements, int k, int start, List<T> current, List<List<T>> result)
        {
            if (k == 0)
            {
                result.Add(new List<T>(current));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                current.Add(elements[i]);
                GenerateCombinationsHelper(elements, k - 1, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
