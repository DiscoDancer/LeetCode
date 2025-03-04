import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.PriorityQueue;

// это промежуточный вариант, который предполагает 2 кучи

class MedianFinder {

    private List<Integer> list;

    public MedianFinder() {
        list = new ArrayList<Integer>();
    }

    public void addNum(int num) {
        list.add(num);
    }

    public double findMedian() {

        Collections.sort(list);

        // first half
        var maxHeap = new PriorityQueue<Integer>((a,b) -> b - a);
        // second half
        var minHeap = new PriorityQueue<Integer>((a,b) -> a - b);

        var i = 0;
        var n = list.size();

        while (i < (n % 2 == 0 ? n / 2 : n / 2 + 1)) {
            maxHeap.add(list.get(i));
            i++;
        }
        while (i < n) {
            minHeap.add(list.get(i));
            i++;
        }

        if (list.size() % 2 == 0) {
            var sum = maxHeap.poll() + minHeap.poll();
            return sum / 2.0;
        }
        // list.size() % 2 == 1
        return maxHeap.poll();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */