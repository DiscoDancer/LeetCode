import java.util.*;

// почему это вообще работает, нужно смотреть оригинальную задачу
// про максимальную подпоследователось


class Solution {

    public int findLongestChain(int[][] pairs) {

        // Sort based on the first element of each row
        // это очень важно при построении жадного алгоритма. Потому что у следующего элемента всегда будет [0] >= [0] предыдущего
        Arrays.sort(pairs, Comparator.comparingInt(a -> a[0]));

        var perfectList = new ArrayList<int[]>();
        perfectList.add(pairs[0]);

        for (var i = 1; i < pairs.length; i++) {
            var pair = pairs[i];
            if (pair[0] > perfectList.get(perfectList.size()-1)[1]) {
                perfectList.add(pair);
            } else {
                // я должен уменьшить самого большого, довольно жадно
                // значит я должен искать его с конца
                // новый элемент не может уменьшить [0], но может уменьшить [1]
                var j = perfectList.size() - 1;
                while (j >= 0) {
                    if (pair[1] < perfectList.get(j)[1]) {
                        // предыдущего либо нет, либо он меньше
                        if (j == 0 || pair[1] > perfectList.get(j - 1)[1]) {
                            perfectList.set(j, pair);
                            break;
                        }
                    }
                    j--;
                }
            }
        }


        return perfectList.size();
    }
}
