import java.util.*;


class Solution {
    
    private int binarySearch(ArrayList<int[]> arr, int[] key) {
        var l = 0;
        var r = arr.size() - 1;
        
        while (l <= r) {
            var m = (r-l) / 2 + l;
            if (key[1] < arr.get(m)[1] && (m == 0 || key[1] > arr.get(m-1)[1])) {
                return m;
            }
            else if (key[1] > arr.get(m)[1]) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }
        
        return -1;
    }

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
                var j = binarySearch(perfectList, pair);
                if (j != -1) {
                    perfectList.set(j, pair);
                }
            }
        }


        return perfectList.size();
    }
}
