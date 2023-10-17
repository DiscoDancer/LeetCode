public class Solution {
    public string PredictPartyVictory(string senate) {
        var queue = new Queue<char>();
        var R = 0;
        var D = 0;
        foreach (var c in senate) {
            queue.Enqueue(c);
            if (c == 'R'){
                R++;
            }
            if (c == 'D') {
                D++;
            }
        }

        var r = 0;
        var d = 0;
        while (R != 0 && D != 0) {
            var cur = queue.Dequeue();

            if (cur == 'D') {
                if (r > 0) {
                    r--;
                    D--;
                }
                else {
                   d++;
                   queue.Enqueue(cur); 
                }
            }
            else if (cur == 'R') {
                if (d > 0) {
                    d--;
                    R--;
                }
                else {
                    r++;
                    queue.Enqueue(cur);
                }
            }
        }

        if (R != 0) {
            return "Radiant";
        }
        return "Dire";
    }
}