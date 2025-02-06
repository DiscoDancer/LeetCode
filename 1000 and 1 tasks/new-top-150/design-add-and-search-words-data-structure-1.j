import java.util.HashMap;
import java.util.Queue;

class WordDictionary {

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

    public WordDictionary() {
        root = new Node(' ', new HashMap<>(), false);
    }

    public void addWord(String word) {
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
        Queue<Node> queue = new java.util.LinkedList<>();
        queue.add(root);
        for (var wi = 0; wi < word.length(); wi++) {
            var c = word.charAt(wi);
            var size = queue.size();
            var anyWord = false;
            for (var i = 0; i < size; i++) {
                var cur = queue.poll();
                if (c == '.') {
                    for (var next : cur.children.values()) {
                        queue.add(next);
                        anyWord |= next.isWord;
                    }
                    ;
                } else {
                    var next = cur.children.getOrDefault(c, null);
                    if (next != null) {
                        queue.add(next);
                        anyWord |= next.isWord;
                    }
                }
            }
            if (queue.isEmpty()) {
                return false;
            }
            if (wi == word.length() - 1) {
                return anyWord;
            }
        }

        throw new RuntimeException("Unreachable code");
    }
}