public class Solution {
    // жадный или перебор
    // i need only vertexes, which has no incoming
    // todo объяснить почему

    /*
        Почему так?
        
        Если посмотреть на цепочку a -> b -> c, то можно заметить, что если мы возьмем c, то получим только c. b - b + c.
        Значит оптимально брать a. 
        Таким образом граф разбивается на несколько цепочек, и значит нас интересует только вершины, в которые никто не приходит.
    */

    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        var hasIncomingTable = new bool[n];
        foreach (var edge in edges) {
            // a -> b
            var a = edge.First();
            var b = edge.Last();

            hasIncomingTable[b] = true;
        }

        var result = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!hasIncomingTable[i]) {
                result.Add(i);
            }
        }

        return result;
    }
}