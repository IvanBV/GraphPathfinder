using Xunit;
using GraphPathfinder;

namespace GraphPathfinder.Tests
{
    public class GraphPathfinder_Tests
    {

        private int [,] _graph =    {{0, 4, 15, 0, 0, 0, 0, 0, 0},
                                    {4, 0, 0, 0, 5, 11, 0, 0, 0},
                                    {15, 0, 0, 13, 0, 0, 20, 3, 0},
                                    {0, 0, 13, 0, 2, 0, 0, 0, 0},
                                    {0, 5, 0, 2, 0, 0, 7, 0, 0},
                                    {0, 11, 0, 0, 0, 0, 19, 13, 0},
                                    {0, 0, 20, 0, 7, 19, 0, 0, 0},
                                    {0, 0, 3, 0, 0, 13, 0, 0, 9},
                                    {0, 0, 0, 0, 0, 0, 0, 9, 0}};


        [Fact]
        public void FindPath_25()
        {
            int [] path = {2, 7, 5};
            Assert.Equal(path, Dijkstra.FindPath(_graph, 2, 5));
        }
        [Fact]

        public void FindPath_06()
        {
            int [] path = {0, 1, 4, 6};
            Assert.Equal(path, Dijkstra.FindPath(_graph, 0, 6));
        }

        [Fact]
        public void FindPath_38()
        {
            int [] path = {8, 7, 2, 3};
            Assert.Equal(path, Dijkstra.FindPath(_graph, 8, 3));
        }
    }
}