import java.util.ArrayList;

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

        for (var i = list.size() - 1; i >= 0; i--) {
            var entry = list.get(i);
            if (entry.snap <= snap_id) {
                return entry.value;
            }
        }

        return 42;
    }
}