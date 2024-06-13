public class Solution {
    private int[] _gas;
    private int[] _cost;

    // ее нужно свести к F(start, end): bool и меморизировать
    private int Check(int startIndex) {
        var n = _gas.Length;
        var balance = 0;
        for (int i = 0; i < n; i++) {
            var trueIndex = (startIndex + i) % n;
            balance -= _cost[trueIndex];
            balance += _gas[trueIndex];

            if (balance < 0) {
                return trueIndex;
            }
        }

        return startIndex;
    }

    public int CanCompleteCircuit(int[] gas, int[] cost) {
        _gas = gas;
        _cost = cost;

        for (int startIndex = 0; startIndex < gas.Length; startIndex++) {
            if (gas[startIndex] >= cost[startIndex] && Check(startIndex) == startIndex) {
                return startIndex;
            }
        }

        return -1;
    }
}