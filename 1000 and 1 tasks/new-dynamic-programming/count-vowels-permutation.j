import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// TL


class Solution {

    private int n;
    private int count = 0;

    private void F(int i, char prevC) {
        if (i == n) {
            count++;
            return;
        }

        if (prevC == ' ') {
            F(i + 1, 'a');
            F(i + 1, 'e');
            F(i + 1, 'i');
            F(i + 1, 'o');
            F(i + 1, 'u');
        }
        if (prevC == 'e') {
            F(i + 1, 'a');
        }
        if (prevC == 'a' || prevC == 'i') {
            F(i + 1, 'e');
        }
        if (prevC != 'i' && prevC != ' ') {
            F(i + 1, 'i');
        }
        if (prevC == 'i' || prevC == 'u') {
            F(i + 1, 'o');
        }
        if (prevC == 'a') {
            F(i + 1, 'u');
        }
    }

    public int countVowelPermutation(int n) {
        this.n = n;

        F(0, ' ');

        return this.count;
    }
}
