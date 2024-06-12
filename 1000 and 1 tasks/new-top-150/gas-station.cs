
// TL
public class Solution {
    // на вид просто DP

    private bool _result = false;
    private int[] _gas;
    private int[] _cost;

    private void F(int startIndex, int curIndex, int balance) {
        var n = _gas.Length;

        if (curIndex == n) {
            _result = true;
            return;
        }

        var i = (startIndex + curIndex) % n;
        balance += _gas[i];
        if (balance >= _cost[i]) {
             F(startIndex, curIndex+1, balance - _cost[i]);
        }
    }

    public int CanCompleteCircuit(int[] gas, int[] cost) {
        _gas = gas;
        _cost = cost;

        var n = gas.Length;

        for (int startIndex = 0; startIndex < n; startIndex++) {
            F(startIndex, 0, 0);
            if (_result) {
                return startIndex;
            }
        }

        return -1;
    }
}