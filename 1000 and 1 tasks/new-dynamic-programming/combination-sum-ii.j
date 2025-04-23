import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private ArrayList<Entry> candidates;
    private List<List<Entry>> result = new ArrayList<>();

    public record Entry(int sum, int source) {}

    private void F(int curSum, List<Entry> curList, int i0) {
        if (curSum == 0) {
            // copy
            result.add(new ArrayList<>(curList));
            return;
        }
        if (curSum < 0) {
            // dead end
            return;
        }

        for (var i = i0; i < candidates.size(); i++) {

            // перекидывает на следующий уникальный элемент
            // потому что все комбинации одного и того же - взаимоисключающие
            var j = i + 1;
            while (j < candidates.size() && candidates.get(i).source == candidates.get(j).source) {
                j++;
            }
            // it is safe for j to be out of bounds
            var l = curList.size();
            curList.add(candidates.get(i));
            F(curSum - candidates.get(i).sum, curList, j);
            curList.remove(l);
        }
    }

    public List<List<Integer>> combinationSum2(int[] candidates, int target) {
        // можем и хэш таблицу, но их очень мало
        Arrays.sort(candidates);


        var i = 0;
        var entries = new ArrayList<Entry>();

        while (i < candidates.length) {
            var j = i;
            var sum = 0;
            var source = candidates[i];
            while (j < candidates.length && candidates[j] == candidates[i]) {
                sum += candidates[j];
                entries.add(new Entry(sum, source));
                j++;
            }
            i = j;
        }

        this.candidates = entries;

        var list = new ArrayList<Entry>();
        F(target, list, 0);

        // преобразуем в нужный формат
        List<List<Integer>> resultResult = new ArrayList<>();
        for (var l:result) {
            var sub = new ArrayList<Integer>();
            for (var e:l) {
                if (e.source == e.sum) {
                    sub.add(e.source);
                } else {
                    for (var j = 0; j < e.sum / e.source; j++) {
                        sub.add(e.source);
                    }
                }
            }
            resultResult.add(sub);
        }

        return resultResult;
    }
}
