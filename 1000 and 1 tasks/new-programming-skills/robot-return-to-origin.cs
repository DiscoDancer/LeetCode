public class Solution {
    public bool JudgeCircle(string moves) {
        var x = 0;
        var y = 0;

        foreach (var m in moves) {
            if (m == 'R') x++;
            else if (m == 'L') x--;
            else if (m == 'D') y--;
            else if (m == 'U') y++;
        }

        return x == 0 && y == 0;
    }
}