import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

class Solution {

    private int[] nums;
    private final List<List<Integer>> result = new ArrayList<>();

    private void F(int i, int[] arr, boolean[] visited) {
        if (i == nums.length) {
            List<Integer> list = Arrays.stream(arr)
                    .boxed()
                    .collect(Collectors.toList());

            result.add(list);
            return;
        }

        for (int j = 0; j < nums.length; j++) {
            if (!visited[j]) {
                visited[j] = true;
                arr[i] = nums[j];
                F(i + 1, arr, visited);
                visited[j] = false;
            }
        }
    }

    public List<List<Integer>> permute(int[] nums) {
        this.nums = nums;

        F(0, new int[nums.length], new boolean[nums.length]);

        return result;
    }
}