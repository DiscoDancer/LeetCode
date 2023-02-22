public class SeatManager {
    // seats numbered from 1 to n

    private PriorityQueue<int, int> _reservedQueue = new ();

    public SeatManager(int n) {
        for (int i = 1; i <= n; i++) {
            _reservedQueue.Enqueue(i, i);
        }
    }
    
    // Fetches the smallest-numbered unreserved seat, reserves it, and returns its number.
    public int Reserve() {
        _reservedQueue.TryDequeue(out var k, out var v);
        return k;
    }
    
    public void Unreserve(int seatNumber) {
        _reservedQueue.Enqueue(seatNumber, seatNumber);
    }
}

/**
 * Your SeatManager object will be instantiated and called as such:
 * SeatManager obj = new SeatManager(n);
 * int param_1 = obj.Reserve();
 * obj.Unreserve(seatNumber);
 */