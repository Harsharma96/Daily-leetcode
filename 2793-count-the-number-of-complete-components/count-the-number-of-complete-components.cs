public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];

            graph[u].Add(v);
            graph[v].Add(u);
        }

        bool[] visited = new bool[n];
        int completeComponents = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;

            int nodeCount = 0;
            int degreeSum = 0;

            DFS(i, graph, visited, ref nodeCount, ref degreeSum);

            if (degreeSum == nodeCount * (nodeCount - 1))
            {
                completeComponents++;
            }
        }

        return completeComponents;
    }

    private void DFS(
        int node,
        List<int>[] graph,
        bool[] visited,
        ref int nodeCount,
        ref int degreeSum)
    {
        visited[node] = true;
        nodeCount++;

        degreeSum += graph[node].Count;

        foreach (int neighbour in graph[node])
        {
            if (!visited[neighbour])
            {
                DFS(
                    neighbour,
                    graph,
                    visited,
                    ref nodeCount,
                    ref degreeSum
                );
            }
        }
    }
}