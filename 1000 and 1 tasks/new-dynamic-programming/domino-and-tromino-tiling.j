import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// TL


class Solution {
    private int n;
    private int count = 0;

    private void F(int i) {
        if (i >= n) {
            count++;
            return;
        }

        // insert |
        F(i + 1);
        // insert =
        if (i < n - 1) {
            F(i + 2);
        }

        var diff = 2;
        while (i < n - diff) {
            // insert ?
            F(i + diff + 1);
            // insert ?
            F(i + diff + 1);
            diff++;
        }

//        //  :. ´: and vice versa
//        if (i < n - 2) {
//            // :.
//            F(i + 3);
//            // ´:
//            F(i + 3);
//        }
//        if (i < n - 3) {
//            // :. - .:
//            F(i + 4);
//            // :´ - ´:
//            F(i + 4);
//        }
//        if (i < n - 4) {
//            // ??
//            F(i + 5);
//            // ??
//            F(i + 5);
//        }
    }

    public int numTilings(int n) {
        this.n = n;

        F(0);

        return count;
    }
}
