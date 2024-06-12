public class Solution {
    // на вид просто DP

    private int[] _gas;
    private int[] _cost;

    private bool F(int startIndex, int curIndex, int balance) {
        var n = _gas.Length;

        if (curIndex == n) {
            return true;
        }

        var i = (startIndex + curIndex) % n;
        balance += _gas[i];
        if (balance >= _cost[i]) {
             return F(startIndex, curIndex+1, balance - _cost[i]);
        }

        return false;
    }

    public int CanCompleteCircuit(int[] gas, int[] cost) {
        _gas = gas;
        _cost = cost;

        var n = gas.Length;

        for (int startIndex = 0; startIndex < n; startIndex++) {
            if (F(startIndex, 0, 0)) {
                return startIndex;
            }
        }

        return -1;
    }
}