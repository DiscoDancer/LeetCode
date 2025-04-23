import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private ArrayList<Integer> candidates;
    private List<List<Integer>> result = new ArrayList<>();

    private void F(int curSum, List<Integer> curList, int i0) {
        if (curSum == 0) {
            // copy
            result.add(new ArrayList<>(curList));
            return;
        }
        if (curSum < 0) {
            // dead end
            return;
        }

        // переключаем i вручную !
        for (var i = i0; i < candidates.size(); ) {
            var j = i;
            var count = 0;
            var source = candidates.get(i);

            while (j < candidates.size() && candidates.get(j) == candidates.get(i)) {
                count++;
                j++;
            }

            var l = curList.size();
            // перебираем все возможные комбинации одинаковых элементов
            // и важно что j - всегда указывает на следующий или на конец
            for (var c = 1; c <= count; c++) {
                curList.add(source);
                F(curSum - source * c, curList, j);
            }
            for (var c = 1; c <= count; c++) {
                curList.remove(l);
            }

            i = j;
        }
    }

    public List<List<Integer>> combinationSum2(int[] candidates, int target) {
        // можем и хэш таблицу, но их очень мало
        Arrays.sort(candidates);
        this.candidates = new ArrayList<>(candidates.length);
        for (var i : candidates) {
            this.candidates.add(i);
        }

        var list = new ArrayList<Integer>();
        F(target, list, 0);


        return this.result;
    }
}
