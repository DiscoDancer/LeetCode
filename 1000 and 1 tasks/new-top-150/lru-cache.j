import java.util.HashMap;
import java.util.List;

// TL

class LRUCache {

    // список ключей по полярности
    // список ключей как история использования
    // я могу просто массив ебануть

    private class Row {
        int timestamp;
        int value;
        Row(int value, int timestamp) {
            this.value = value;
            this.timestamp = timestamp;
        }
    }

    private HashMap<Integer, Row> cache;
    private int capacity;
    private int timeNow;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.cache = new HashMap<>(capacity);
        this.timeNow = 0;
    }

    public int get(int key) {
        timeNow++;
        if (cache.containsKey(key)) {
            var row = cache.get(key);
            row.timestamp = timeNow;
            return row.value;
        }
        return -1;
    }

    public void put(int key, int value) {
        timeNow++;
        if (cache.containsKey(key) ) {
            var row = cache.get(key);
            row.value = value;
            row.timestamp = timeNow;
        }
        else if (cache.size() < capacity) {
            cache.put(key, new Row(value, timeNow));
        } else {
            var maxTimestamp = Integer.MAX_VALUE;
            var maxKey = -1;
            for (var entry : cache.entrySet()) {
                if (entry.getValue().timestamp < maxTimestamp) {
                    maxTimestamp = entry.getValue().timestamp;
                    maxKey = entry.getKey();
                }
            }
            cache.remove(maxKey);
            cache.put(key, new Row(value, timeNow));
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */