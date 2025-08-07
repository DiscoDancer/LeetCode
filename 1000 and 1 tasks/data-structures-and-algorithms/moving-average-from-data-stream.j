import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;
import java.util.LinkedList;

class MovingAverage {

    private final Deque<Integer> buffer;
    private double sum = 0;
    private final int size;

    public MovingAverage(int size) {
        this.buffer = new ArrayDeque<>(size);
        this.size = size;
    }

    public double next(int val) {
        var firstToRemove = buffer.size() == this.size ? buffer.removeFirst() : 0;
        buffer.addLast(val);

        sum -= firstToRemove;
        sum += val;

        return sum / buffer.size();
    }
}
