import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private int n;

    private int F(int i) {
        if (i >= n) {
            return 1;
        }

        var result = 0;

        // insert |
        result += F(i + 1);
        // insert =
        if (i < n - 1) {
            result += F(i + 2);
        }

        var diff = 2;
        while (i < n - diff) {
            // insert ?
            result += F(i + diff + 1);
            // insert ?
            result += F(i + diff + 1);
            diff++;
        }

        return result;
    }

    public int numTilings(int n) {
        this.n = n;

        return F(0);
    }
}
