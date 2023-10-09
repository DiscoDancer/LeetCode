public class Solution {
    private bool IsVowel (char c) {
        c = char.ToLower(c);
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    public string ReverseVowels(string s) {
        var arr = s.ToCharArray();

        var l = 0;
        var r = s.Length - 1;

        while (l < r) {
            while (l < s.Length - 1 && !IsVowel(s[l])) {
                l++;
            }
            while (r >= 0 && !IsVowel(s[r])) {
                r--;
            }
            if (l < r) {
                var tmp = arr[l];
                arr[l] = arr[r];
                arr[r] = tmp;
                l++;
                r--;
            }
        }

        return new string(arr);
    }
}