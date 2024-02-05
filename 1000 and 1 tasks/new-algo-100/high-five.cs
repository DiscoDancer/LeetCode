public class Solution {
    public int[][] HighFive(int[][] items) {
        var table = new Dictionary<int, PriorityQueue<int, int>>();

        foreach (var item in items) {
            var studentId = item[0];
            var studentScore = item[1];

            if (!table.ContainsKey(studentId)) {
                table[studentId] = new ();
            }

            table[studentId].Enqueue(studentScore, studentScore);
            if (table[studentId].Count > 5) {
                table[studentId].Dequeue();
            }
        }

        var ids = table.Keys.OrderBy(x => x).ToArray();
        var result = new int[ids.Length][];

        for (int i = 0; i < ids.Length; i++) {
            var id = ids[i];
            var sum = 0;
            var count = 0;

            while (table[id].Count > 0) {
                sum += table[id].Dequeue();
                count++;
            }

            result[i] = new int[] {id,sum/count};
        }

        return result;
    }
}