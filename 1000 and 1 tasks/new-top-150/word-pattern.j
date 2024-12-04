import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

public class Solution {
    public boolean wordPattern(String pattern, String s) {
        var patternMap = new int[26];
        var patternIndex = 1;
        // can be array
        var patternList = new ArrayList<Integer>();
        for (var i = 0; i < pattern.length(); i++) {
            var chIndex = pattern.charAt(i) - 'a';
            if (patternMap[chIndex] == 0) {
                patternMap[chIndex] = patternIndex++;
            }
            patternList.add(patternMap[chIndex]);
        }

        var sMap = new HashMap<String, Integer>();
        var sIndex = 1;
        var sWords = s.split(" ");
        var sList = new ArrayList<Integer>();
        for (var word : sWords) {
            if (!sMap.containsKey(word)) {
                sMap.put(word, sIndex++);
            }
            sList.add(sMap.get(word));
        }

        return Arrays.equals(patternList.toArray(), sList.toArray());
    }
}