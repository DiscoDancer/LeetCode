// editorial

public class MapSum {
    public class Node {
        public int sum {get; set;} = 0;
        public Node[] children = new Node[26];
    }

    private Node _root = new ();

    private Dictionary<string, int> _allPairs = new ();

    public MapSum() {
        
    }

    public void Insert(string key, int val) {
        var delta = val - (_allPairs.ContainsKey(key) ? _allPairs[key] : 0);
        _allPairs[key] = val;

        var cur = _root;
        foreach (var c in key) {
            if (cur.children[c-'a'] == null) {
                cur.children[c-'a'] = new Node();
            }
            cur = cur.children[c-'a'];
            cur.sum += delta;
        }
    }
    
    public int Sum(string prefix) {
        var result = 0;

        var cur = _root;
        foreach (var c in prefix) {
            if (cur.children[c-'a'] != null) {
                cur = cur.children[c-'a'];
            }
            else {
                return 0;
            }
        }

        return cur.sum;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */