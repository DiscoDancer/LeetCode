/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

// editorial

class Solution {
    private HashSet<(int,int)> _visited = new ();
    private Robot _robot;

    private void GoStepBackSavingCurrentDirection() {
        _robot.TurnRight();
        _robot.TurnRight();
        _robot.Move();
        _robot.TurnRight();
        _robot.TurnRight();
    }

    // top, right, bottom, left
    private int[][] _directions = new int[][] {new int[]{-1,0}, new int[]{0,1}, new int[]{1,0}, new int[]{0,-1}};

    public void DFS((int x, int y) position, int d) {
        _robot.Clean();
        _visited.Add(position);

        var (x,y) = position;

        for (int i = 0; i < 4; i++) {
            var newD = (i+d) % 4;
            var newX = x + _directions[newD][0];
            var newY = y + _directions[newD][1];

           if (!_visited.Contains((newX, newY)) && _robot.Move()) {
               DFS((newX, newY), newD);
               GoStepBackSavingCurrentDirection();
           }

           _robot.TurnRight();
        }
    }


    public void CleanRoom(Robot robot) {
        _robot = robot;
        DFS((0,0), 0);
    }
}