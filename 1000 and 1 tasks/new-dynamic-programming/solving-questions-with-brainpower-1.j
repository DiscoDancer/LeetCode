import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public long mostPoints(int[][] questions) {
        var table = new long[questions.length + 1];
        for (var i = questions.length - 1; i >= 0; i--) {
            var skip = table[i + 1];
            var take = questions[i][0] + (i + questions[i][1] + 1 >= questions.length ? 0:  table[i + questions[i][1] + 1]);
            table[i] = Math.max(take, skip);
        }

        return table[0];
    }
}
