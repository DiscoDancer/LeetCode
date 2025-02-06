import java.util.HashMap;

class Trie {

    private class Node {
        private final char c;
        private final HashMap<Character, Node> children;
        private boolean isWord;

        Node(char c, HashMap<Character, Node> children, boolean isWord) {
            this.c = c;
            this.children = children;
            this.isWord = isWord;
        }
    }

    private final Node root;

    public Trie() {
        root = new Node(' ', new HashMap<>(), false);
    }

    public void insert(String word) {
        var cur = root;
        for (var c : word.toCharArray()) {
            var next = cur.children.getOrDefault(c, null);
            if (next != null) {
                cur = next;
            } else {
                var newNode = new Node(c, new HashMap<>(), false);
                cur.children.put(c, newNode);
                cur = newNode;
            }
        }
        cur.isWord = true;
    }

    public boolean search(String word) {
        var cur = root;
        for (var c : word.toCharArray()) {
            cur = cur.children.getOrDefault(c, null);
            if (cur == null) {
                return false;
            }
        }
        return cur.isWord;
    }

    public boolean startsWith(String prefix) {
        var cur = root;
        for (var c : prefix.toCharArray()) {
            cur = cur.children.getOrDefault(c, null);
            if (cur == null) {
                return false;
            }
        }
        return true;
    }
}