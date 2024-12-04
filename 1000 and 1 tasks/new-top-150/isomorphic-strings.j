class Solution {
    public boolean isIsomorphic(String s, String t) {
        int[] sMap = new int[256];
        var sIndex = 1;
        for (var i = 0; i < s.length(); i++) {
            var sChar = s.charAt(i);
            if (sMap[sChar] == 0) {
                sMap[sChar] = sIndex++;
            }
        }

        var tMap = new int[256];
        var tIndex = 1;
        for (var i = 0; i < t.length(); i++) {
            var tChar = t.charAt(i);
            if (tMap[tChar] == 0) {
                tMap[tChar] = tIndex++;
            }
        }

        if (s.length() != t.length()) {
            return false;
        }

        for (var i = 0; i < s.length(); i++) {
            if (sMap[s.charAt(i)] != tMap[t.charAt(i)]) {
                return false;
            }
        }
        
        return true;
    }
}