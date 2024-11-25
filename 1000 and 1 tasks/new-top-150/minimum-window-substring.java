import java.util.*;

public class Solution {

    public String minWindow(String s, String t) {
        var tMap = new HashMap<Character, Integer>();
        for (var c : t.toCharArray()) {
            tMap.put(c, tMap.getOrDefault(c, 0) + 1);
        }

        String result = "";
        var min = Integer.MAX_VALUE;

        for (var left = 0; left < s.length(); left++) {
            for (var right = left; right < s.length(); right++) {
                var sub = s.substring(left, right + 1);

                var isValid = true;
                for (var key : tMap.keySet()) {
                    var count = tMap.get(key);
                    if (sub.chars().filter(c -> c == key).count() < count) {
                        isValid = false;
                        break;
                    }
                }
                if (isValid && sub.length() < min) {
                    min = sub.length();
                    result = sub;
                }
            }
        }
        return result;
    }
}