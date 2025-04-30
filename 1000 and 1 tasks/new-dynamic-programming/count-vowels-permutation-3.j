import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// prev + modulo


class Solution {
    private int n;

    private int F(int i, int prevC) {
        if (i == n) {
            return 1;
        }

        var result = 0;

        if (prevC == 0) {
            result += F(i + 1, 1);
            result %= 1000000007;
            result += F(i + 1, 2);
            result %= 1000000007;
            result += F(i + 1, 3);
            result %= 1000000007;
            result += F(i + 1, 4);
            result %= 1000000007;
            result += F(i + 1, 5);
            result %= 1000000007;
        }
        else {
            if (prevC == 2) {
                result += F(i + 1, 1);
                result %= 1000000007;
            }
            if (prevC == 1 || prevC == 3) {
                result += F(i + 1, 2);
                result %= 1000000007;
            }
            if (prevC != 3) {
                result += F(i + 1, 3);
                result %= 1000000007;
            }
            if (prevC == 3 || prevC == 5) {
                result += F(i + 1, 4);
                result %= 1000000007;
            }
            if (prevC == 1) {
                result += F(i + 1, 5);
                result %= 1000000007;
            }
        }

        return result;
    }

    public int countVowelPermutation(int n) {
        this.n = n;

        return F(0, 0);
    }
}
