public class Solution {
    // неверно
    public int LongestPalindromeSubseq(string s) {
        var max = 0;
        for (int i = 0; i < s.Length; i++) {
            var l1 = TryExpand(s, i, i);
            var l2 = TryExpand(s, i, i+1);
            var l = Math.Max(l1,l2);

            if (l > max) {
                max = l;
            }
        }

        return max;
    }

    public int TryExpand(string s, int l, int r) {
        var count = 0;
        while (l >= 0 && r <= s.Length -1) {
            if (s[l] == s[r]) {
                count += l==r ? 1 : 2;
                l--;
                r++;
            }
            else { // не равны, можем пойти вправо, можем пойти влево

                // идем в право
                var l1 = l;
                var r1 = r;

                while (r1 <= s.Length -1 && s[l1] != s[r1]) {
                    r1++;
                }
                if (r1 < s.Length) // нашелся 
                {
                    r = r1;
                    l = l1;
                    continue;
                }

                // идем влево
                var l2 = l;
                var r2 = r;
                while (l2 >= 0 && s[r2] != s[l2]) {
                    l2--;
                }
                if (l2 >= 0) {
                    r = r2;
                    l = l2;
                    continue;
                }

                l--;
                r++;
            }
        }
        return count;
    }
}