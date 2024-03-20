/**
 * // This is the ArrayReader's API interface.
 * // You should not implement it, or speculate about its implementation
 * class ArrayReader {
 *   public:
 *     // Compares 4 different elements in the array
 *     // return 4 if the values of the 4 elements are the same (0 or 1).
 *     // return 2 if three elements have a value equal to 0 and one element has value equal to 1 or vice versa.
 *     // return 0 : if two element have a value equal to 0 and two elements have a value equal to 1.
 *     public int Query(int a, int b, int c, int d) {}
 *
 *     // Returns the length of the array
 *     public int Length() {}
 * };
 */

class Solution {
    public int GuessMajority(ArrayReader reader)
    {
        var groups = new List<int>[4];
        var groupsEncoded = new Dictionary<int, char>[4];
        for (int i = 0; i < 4; i++)
        {
            groups[i] = new List<int>();
            groupsEncoded[i] = new();
        }
        
        for (int i = 0; i < reader.Length(); i++) {
            for (int j = 0; j < 4; j++)
            {
                if (i % 4 == j) groups[j].Add(i);
            }
        }

        for (int groupIndex = 0; groupIndex < 4; groupIndex++)
        {
            var group = groups[groupIndex];
            var cmpCount = group.Count - 1;
            groupsEncoded[groupIndex][group[0]] = 'A';

            var prevChar = 'A';

            for (int cmpIndex = 0; cmpIndex < cmpCount; cmpIndex++)
            {
                // todo можно оптимизировать храня предыдущий или proxy паттерном
                var first = reader.Query(group[cmpIndex], group[cmpIndex] + 1, group[cmpIndex] + 2, group[cmpIndex] + 3);
                var second = reader.Query(group[cmpIndex] + 1, group[cmpIndex] + 2, group[cmpIndex] + 3, group[cmpIndex] + 4);

                var target = group[cmpIndex + 1];
                var targetChar = first == second ? prevChar : (prevChar == 'A' ? 'B' : 'A');
                groupsEncoded[groupIndex][target] = targetChar;
                prevChar = targetChar;
            }
        }
        
        // cmp group 0 and group 1

        var combinedGroup = groups[0];
        var combinedEncoded = groupsEncoded[0];

        var restGroups = new[] { groups[1], groups[2], groups[3] };
        var restEncoded = new[] { groupsEncoded[1], groupsEncoded[2], groupsEncoded[3] };
        var comparisons = new[]
        {
            reader.Query(0, 2, 3, 4) == reader.Query(1, 2, 3, 4),
            reader.Query(0, 1, 3, 4) == reader.Query(1, 2, 3, 4),
            reader.Query(0, 1, 2, 4) == reader.Query(1, 2, 3, 4),
        };

        for (int i = 0; i < 3; i++)
        {
            var aMeans = comparisons[i] ? 'A' : 'B';
            var bMeans = comparisons[i] ? 'B' : 'A';
            foreach (var x in restGroups[i])
            {
                combinedGroup.Add(x);
                combinedEncoded[x] = restEncoded[i][x] == 'A' ? aMeans : bMeans;
            }
        }
        
        // todo optimize
        var aCount = combinedEncoded.Values.Count(x => x == 'A');
        var bCount = combinedEncoded.Values.Count(x => x == 'B');

        if (aCount > bCount)
        {
            foreach (var (k,v) in combinedEncoded)
            {
                if (v == 'A') return k;
            }
        }
        else if (bCount > aCount)
        {
            foreach (var (k,v) in combinedEncoded)
            {
                if (v == 'B') return k;
            }
        }
        
        return -1;
    }
}