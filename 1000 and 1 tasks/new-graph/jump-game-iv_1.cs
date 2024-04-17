// TL
public class Solution {
    public int MinJumps(int[] arr) {
        var valToListOfIndexes = new Dictionary<int, List<int>>();

        for (int i = 0; i < arr.Length; i++) {
            if (!valToListOfIndexes.ContainsKey(arr[i])) {
                valToListOfIndexes[arr[i]] = new ();
            }
            valToListOfIndexes[arr[i]].Add(i);
        }

        var queue = new Queue<int>();
        queue.Enqueue(0);
        var visited = new bool[arr.Length];
        visited[0] = true;

        var jumpCount = 0;

        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var index = queue.Dequeue();

                if (index == arr.Length - 1) {
                    return jumpCount;
                }

                // go back
                if (index > 0 && !visited[index - 1]) {
                    visited[index - 1] = true;
                    queue.Enqueue(index - 1);
                }

                // go forward
                if (index < arr.Length - 1 &&  !visited[index + 1]) {
                    visited[index + 1] = true;
                    queue.Enqueue(index + 1);
                }

                // go same value
                foreach (var sameValueIndex in valToListOfIndexes[arr[index]]) {
                    if (!visited[sameValueIndex]) {
                        visited[sameValueIndex] = true;
                        queue.Enqueue(sameValueIndex);
                    }
                }
            }
            jumpCount++;
        }

        return -1;
    }
}