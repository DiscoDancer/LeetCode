import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

class TimeMap {

    record Entry(String value, int timestamp) {}
    private final Map<String, ArrayList<Entry>> map = new HashMap<>();

    public TimeMap() {

    }

    public void set(String key, String value, int timestamp) {
        if (!map.containsKey(key)) {
            map.put(key, new ArrayList<>());
        }
        map.get(key).add(new Entry(value, timestamp));
    }

    public String get(String key, int timestamp) {
        if (!map.containsKey(key)) {
            return "";
        }

        for (int i = map.get(key).size() - 1; i >= 0; i--) {
            Entry entry = map.get(key).get(i);
            if (entry.timestamp <= timestamp) {
                return entry.value;
            }
        }

        return "";
    }
}
