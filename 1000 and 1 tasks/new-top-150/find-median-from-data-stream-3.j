import java.util.PriorityQueue;

class MedianFinder {
    private int count = 0;

    private PriorityQueue<Integer> maxHeapFirstHalf = new PriorityQueue<>((a,b) -> b - a);
    private PriorityQueue<Integer> minHeapSecondHalf = new PriorityQueue<>((a,b) -> a - b);

    public MedianFinder() {
    }

    public void addNum(int num) {
        count++;

        // мы гарантируем сами себе, что добавляем в кучи по очереди всегда.
        if (count % 2 == 1) {
            // вторая куча будет пустой здесь только, когда обе пустые
            // дальше она никогда не будет пустой
            if (maxHeapFirstHalf.size() == 0 && minHeapSecondHalf.size() == 0) {
                maxHeapFirstHalf.add(num);
            }
            // в текущей куче может лежать все что угодно
            // важно только, чтобы оно не противоречило второй куче
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
            // все абсолютно симметрично, только пустого случай не может быть
            if (maxHeapFirstHalf.peek() <= num) {
                minHeapSecondHalf.add(num);
            }
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
        return maxHeapFirstHalf.peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */