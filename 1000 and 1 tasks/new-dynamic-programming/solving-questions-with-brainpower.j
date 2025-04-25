import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// tl

class Solution {

    private int[][] questions;

    private long F(int i) {
        if (i >= questions.length) {
            return 0;
        }

        var skip = F(i + 1);
        var take = questions[i][0] + F(i + questions[i][1] + 1);

        return Math.max(take, skip);
    }

    public long mostPoints(int[][] questions) {
        this.questions = questions;

        return F(0);
    }
}
