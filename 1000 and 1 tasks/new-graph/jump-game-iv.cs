public class Solution {
    // TL
    public int MinJumps(int[] arr) {
        var indexToMinJumps = new int[arr.Length];

        var valToListOfIndexes = new Dictionary<int, List<int>>();

        for (int i = 0; i < arr.Length; i++) {
            if (!valToListOfIndexes.ContainsKey(arr[i])) {
                valToListOfIndexes[arr[i]] = new ();
            }
            valToListOfIndexes[arr[i]].Add(i);
            indexToMinJumps[i] = int.MaxValue;
        }

        var queue = new Queue<(int index, int jumpsToReach)>();
        queue.Enqueue((0, 0));
        indexToMinJumps[0] = 0;

        while (queue.Any()) {
            var (index, jumpsToReach) = queue.Dequeue();

            // go back
            if (index > 0 && indexToMinJumps[index - 1] > jumpsToReach + 1) {
                indexToMinJumps[index - 1] = jumpsToReach + 1;
                queue.Enqueue((index - 1, jumpsToReach + 1));
            }

            // go forward
            if (index < arr.Length - 1 && indexToMinJumps[index + 1] > jumpsToReach + 1) {
                indexToMinJumps[index + 1] = jumpsToReach + 1;
                queue.Enqueue((index + 1, jumpsToReach + 1));
            }

            // go same value
            foreach (var sameValueIndex in valToListOfIndexes[arr[index]]) {
                if (indexToMinJumps[sameValueIndex] > jumpsToReach + 1) {
                    indexToMinJumps[sameValueIndex] = jumpsToReach + 1;
                    queue.Enqueue((sameValueIndex, jumpsToReach + 1));
                }
            }
        }

        return indexToMinJumps[arr.Length - 1];
    }
}