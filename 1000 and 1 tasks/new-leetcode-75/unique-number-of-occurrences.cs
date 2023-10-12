public class Solution {
    // словарь или хуйня
    public bool UniqueOccurrences(int[] arr) {
        var positiveTable = new int [1001];
        var negativeTable = new int [1001];

        foreach (var n in arr) {
            if (n >= 0) {
                positiveTable[n]++;
            }
            else {
                negativeTable[-n]++;
            }
        }

        var occurances = new int [1001];
        for (int i = 0; i < 1001; i++) {
            occurances[positiveTable[i]]++;
            occurances[negativeTable[i]]++;
        }

        for (int i = 1; i < 1001; i++) {
            if (occurances[i] > 1) {
                return false;
            }
        }

        return true;
    }
}