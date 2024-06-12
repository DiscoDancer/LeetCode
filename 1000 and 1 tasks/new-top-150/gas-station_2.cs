public class Solution {
    private int[] _gas;
    private int[] _cost;

    private bool Check(int startIndex) {
        var n = _gas.Length;
        var balance = 0;
        for (int i = 0; i < n; i++) {
            var trueI = (startIndex + i) % n;
            balance -= _cost[trueI];
            balance += _gas[trueI];

            if (balance < 0) {
                return false;
            }
        }

        return true;
    }

    public int CanCompleteCircuit(int[] gas, int[] cost) {
        _gas = gas;
        _cost = cost;

        for (int startIndex = 0; startIndex < gas.Length; startIndex++) {
            if (Check(startIndex)) {
                return startIndex;
            }
        }

        return -1;
    }
}