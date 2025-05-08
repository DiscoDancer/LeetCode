import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

class TimeMap {

    record Entry(String value, int timestamp) {}
    private final Map<String, ArrayList<Entry>> map = new HashMap<>();

    public TimeMap() {

    }

    // always strictly increasing
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

        var arr = map.get(key);
        var l = 0;
        var r = arr.size() - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            // не может быть несколько одинаковых timestamp
            // если попали, точнее быть не может
            if (arr.get(m).timestamp == timestamp) {
                return arr.get(m).value;
            }
            // если больше, то точно не подойдет
            else if (arr.get(m).timestamp > timestamp) {
                r = m - 1;
            }
            else if (arr.get(m).timestamp < timestamp) {
                // если это последний самый маленький, то пойдет
                if (m == arr.size() - 1 || arr.get(m + 1).timestamp > timestamp) {
                    return arr.get(m).value;
                }
                l = m + 1;
            }
        }

        return "";
    }
}
