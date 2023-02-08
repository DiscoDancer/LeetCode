public class Solution {
    // в дереве между 2мя узлами только 1 путь
    // цикла тоже нету
    // undirected
    // nodes: 0..n-1
    // нужно корень выбрать так, чтобы высота была минимальной => их несколько

    /*
        Идеи:
        - не надо in out, а только степень
        - мб обратный порядок? но врятли начну с обычного. (со степени 1)
        - сделать сортировку, взять ответы с конца с максим
    */
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        var table = new List<int>[n];
        for (int i = 0; i < n; i++) {
            table[i] = new ();
        }

        foreach (var e in edges) {
            table[e[0]].Add(e[1]);
            table[e[1]].Add(e[0]);
        }

        var queue = new Queue<int>();
        var result = new List<int>();

        var generation = new int[n];
        for (int i = 0; i < n; i++) {
            if (table[i].Count() == 1) {
                queue.Enqueue(i);
                generation[i] = 1;
            }
            else {
                generation[i] = -1;
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            result.Add(cur);

            foreach (var neighbour in table[cur]) {
                table[neighbour].Remove(cur);
                if (table[neighbour].Count() == 1) {
                    generation[neighbour] = generation[cur] + 1;
                    queue.Enqueue(neighbour);
                }
            }
        }

        var maxGen = generation[result.LastOrDefault()];
        var superResult = new List<int>();
        for (int i =0; i < n; i++)  {
            if (generation[i] == maxGen) {
                superResult.Add(i);
            }
        }

        return superResult;
    }
}