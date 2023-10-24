public class Solution {
    private bool[] _visited;
    private int _result = 0;
    private int[][] _isConnected;

    private void Process(int i) {
        _result++;

        var queue = new Queue<int>();
        _visited[i] = true;
        queue.Enqueue(i);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            for (int j = 0; j < _isConnected[cur].Length; j++) {
                if (_isConnected[cur][j] == 1 && !_visited[j]) {
                    _visited[j] = true;
                    queue.Enqueue(j);                 
                }
            }
        }
    }

    public int FindCircleNum(int[][] isConnected) {
        _visited = new bool[isConnected.Count()];
        _isConnected = isConnected;

        for (int i = 0; i < isConnected.Count(); i++) {
            if (_visited[i]) {
                continue;
            }
            Process(i);
        }

        return _result;
    }
}