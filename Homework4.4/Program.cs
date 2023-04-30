using System;

class GraphNodeSymbols
{
    static void Main()
    {
        // Accept number of nodes from user
        Console.Write("Enter the number of nodes in the graph: ");
        int n = int.Parse(Console.ReadLine());

        // Initialize adjacency matrix for the graph
        bool[,] adjMatrix = new bool[n, n];

        // Accept edges from user until negative integer or out of range is entered
        int i = 0, j = 0;
        while (true)
        {
            Console.Write("Enter source node (negative to quit): ");
            i = int.Parse(Console.ReadLine());
            if (i < 0 || i >= n)
                break;

            Console.Write("Enter destination node: ");
            j = int.Parse(Console.ReadLine());
            if (j < 0 || j >= n || i == j || adjMatrix[i,j])
                continue;

            adjMatrix[i,j] = true;
            adjMatrix[j,i] = true;
        }

        // Find minimum number of symbols needed for node symbols
        char[] symbols = new char[n];
        int symbolCount = 0;
        for (i = 0; i < n; i++)
        {
            // Check if a symbol has already been assigned to adjacent nodes
            bool[] usedSymbols = new bool[symbolCount];
            for (j = 0; j < n; j++)
            {
                if (adjMatrix[i,j] && symbols[j] != '\0')
                {
                    usedSymbols[symbols[j] - 'A'] = true;
                }
            }

            // Assign a new symbol if necessary
            for (j = 0; j < symbolCount; j++)
            {
                if (!usedSymbols[j])
                {
                    symbols[i] = (char)('A' + j);
                    break;
                }
            }
            if (j == symbolCount)
            {
                symbols[i] = (char)('A' + symbolCount);
                symbolCount++;
            }
        }

        Console.WriteLine("Minimum number of symbols needed: " + symbolCount);
    }
}