import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// TL
// encoded


class Solution {

    private int n;
    private int count = 0;

    private void F(int i, int prevC) {
        if (i == n) {
            count++;
            return;
        }

        if (prevC == 0) {
            F(i + 1, 1);
            F(i + 1, 2);
            F(i + 1, 3);
            F(i + 1, 4);
            F(i + 1, 5);
        }
        if (prevC == 2) {
            F(i + 1, 1);
        }
        if (prevC == 1 || prevC == 3) {
            F(i + 1, 2);
        }
        if (prevC != 3 && prevC != 0) {
            F(i + 1, 3);
        }
        if (prevC == 3 || prevC == 5) {
            F(i + 1, 4);
        }
        if (prevC == 1) {
            F(i + 1, 5);
        }
    }

    public int countVowelPermutation(int n) {
        this.n = n;

        F(0, 0);

        return this.count;
    }
}
