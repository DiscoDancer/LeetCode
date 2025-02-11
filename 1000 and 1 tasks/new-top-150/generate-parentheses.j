import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

class Solution {
    private List<String> result = new LinkedList<>();
    private int n;

    private void F(char[] arr, int index, int openTotalCount, int openedCount) {
        if (index == n*2) {
            result.add(new String(arr));
            return;
        }

        // can we open a parenthesis?
        if (openTotalCount < n) {
            arr[index] = '(';
            F(arr, index + 1, openTotalCount + 1, openedCount + 1);
        }
        // can we close a parenthesis?
        if (openedCount > 0) {
            arr[index] = ')';
            F(arr, index + 1, openTotalCount, openedCount - 1);
        }
    }

    public List<String> generateParenthesis(int n) {
        this.n = n;

        F(new char[2 * n], 0, 0, 0);

        return result;
    }
}