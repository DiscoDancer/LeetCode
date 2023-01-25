public class Solution {
    // possible letters A,C,G,T
    // startGene -> endGene
    // example mutation: "AACCGGTT" --> "AACCGGTA"
    // A gene must be in bank to make it a valid gene string.

    // return the minimum number of mutations needed to mutate from startGene to endGene

    // 4^8 = 65536 (не такое большое число)
    // как альтернатива HT
    // или еще проще 0000_0000
    // bank маленький проще перебирать его, иначе 4*8
    // из bank можно удалять, если visited
    public int MinMutation(string startGene, string endGene, string[] bank) {
        var visited = new HashSet<string>();
        visited.Add(startGene);

        var queue = new Queue<(string g, int steps)>();
        queue.Enqueue((startGene, 0));

        while (queue.Any()) {
            var (g, steps) = queue.Dequeue();
            if (g == endGene) {
                return steps;
            }

            foreach (var b in bank) {
                if (visited.Contains(b)) {
                    continue;
                }
                var count = 0;
                for (int i = 0; i < 8 && count <= 1; i++) {
                    if (g[i] != b[i]) {
                        count++;
                    }
                }
                if (count == 1) {
                    visited.Add(b);
                    queue.Enqueue((b, steps + 1));
                }
            }
        }

        return -1;
    }
}