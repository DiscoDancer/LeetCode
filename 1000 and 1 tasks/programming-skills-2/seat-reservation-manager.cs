// naive -> TL
public class SeatManager {
    // seats numbered from 1 to n

    private bool[] _reservedTable;

    public SeatManager(int n) {
        _reservedTable = new bool[n];
    }
    
    // Fetches the smallest-numbered unreserved seat, reserves it, and returns its number.
    public int Reserve() {
        for (int i = 0; i < _reservedTable.Length; i++) {
            if (!_reservedTable[i]) {
                _reservedTable[i] = true;
                return i + 1;
            }
        }

        return -1;
    }
    
    public void Unreserve(int seatNumber) {
        _reservedTable[seatNumber - 1] = false;
    }
}

/**
 * Your SeatManager object will be instantiated and called as such:
 * SeatManager obj = new SeatManager(n);
 * int param_1 = obj.Reserve();
 * obj.Unreserve(seatNumber);
 */