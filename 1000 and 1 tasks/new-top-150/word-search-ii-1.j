import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;

class Solution {

    public class Trie {

        public class Node {
            public final char c;
            public final HashMap<Character, Node> children;
            public String wordOrDefault;

            Node(char c, HashMap<Character, Node> children) {
                this.c = c;
                this.children = children;
                this.wordOrDefault = null;
            }
        }

        public final Node root;

        public Trie() {
            root = new Node(' ', new HashMap<>());
        }

        public void insert(String word) {
            var cur = root;
            for (var c : word.toCharArray()) {
                var next = cur.children.getOrDefault(c, null);
                if (next != null) {
                    cur = next;
                } else {
                    var newNode = new Node(c, new HashMap<>());
                    cur.children.put(c, newNode);
                    cur = newNode;
                }
            }
            cur.wordOrDefault = word;
        }

        public boolean search(String word) {
            var cur = root;
            for (var c : word.toCharArray()) {
                cur = cur.children.getOrDefault(c, null);
                if (cur == null) {
                    return false;
                }
            }
            return cur.wordOrDefault == word;
        }
    }

    private final Trie _trie = new Trie();
    private char[][] _board;
    private HashSet<String> _result = new HashSet<>();

    public enum Direction {
        START, UP, DOWN, LEFT, RIGHT
    }

    private void F(int x, int y, Trie.Node node, boolean[][] visited, Direction direction) {
        if (node.wordOrDefault != null) {
            _result.add(node.wordOrDefault);
        }

        var X = _board.length;
        var Y = _board[0].length;
        if (x < X - 1 && !visited[x+1][y] && direction != Direction.UP) {
            var matchOrDefault = node.children.getOrDefault(_board[x+1][y], null);
            if (matchOrDefault != null) {
                visited[x+1][y] = true;
                F(x+1, y, matchOrDefault, visited, Direction.DOWN);
                visited[x+1][y] = false;
            }
        }
        if (x > 0 && !visited[x-1][y] && direction != Direction.DOWN) {
            var matchOrDefault = node.children.getOrDefault(_board[x-1][y], null);
            if (matchOrDefault != null) {
                visited[x-1][y] = true;
                F(x-1, y, matchOrDefault, visited, Direction.UP);
                visited[x-1][y] = false;
            }
        }
        if (y < Y - 1 && !visited[x][y+1] && direction != Direction.LEFT) {
            var matchOrDefault = node.children.getOrDefault(_board[x][y+1], null);
            if (matchOrDefault != null) {
                visited[x][y+1] = true;
                F(x, y+1, matchOrDefault, visited, Direction.RIGHT);
                visited[x][y+1] = false;
            }
        }
        if (y > 0 && !visited[x][y-1] && direction != Direction.RIGHT) {
            var matchOrDefault = node.children.getOrDefault(_board[x][y-1], null);
            if (matchOrDefault != null) {
                visited[x][y-1] = true;
                F(x, y-1, matchOrDefault, visited, Direction.LEFT);
                visited[x][y-1] = false;
            }
        }
    }

    public List<String> findWords(char[][] board, String[] words) {
        for (var word : words) {
            _trie.insert(word);
        }

        _board = board;

        var X = board.length;
        var Y = board[0].length;

        var visited = new boolean[board.length][board[0].length];

        for (var x = 0; x < X; x++) {
            for (var y = 0; y < Y; y++) {
                var matchOrDefault = _trie.root.children.getOrDefault(board[x][y], null);
                if (matchOrDefault != null) {
                    visited[x][y] = true;
                    F(x, y, matchOrDefault, visited, Direction.START);
                    visited[x][y] = false;
                }
            }
        }

        return _result.stream().toList();
    }
}