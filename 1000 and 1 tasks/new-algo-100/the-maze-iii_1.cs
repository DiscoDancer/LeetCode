public class Solution {
    public class State
    {
        public int row;
        public int col;
        public int dist;
        public string path;

        public State(int row, int col, int dist, string path)
        {
            this.row = row;
            this.col = col;
            this.dist = dist;
            this.path = path;
        }
    }
    
    private int[][] directions = new int[][]{new int[]{0, -1}, new int[]{-1, 0}, new int[]{0, 1}, new int[]{1, 0}};
    private string[] textDirections = new String[]{"l", "u", "r", "d"};
    private int m;
    private int n;
    
    private bool valid(int row, int col, int[][] maze) {
        if (row < 0 || row >= m || col < 0 || col >= n) {
            return false;
        }

        return maze[row][col] == 0;
    }
    
    private List<State> getNeighbors(int row, int col, int[][] maze, int[] hole) {
        var neighbors = new List<State>();
        
        for (int i = 0; i < 4; i++) {
            var dy = directions[i][0];
            var dx = directions[i][1];
            var direction = textDirections[i];
            
            var currRow = row;
            var currCol = col;
            var dist = 0;
            
            while (valid(currRow + dy, currCol + dx, maze)) {
                currRow += dy;
                currCol += dx;
                dist++;
                if (currRow == hole[0] && currCol == hole[1]) {
                    break;
                }
            }
            
            neighbors.Add(new State(currRow, currCol, dist, direction));
        }
        
        return neighbors;
    }

    // editorial
    public string FindShortestWay(int[][] maze, int[] ball, int[] hole)
    {
        m = maze.Length;
        n = maze[0].Length;
        
        // https://stackoverflow.com/questions/71306396/use-lambda-comparator-with-priorityqueue
        var heap = new PriorityQueue<State, State>(Comparer<State>.Create((a, b) =>
        {
            int distA = a.dist;
            int distB = b.dist;
            
            if (distA == distB) {
                return a.path.CompareTo(b.path);
            }
            
            return distA - distB;
        }));
        
        var seen = new bool[m,n];
        var state = new State(ball[0], ball[1], 0, "");
        heap.Enqueue(state, state);

        while (heap.Count > 0)
        {
            var curr = heap.Dequeue();
            var row = curr.row;
            var col = curr.col;
            
            if (seen[row,col]) {
                continue;
            }
            
            if (row == hole[0] && col == hole[1]) {
                return curr.path;
            }
            seen[row,col] = true;
            
            foreach (var  nextState in getNeighbors(row, col, maze, hole)) {
                var nextRow = nextState.row;
                var nextCol = nextState.col;
                var nextDist = nextState.dist;
                var nextChar = nextState.path;
                var next = new State(nextRow, nextCol, curr.dist + nextDist, curr.path + nextChar);
                heap.Enqueue(next, next);
            }
        }
        
        return "impossible";
    }
}