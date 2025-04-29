import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public int numTilings(int n) {
        var table = new int[n+1];
        for (var i = n; i >= 0; i--) {
            if (i == n) {
                table[i] = 1;
                continue;
            }

            var result = 0;
            // insert |
            result += table[i + 1];
            result %= 1000000007;
            // insert =
            if (i < n - 1) {
                result += table[i + 2];
                result %= 1000000007;
            }

            var diff = 2;
            while (i < n - diff) {
                // insert ?
                result += table[i + diff + 1];
                result %= 1000000007;
                // insert ?
                result += table[i + diff + 1];
                result %= 1000000007;
                diff++;
            }

            table[i] = result;
        }

        return table[0];
    }
}
