public class Solution {
    // vertices 0..n-1
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        var fromTable = new Dictionary<int, List<int>>();
        var toTable = new Dictionary<int, List<int>>();

        foreach (var e in edges) {
            var from = e.First();
            var to = e.Last();

            if (!fromTable.ContainsKey(from)) {
                fromTable[from] = new List<int>();
            }
            fromTable[from].Add(to);

            if (!toTable.ContainsKey(to)) {
                toTable[to] = new List<int>();
            }
            toTable[to].Add(from);
        }

        // unreachable сразу кладем
        var noYetReached = Enumerable.Range(0, n).ToList();

        var res = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!toTable.ContainsKey(i)) {
                res.Add(i);
                noYetReached.Remove(i);

                if (fromTable.ContainsKey(i)) {
                    foreach (var to in fromTable[i]) {
                        noYetReached.Remove(to);
                    }
                }
            }
        }

        // var r = noYetReached.Count();
        // while (r > 0) {

        // }

        // сколько осталось

        return res;

        // мб выписать откуда кто доступен
        // canReachTable и canBeReachedFromTable

        // полный перебор выглядит как берем по 1, смотрим ок не ок, дальше начинаем брать по 2 и тд
        // но n довольно большой
        // это решение с canReachTable

        // а если с canBeReachedFromTable ?
        // тут можно canBeReachedFromTable[x] == 1 (ниоткуда кроме себя) сразу добавлять в ответ
        // походу больше ничего и не требуется
    }
}