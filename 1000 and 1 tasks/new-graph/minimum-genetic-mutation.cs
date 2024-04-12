public class Solution {
    public int MinMutation(string startGene, string endGene, string[] bank) {
        if (startGene == endGene) {
            return 0;
        }

        var queue = new Queue<string>();
        queue.Enqueue(startGene);

        var copyBank = bank.ToList();

        var generation = 0;
        while (queue.Any()) {
            var size = queue.Count();

            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur == endGene) {
                    return generation;
                }

                var optionsToDelete = new List<string>();

                foreach (var option in copyBank) {
                    var diffCount = 0;
                    for (int j = 0; j < option.Length; j++) {
                        if (option[j] != cur[j]) {
                            diffCount++;
                        }
                    }
                    if (diffCount == 1) {
                        queue.Enqueue(option);
                        optionsToDelete.Add(option);
                    }
                }

                foreach (var x in optionsToDelete) {
                    copyBank.Remove(x);
                }
            }
            generation++;
        }

        return -1;
    }
}