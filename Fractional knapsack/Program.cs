using System;

class FractionalKnapsack
{
    static void Main()
    {
        int[] values = { 15, 5, 20, 8, 7, 20, 6 };
        int[] weights = { 3, 4, 6, 8, 2, 2, 3 };
        int maxCapacity = 18;

        Console.Write("Values: ");
        Console.Write("[ ");
        foreach (int value in values)
        {
            Console.Write(value + " ");
        }
        Console.Write("]");
        Console.WriteLine("\n");

        Console.Write("weights: ");
        Console.Write("[ ");
        foreach (int weight in weights)
        {
            Console.Write(weight + " ");
        }
        Console.Write("]");
        Console.WriteLine("\n");


        double optimalValue = FractionalKnapsackAlgorithm(values, weights, maxCapacity);

        Console.WriteLine();
        Console.WriteLine($"Optimal value in the knapsack: {optimalValue}");
    }

    static double FractionalKnapsackAlgorithm(int[] values, int[] weights, int maxCapacity)
    {
        int n = values.Length;
        double[] valueToWeightRatio = new double[n];

        for (int i = 0; i < n; i++)
        {
            valueToWeightRatio[i] = (double)values[i] / weights[i];
        }

        Console.Write("Value-to-Weight Ratios: ");
        Console.Write("[ ");
        foreach (double ratio in valueToWeightRatio)
        {
            Console.Write(ratio + " ");
        }
        Console.Write("]");

        Console.WriteLine();

        double totalValue = 0;
        int remainingCapacity = maxCapacity;

        while (remainingCapacity > 0)
        {
            int bestItemIndex = GetBestItemIndex(valueToWeightRatio);
            if (bestItemIndex == -1)
            {
                // No more items to consider
                break;
            }

            double fraction = Math.Min(1, (double)remainingCapacity / weights[bestItemIndex]);

            totalValue += fraction * values[bestItemIndex];
            remainingCapacity -= (int)(fraction * weights[bestItemIndex]);

            // Mark the item as used by setting its ratio to a non-positive value
            valueToWeightRatio[bestItemIndex] = -1;

            Console.WriteLine();
            Console.WriteLine($"Fraction of bestItemIndex {bestItemIndex}: {fraction}, Best item index: {bestItemIndex}, The value of bestItemIndex: {values[bestItemIndex]},Value of Knapsack:{totalValue}");
            Console.WriteLine();
        }

        return totalValue;
    }

    static int GetBestItemIndex(double[] ratios)
    {
        int bestIndex = -1;
        double bestRatio = 0;

        for (int i = 0; i < ratios.Length; i++)
        {
            if (ratios[i] > 0 && ratios[i] > bestRatio)
            {
                bestRatio = ratios[i];
                bestIndex = i;
            }
        }

        return bestIndex;
    }
}
