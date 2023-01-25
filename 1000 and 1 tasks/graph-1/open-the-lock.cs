public class Solution {
    // 4 circular wheels
    // 1 wheel = 10 digits '0'..'9'
    // The lock initially starts at '0000'
    // deadends forbidden numbers (count <= 500)

    // за один ход мы получаем 2 новых вариантов
    // полный перебор слишком большой на вид
    // опять же с цифрами мб проще работать
    // мб проще с конца?
    // сначала точно нужно попробовать полный перебор
    public int OpenLock(string[] deadends, string target) {
        var visited = new HashSet<(int a, int b, int c, int d)>();
        visited.Add((0, 0, 0 , 0));

        
        var t1 = target[0] - '0';
        var t2 = target[1] - '0';
        var t3 = target[2] - '0';
        var t4 = target[3] - '0';
        var targetParsed = (t1,t2,t3,t4);

        var queue = new Queue<(int a, int b, int c, int d, int steps)>();
        queue.Enqueue((0, 0, 0, 0, 0));

        foreach (var deadend in deadends) {
            if (deadend == "0000") {
                return -1;
            }
            
            var a = deadend[0] - '0';
            var b = deadend[1] - '0';
            var c = deadend[2] - '0';
            var d = deadend[3] - '0';

            visited.Add((a,b,c,d));
        }

        while (queue.Any()) {
            var (a,b,c,d,steps) = queue.Dequeue();

            if (targetParsed == (a,b,c,d)) {
                return steps;
            }

            // 1 st
            var aInc = a < 9 ? a + 1 : 0;
            var aDec = a > 0 ? a - 1 : 9;

            if (!visited.Contains((aInc, b, c, d))) {
                visited.Add((aInc, b, c, d));
                queue.Enqueue((aInc, b, c, d, steps+1));
            }
            if (!visited.Contains((aDec, b, c, d))) {
                visited.Add((aDec, b, c, d));
                 queue.Enqueue((aDec, b, c, d, steps+1));
            }

            var bInc = b < 9 ? b + 1 : 0;
            var bDec = b > 0 ? b - 1 : 9;

            if (!visited.Contains((a, bInc, c, d))) {
                visited.Add((a, bInc, c, d));
                queue.Enqueue((a, bInc, c, d, steps+1));
            }
            if (!visited.Contains((a, bDec, c, d))) {
                visited.Add((a, bDec, c, d));
                queue.Enqueue((a, bDec, c, d, steps+1));
            }

            var cInc = c < 9 ? c + 1 : 0;
            var cDec = c > 0 ? c - 1 : 9;

            if (!visited.Contains((a, b, cInc, d))) {
                visited.Add((a, b, cInc, d));
                 queue.Enqueue((a, b, cInc, d, steps+1));
            }
            if (!visited.Contains((a, b, cDec, d))) {
                visited.Add((a, b, cDec, d));
                 queue.Enqueue((a, b, cDec, d, steps+1));
            }

            var dInc = d < 9 ? d + 1 : 0;
            var dDec = d > 0 ? d - 1 : 9;

            if (!visited.Contains((a, b, c, dInc))) {
                visited.Add((a, b, c, dInc));
                 queue.Enqueue((a, b, c, dInc, steps+1));
            }
            if (!visited.Contains((a, b, c, dDec))) {
                visited.Add((a, b, c, dDec));
                 queue.Enqueue((a, b, c, dDec, steps+1));
            }
        }

        return -1;
    }
}