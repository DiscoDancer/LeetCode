import java.util.*;


class Solution {
    public String makeGood(String s) {
        var buffer = new StringBuilder();

        for (char c : s.toCharArray()) {
            if (!buffer.isEmpty()) {
                var prevC = buffer.charAt(buffer.length() - 1);
                if (prevC != c && Character.toUpperCase(prevC) == Character.toUpperCase(c)) {
                    buffer.deleteCharAt(buffer.length() - 1);
                }
                else {
                    buffer.append(c);
                }
            }
            else {
                buffer.append(c);
            }
        }



        return buffer.toString();
    }
}