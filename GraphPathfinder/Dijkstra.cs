using System;
using System.Collections.Generic;

namespace GraphPathfinder
{
    public class Dijkstra
    {
        public static int[] FindPath(int [,] graph, int beginNode, int endNode)
        {
            var size = graph.GetLength(0);
            if (graph.Length != size * size)
                return new int[0];

            var minDistance = new int[size];
            var visitedNodes = new int [size];
            
            // Init values
            for (int i = 0; i < size; i++)
            {
                minDistance[i] = int.MaxValue;
                visitedNodes[i] = 1;
            }

            minDistance[beginNode] = 0; // Distance to the first node is 0
            int minIndex, minNodeDistance;
            do
            {
                minIndex = minNodeDistance = int.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    // If node isn't visited yet and current distance is less than min
                    if (visitedNodes[i] == 1 && minDistance[i] < minNodeDistance)
                    {
                        minNodeDistance = minDistance[i];
                        minIndex = i;
                    }
                }

                // Add found minimal distance to current node distance
                // and compare with current min distance
                if (minIndex != int.MaxValue)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (graph[minIndex, i] > 0)
                        {
                            var temp = minNodeDistance + graph[minIndex, i];
                            if (temp < minDistance[i])
                                minDistance[i] = temp;
                        }
                    }
                    visitedNodes[minIndex] = 0;
                }
            } while (minIndex < int.MaxValue);

            // Restore path
            visitedNodes = new int[size];
            visitedNodes[0] = endNode; // Start from end
            var k = 1; // Index for next visited node
            int distance = minDistance[endNode]; // Total distance to end node

            while (endNode != beginNode)
            {
                for (int i = 0; i < size; i++)
                {
                    if (graph[i, endNode] != 0)
                    {
                        var temp = distance - graph[i, endNode]; // Total distance minus distance current node
                        if (temp == minDistance[i]) // If match, that's the shortest path
                        {
                            distance = temp;
                            visitedNodes[k] = endNode = i;
                            k++;
                        }
                    }
                }
            }

            // Save path to new array
            List<int> path = new List<int>();
            for (int i = k - 1; i >= 0; i--)
            {
                path.Add(visitedNodes[i]);
            }

            return path.ToArray();
        }
    }
}
