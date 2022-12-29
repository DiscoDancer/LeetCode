public class Solution {
    // написать компоратор для массивчика
    // можно построить Tri (но мне это ничего не дает на вид)
    public bool IsAlienSorted(string[] words, string order) {
        if (words.Length == 1) {
            return true;
        }

        var orderArr = order.ToCharArray();

        var prev = words[0];
        for (int i = 1; i < words.Length; i++) {
            var cur = words[i];
            // prev

            var p1 = 0;
            var p2 = 0;

            var areSameSoFar = true;
            while (areSameSoFar && p1 < prev.Length && p2 < cur.Length) {
                var a = Array.IndexOf(orderArr,prev[p1]);
                var b = Array.IndexOf(orderArr,cur[p2]);

                if (a > b) {
                    return false;
                }
                if (areSameSoFar && a != b) {
                    areSameSoFar = false;
                }

                p1++;
                p2++;
            }

            if (areSameSoFar && prev.Length > cur.Length) {
                return false;
            }

            prev = cur;
        }

        return true;
    }
}