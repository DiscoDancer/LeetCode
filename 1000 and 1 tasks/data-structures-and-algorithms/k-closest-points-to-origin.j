import java.util.*;

class Solution {

    private static int[][] _points;
    private static int _k;

    private class Entry {
        public int[] xy;
        public double d;

        public Entry(int[] inputXY) {
            this.xy = inputXY;
            this.d = Math.sqrt(inputXY[0]*inputXY[0] + inputXY[1]*inputXY[1]);
        }
    }

    public int[][] kClosest(int[][] points, int k) {
        _points = points;
        _k = k;

        PriorityQueue<Entry> maxHeap = new PriorityQueue<>((a, b) -> Double.compare(b.d, a.d));

        for (var xy: points) {
            var e = new Entry(xy);
            if (maxHeap.size() < k) {
                maxHeap.add(e);
            }
            else {
                if (maxHeap.peek().d <= e.d) {
                    // ignore
                }
                else {
                    maxHeap.poll();
                    maxHeap.add(e);
                }
            }
        }

        int[][] result = new int[k][2];
        var nextI = 0;
        while (maxHeap.size() > 0) {
            result[nextI++] = maxHeap.poll().xy;
        }

        return result;
    }
}