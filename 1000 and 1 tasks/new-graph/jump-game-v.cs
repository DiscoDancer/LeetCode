public class Solution {
    // TL
    public int MaxJumps(int[] arr, int d) {
        var max = 0;

        for (var startIndex = 0; startIndex < arr.Length; startIndex++) {
            // предполагаю, что я не могу зациклиться
            // потому что можно идти только из большего в меньшее

            var queue = new Queue<(int index, int jumpCount)>();
            queue.Enqueue((startIndex, 1));

            while (queue.Any())
            {
                var (curIndex, jumpCount) = queue.Dequeue();
                max = Math.Max(max, jumpCount);
                
                // go forward
                for (var i = 1; i <= d && curIndex + i < arr.Length; i++)
                {
                    if (arr[curIndex + i] >= arr[curIndex]) {
                        break;
                    }
                    queue.Enqueue((curIndex + i, jumpCount + 1));
                }
                
                // go backward
                for (var i = 1; i <= d && curIndex - i >= 0; i++)
                {
                    if (arr[curIndex - i] >= arr[curIndex]) {
                        break;
                    }
                    queue.Enqueue((curIndex - i, jumpCount + 1));
                }
            }
        }

        return max;
    }
}