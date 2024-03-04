public class Solution {
    public bool IsStrobogrammatic(string num) {
        var l = 0;
        var r = num.Length - 1;

        while (l <= r) {
            var eight = num[l] == num[r] && num[l] == '8';
            var zero = num[l] == num[r] && num[l] == '0';
            var one = num[l] == num[r] && num[l] == '1';
            var sixtyNine = num[l] == '6' && num[r] == '9' || num[l] == '9' && num[r] == '6';

            if (!(eight || zero || sixtyNine || one)) {
                return false;
            }

            l++;
            r--;
        }

        return true;
    }
}