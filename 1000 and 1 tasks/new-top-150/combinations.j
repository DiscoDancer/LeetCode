import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;
import java.util.stream.Collectors;

class Solution {
    private List<List<Integer>> result = new LinkedList<>();
    private int n;
    private int k;

    private void F(int i, int[] arr, int start) {
        if (i == k) {
            List<Integer> list = Arrays.stream(arr)
                    .boxed()
                    .collect(Collectors.toList());
            result.add(list);
            return;
        }

        for (int num = start; num <= n; num++) {
            arr[i] = num;
            F(i + 1, arr, num + 1);
        }
    }

    public List<List<Integer>> combine(int n, int k) {
        this.n = n;
        this.k = k;

        F(0, new int[k], 1);

        return result;
    }
}