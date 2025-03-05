import java.util.PriorityQueue;

class MedianFinder {
    private int count = 0;

    private PriorityQueue<Integer> maxHeapFirstHalf = new PriorityQueue<>((a,b) -> b - a);
    private PriorityQueue<Integer> minHeapSecondHalf = new PriorityQueue<>((a,b) -> a - b);

    public MedianFinder() {
    }

    public void addNum(int num) {
        count++;

        if (count % 2 == 1) {
            // add to the first half

            // кто-то из куч может быть пустой
            // число может не подойти в кучу

            if (maxHeapFirstHalf.size() == 0 && minHeapSecondHalf.size() == 0) {
                maxHeapFirstHalf.add(num);
            }
            else if (minHeapSecondHalf.peek() >= num) {
                maxHeapFirstHalf.add(num);
            }
            else {
                var curMin = minHeapSecondHalf.poll();
                maxHeapFirstHalf.add(curMin);
                minHeapSecondHalf.add(num);
            }
        }
        else {
            // add to the second half

            // first half is always not empty
            if (maxHeapFirstHalf.size() == 0) {
                throw new RuntimeException("Not possible case");
            }
            // если первая половина меньше, то все ок, спокойно добавляем
            // не важно сколько там элементов
            else if (maxHeapFirstHalf.peek() <= num) {
                minHeapSecondHalf.add(num);
            }
            // иначе перекидываем
            else {
                var curMax = maxHeapFirstHalf.poll();
                maxHeapFirstHalf.add(num);
                minHeapSecondHalf.add(curMax);
            }
        }
    }

    public double findMedian() {
        if (count % 2 == 0) {
            var sum = maxHeapFirstHalf.peek() + minHeapSecondHalf.peek();
            return sum / 2.0;
        }
        // list.size() % 2 == 1
        return maxHeapFirstHalf.peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */