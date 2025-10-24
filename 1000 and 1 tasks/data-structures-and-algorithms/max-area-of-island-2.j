import java.util.*;


class Solution {
    public record Pair(int x, int y) {}

    public class UnionFind {
        private int[] _root;
        private int[] _rank;
        private int _size;

        public UnionFind(int n) {
            _size = n;
            _root = new int[n];
            _rank = new int[n];
            for (int i = 0; i < n; i++) {
                _root[i] = i;
                _rank[i] = 1;
            }
        }

        public int find(int x) {
            if (x == _root[x]) {
                return x;
            }

            return _root[x] = find(_root[x]);
        }

        public void union(int x, int y) {
            var rootX = find(x);
            var rootY = find(y);

            if (rootX == rootY) {
                return;
            }
            else if (_rank[rootX] > _rank[rootY]) {
                _root[rootY] = rootX;
            }
            else if (_rank[rootX] < _rank[rootY]) {
                _root[rootX] = rootY;
            }
            else {
                _root[rootY] = rootX;
                _rank[rootX] ++;
            }
        }
    }

    public int maxAreaOfIsland(int[][] grid) {
        var X = grid.length;
        var Y = grid[0].length;

        var uf =  new UnionFind(X*Y);

        var anyIsland = false;

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid[x][y] == 0) {
                    continue;
                }
                anyIsland = true;

                if (x < X - 1 && grid[x+1][y] == 1) {
                    uf.union(x*Y+y, (x+1)*Y+y);
                }
                if (x > 0 && grid[x-1][y] == 1) {
                    uf.union(x*Y+y, (x-1)*Y+y);
                }
                if (y < Y - 1 && grid[x][y+1] == 1) {
                    uf.union(x*Y+y, x*Y+y+1);
                }
                if (y > 0 && grid[x][y-1] == 1) {
                    uf.union(x*Y+y, x*Y+y-1);
                }
            }
        }

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                uf.find(x*Y+y);
            }
        }

        var table = new int[X*Y];
        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                table[uf._root[x*Y+y]]++;
            }
        }

        if (!anyIsland) {
            return 0;
        }

        return Arrays.stream(table).max().getAsInt();
    }
}