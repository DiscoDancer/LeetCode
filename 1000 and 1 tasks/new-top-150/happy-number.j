import java.util.*;
import java.util.stream.Collectors;

public class Solution {

    public boolean isHappy(int n) {
        var hs = new HashSet<Integer>();
        while (n != 1 && hs.add(n)) {
            n = Arrays.stream(String.valueOf(n).split(""))
                    .mapToInt(Integer::parseInt)
                    .map(i -> i * i)
                    .sum();
        }
        return n == 1;
    }
}