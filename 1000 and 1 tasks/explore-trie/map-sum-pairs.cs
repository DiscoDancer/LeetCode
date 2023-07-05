public class MapSum {

    public class Node {
        public int sum {get; set;} = 0;
        public Node[] children = new Node[26];
    }

    // write numbers to nodes
    // ok to write 0 by default

    private Node _root = new ();

    public MapSum() {
        
    }
    
    // важно свойсто перезаписи
    // можно было бы сразу писать в родителя все суммы, но тогда не получится перезаписать
    // то есть не пройдет (apple,2) и потом (apple,4)
    public void Insert(string key, int val) {
        var cur = _root;
        foreach (var c in key) {
            if (cur.children[c-'a'] == null) {
                cur.children[c-'a'] = new Node();
            }
            cur = cur.children[c-'a'];
        }
        cur.sum = val;
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

        var queue = new Queue<Node>();
        queue.Enqueue(cur);

        while (queue.Any()) {
            cur = queue.Dequeue();
            result += cur.sum;

            for (int i = 0; i < 26; i++) {
                if (cur.children[i] != null) {
                    queue.Enqueue(cur.children[i]);
                }
            }
        }

        return result;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */