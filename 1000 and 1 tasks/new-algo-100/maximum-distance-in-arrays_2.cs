public class Solution {
    // sorted  -> bin search


    // Passes 
    // 2 кучи или сортировка, все ранво лучше, чем квадрат
    // спускаем кучи или указатели
    // куча будет будет мб лучше, но сложность одинаковая
    public int MaxDistance(IList<IList<int>> arrays) {
        var maxes = new (int index, int val)[arrays.Count()];
        var mines = new (int index, int val)[arrays.Count()];

        for (int i = 0; i < arrays.Count(); i++) {
            maxes[i] = (i, arrays[i].Last());
            mines[i] = (i, arrays[i].First());
        }

        maxes = maxes.OrderBy(x => -x.val).ToArray();
        mines = mines.OrderBy(x => x.val).ToArray();

        var pMax = 0;
        var pMin = 0;
        var n = maxes.Length;

        var maxDiff = 0;

        while (pMax < n && pMin < n) {
            if (maxes[pMax].index != mines[pMin].index) {
                return Math.Abs(maxes[pMax].val - mines[pMin].val);
            }
            // есть куда свдигаться обоим
            else if (pMax < n - 1 && pMin < n - 1) {
                var diffMax = Math.Abs(maxes[pMax].val - maxes[pMax+1].val);
                var diffMin = Math.Abs(mines[pMin].val - mines[pMin+1].val);
                if (diffMax >= diffMin) {
                    pMin++;
                }
                else {
                    pMax++;
                }
            }
            else if (pMax < n - 1) {
                pMax++;
            }
            else {
                pMin++;
            }
        }

        return -1;

        // var max = 0;
        // for (int i = 0; i < arrays.Count(); i++) {
        //     for (int j = i + 1; j < arrays.Count(); j++) {
        //         max = Math.Max(Math.Abs(arrays[i].First() - arrays[j].Last()), max);
        //         max = Math.Max(Math.Abs(arrays[j].First() - arrays[i].Last()), max);
        //         // foreach (var a in arrays[i]) {
        //         //     foreach (var b in arrays[j]) {
        //         //         max = Math.Max(max, Math.Abs(a-b));
        //         //     }
        //         // }
        //     }
        // }

        // return max;
    }
}