// тут нужно рисовать 3 точки,
// получить 9 случаев и думать в каком случае что

public class Solution {
    private int _max = -1;
    private int _maxIndex = -1;
    
    private void UpdateMax(int x, int i) {
        if (x > _max) {
            _max = x;
            _maxIndex = i;
        }
    }
    
    public int PeakIndexInMountainArray(int[] arr) {
        int a0 = 0;
        int b0 = arr.Length - 1;

        var queue = new Queue<(int, int)>();
        
        queue.Enqueue((a0, b0));
        
        while (queue.Any()) {
            var curr = queue.Dequeue();
            var a = curr.Item1;
            var b = curr.Item2;
            
            if (a > b) {
                continue;
            }
            
            var m = a + (b-a)/2;
            
            
            UpdateMax(arr[a], a);
            UpdateMax(arr[b], b);
            UpdateMax(arr[m], m);
                                    
            if (arr[a] == arr[m] && arr[m] == arr[b]) {
                queue.Enqueue((a + 1, m - 1)); // am
                queue.Enqueue((m+1, b-1)); // mb
            }
            if (arr[a] == arr[m] && arr[m] < arr[b]) {
                queue.Enqueue((m+1, b-1));
            }
            if (arr[a] == arr[m] && arr[m] > arr[b]) {
                queue.Enqueue((a + 1, m - 1));
            }
            
            
            if (arr[a] < arr[m] && arr[m] == arr[b]) {
                queue.Enqueue((m+1, b-1));
            }
            if (arr[a] < arr[m] && arr[m] < arr[b]) {
                queue.Enqueue((m+1, b-1));
            }
            if (arr[a] < arr[m] && arr[m] > arr[b]) {
                queue.Enqueue((a + 1, m - 1));
                queue.Enqueue((m+1, b-1));
            }
            
            if (arr[a] > arr[m] && arr[m] == arr[b]) {
                queue.Enqueue((a + 1, m - 1));
            }
            if (arr[a] > arr[m] && arr[m] < arr[b]) {
                // do nothing
            }
            if (arr[a] > arr[m] && arr[m] > arr[b]) {
                queue.Enqueue((a + 1, m - 1));
            }
        }
        
        return _maxIndex;
    }
}