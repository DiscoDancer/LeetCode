import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// prev + no global var


class Solution {
    private int n;

    private int F(int i, int prevC) {
        if (i == n) {
            return 1;
        }

        var result = 0;

        if (prevC == 0) {
            result += F(i + 1, 1);
            result += F(i + 1, 2);
            result += F(i + 1, 3);
            result += F(i + 1, 4);
            result += F(i + 1, 5);
        }
        else {
            if (prevC == 2) {
                result += F(i + 1, 1);
            }
            if (prevC == 1 || prevC == 3) {
                result += F(i + 1, 2);
            }
            if (prevC != 3) {
                result += F(i + 1, 3);
            }
            if (prevC == 3 || prevC == 5) {
                result += F(i + 1, 4);
            }
            if (prevC == 1) {
                result += F(i + 1, 5);
            }
        }

        return result;
    }

    public int countVowelPermutation(int n) {
        this.n = n;

        return F(0, 0);
    }
}
