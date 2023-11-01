public class Solution {
    // editorial
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        var n = nums2.Length;
        var pairs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            pairs[i] = new[] { nums1[i], nums2[i] };
        }
        Array.Sort(pairs, (x,y) => y[1]-x[1]);
        
        var topKHeap = new PriorityQueue<int, int>(k);
        long topKSum = 0;
        for (int i = 0; i < k; ++i) {
            topKSum += pairs[i][0];
            topKHeap.Enqueue(pairs[i][0], pairs[i][0]);
        }
        
        // The score of the first k pairs.
        long answer = topKSum * pairs[k - 1][1];
        
        // Iterate over every nums2[i] as minimum from nums2.
        for (int i = k; i < n; ++i) {
            // Remove the smallest integer from the previous top k elements
            // then add nums1[i] to the top k elements.
            topKSum += pairs[i][0] - topKHeap.Dequeue();
            topKHeap.Enqueue(pairs[i][0], pairs[i][0]);
            
            // Update answer as the maximum score.
            answer = Math.Max(answer, topKSum * pairs[i][1]);
        }
        
        return answer;
    }
}