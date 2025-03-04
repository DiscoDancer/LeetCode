import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// TL

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

        if (list.size() % 2 == 0) {
            return ((double) (list.get(list.size() / 2) + list.get(list.size() / 2 - 1))) / 2.0;
        }
        return list.get(list.size() / 2);
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */