// TL

public class Solution {
    // проверить на циклы, если есть то выходим
    // иначе просто идем по всем путям
    // backtraning ?

    // с какой вершины надо начать?

    private bool _hasCycles = false;
    private int _result = 0;
    // оптимизация заменить на список
    private bool[,] _connectedTable;
    private string _colors;

    private void F(int v, int[] colorsCount, bool[] visited) {
        // оптимиазция
        if (_hasCycles) {
            return;
        }

        var n = _colors.Length;
        for (int i = 0; i < n; i++) {
            if (_connectedTable[v,i]) {
                if (visited[i]) {
                    _hasCycles = true;
                    return;
                }
                else {
                    visited[i] = true;
                    colorsCount[_colors[i]-'a']++;
                    
                    F(i, colorsCount, visited);

                    visited[i] = false;
                    colorsCount[_colors[i]-'a']--;
                }
            }
        }

        if (!_hasCycles) {
            _result = Math.Max(_result, colorsCount.Max());
        }
    }

    public int LargestPathValue(string colors, int[][] edges) {
        _colors = colors;
        var n = colors.Length;
        _connectedTable = new bool[n,n];

        foreach (var ab in edges) {
            var a = ab.First();
            var b = ab.Last();
            _connectedTable[a,b] = true;
        }

        // место для оптимизации
        for (int i = 0; i < n && !_hasCycles; i++) {
            var colorsCount = new int[26];
            colorsCount[colors[i]-'a'] = 1;
            var visited = new bool[n];
            visited[i] = true;
            F(i, colorsCount, visited);
        }

        return _hasCycles ? -1 : _result;
    }
}