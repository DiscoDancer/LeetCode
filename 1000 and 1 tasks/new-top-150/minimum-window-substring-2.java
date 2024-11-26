// my, accepted
class Solution {
    private boolean isMatch(int[] sTableSmall, int[] sTableBig, int[] tTableSmall, int[] tTableBig) {
        for (var i = 0; i < 26; i++) {
            if (sTableSmall[i] < tTableSmall[i] || sTableBig[i] < tTableBig[i]) {
                return false;
            }
        }

        return true;
    }

    public String minWindow(String s, String t) {
        var tTableSmall = new int[26];
        var tTableBig = new int[26];

        for (var c : t.toCharArray()) {
            if (c >= 'a' && c <= 'z') tTableSmall[c - 'a']++;
            else tTableBig[c - 'A']++;
        }

        var sTableSmall = new int[26];
        var sTableBig = new int[26];

        var min_len = Integer.MAX_VALUE;
        var res = "";

        var left = 0;
        for (var right = 0; right < s.length(); right++) {
            var c = s.charAt(right);
            if (c >= 'a' && c <= 'z') sTableSmall[c - 'a']++;
            else sTableBig[c - 'A']++;

            if (isMatch(sTableSmall, sTableBig, tTableSmall, tTableBig)) {
                var sub = s.substring(left, right + 1);
                if (sub.length() < min_len) {
                    min_len = sub.length();
                    res = sub;
                }

                var shouldTryShrink = true;
                while (shouldTryShrink) {
                    c = s.charAt(left);
                    if (c >= 'a' && c <= 'z') sTableSmall[c - 'a']--;
                    else sTableBig[c - 'A']--;

                    if (isMatch(sTableSmall, sTableBig, tTableSmall, tTableBig)) {
                        left++;
                        sub = s.substring(left, right + 1);
                        if (sub.length() < min_len) {
                            min_len = sub.length();
                            res = sub;
                        }
                    } else {
                        shouldTryShrink = false;
                        if (c >= 'a' && c <= 'z') sTableSmall[c - 'a']++;
                        else sTableBig[c - 'A']++;
                    }
                }
            }

            // всегда смещаем левую границу, если уже есть хоть какое-то окно
            if (res != "") {
                c = s.charAt(left);
                if (c >= 'a' && c <= 'z') sTableSmall[c - 'a']--;
                else sTableBig[c - 'A']--;
                left++;
            }
        }

        return res;
    }
}