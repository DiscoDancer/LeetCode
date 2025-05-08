import java.util.ArrayList;

// смотри time-based-key-value-store

class SnapshotArray {
    record Entry(int value, int snap) {}

    ArrayList<Entry>[] arrayOfLists;
    private int currentSnap = 0;

    public SnapshotArray(int length) {
        arrayOfLists = new ArrayList[length];
        for (int i = 0; i < length; i++) {
            arrayOfLists[i] = new ArrayList<>();
            arrayOfLists[i].add(new Entry(0, 0));
        }
    }

    public void set(int index, int val) {
        var x = arrayOfLists[index];
        if (x.get(x.size() - 1).snap == currentSnap) {
            x.set(x.size() - 1, new Entry(val, currentSnap));
        }
        else {
            x.add(new Entry(val, currentSnap));
        }
    }

    public int snap() {
        this.currentSnap++;
        return this.currentSnap - 1;
    }

    public int get(int index, int snap_id) {
        var list = arrayOfLists[index];

        var l = 0;
        var r = list.size() - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            // не может быть несколько одинаковых timestamp
            // если попали, точнее быть не может
            if (list.get(m).snap == snap_id) {
                return list.get(m).value;
            }
            // если больше, то точно не подойдет
            else if (list.get(m).snap > snap_id) {
                r = m - 1;
            }
            else if (list.get(m).snap < snap_id) {
                // если это последний самый маленький, то пойдет
                if (m == list.size() - 1 || list.get(m + 1).snap > snap_id) {
                    return list.get(m).value;
                }
                l = m + 1;
            }
        }

        return 42;
    }
}