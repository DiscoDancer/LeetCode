import java.util.Arrays;
import java.util.HashMap;

public class Main {

    public Node copyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        var table = new HashMap<Node, Node>();

        var current = head;
        Node prev = null;
        while (current != null) {
            table.putIfAbsent(current, new Node(current.val));

            if (current.random != null) {
                table.putIfAbsent(current.random, new Node(current.random.val));
                table.get(current).random = table.get(current.random);
            }

            if (prev != null) {
                table.get(prev).next = table.get(current);
            }

            prev = current;
            current = current.next;
        }

        return table.get(head);
    }
}