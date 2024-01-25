public class Solution {
    public void dfs(int[][] maze, int[] start, int[][] distance) {
        var dirs = new []{new []{0,1}, new []{0,-1}, new []{-1,0}, new []{1,0}};
        foreach (var dir in dirs) {
            int x = start[0] + dir[0];
            int y = start[1] + dir[1];
            int count = 0;
            while (x >= 0 && y >= 0 && x < maze.Length && y < maze[0].Length && maze[x][y] == 0) {
                x += dir[0];
                y += dir[1];
                count++;
            }
            if (distance[start[0]][start[1]] + count < distance[x - dir[0]][y - dir[1]]) {
                distance[x - dir[0]][y - dir[1]] = distance[start[0]][start[1]] + count;
                dfs(maze, new int[]{x - dir[0],y - dir[1]}, distance);
            }
        }
    }

    // editorial
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        var distance = new int[maze.Length][];
        for (int i = 0; i < maze.Length; i++) {
            distance[i] = new int[maze[0].Length];
            Array.Fill(distance[i], int.MaxValue);
        }
        distance[start[0]][start[1]] = 0;
        dfs(maze, start, distance);
        return distance[destination[0]][destination[1]] == int.MaxValue ? -1 : distance[destination[0]][destination[1]];
    }
}