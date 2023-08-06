public class Solution {
    // был какой min за o(1) задача
    // с 2х сторон сделать
    // тогда k*k можно убрать

    // Теперь O(n*k*3) = O(n*k)
    public int MinCostII(int[][] costs) {
        var n = costs.Length;
        var k = costs[0].Length;

        var oldRow = new int[k];
        for (var index = n-1; index >= 0; index--) {
            var newRow = new int[k];

            var minL = new int[k];
            minL[0] = oldRow[0] + costs[index][0];
            for (int i = 1; i < k; i++) {
                minL[i] = Math.Min(minL[i-1], oldRow[i] + costs[index][i]);
            }

            var minR = new int[k];
            minR[k-1] = oldRow[k-1] + costs[index][k-1];
            for (int i = k-2; i >=0; i--) {
                minR[i] = Math.Min(minR[i+1], oldRow[i] + costs[index][i]);
            }
            
            for (var color = 0; color < k; color++ ) {
                var leftMin = color == 0 ? int.MaxValue : minL[color-1];
                var rightMin = color == k-1? int.MaxValue : minR[color+1];
                newRow[color] = Math.Min(leftMin, rightMin);
            }
            oldRow = newRow;
        }

        return oldRow.Min();
    }
}