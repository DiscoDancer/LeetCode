/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

// https://leetcode.com/problems/copy-list-with-random-pointer/solutions/169069/copy-list-with-random-pointer/?orderBy=most_votes

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        // would be A->A'->B->B'->C->C'
        var p = head;
        while (p != null) {
            var clone = new Node(p.val);
            clone.next = p.next;
            p.next = clone;
            p = clone.next;
        }

        p = head;
        while (p != null) {
            p.next.random = (p.random != null) ? p.random.next : null;
            p = p.next.next;
        }

            // Unweave the linked list to get back the original linked list and the cloned list.
    // i.e. A->A'->B->B'->C->C' would be broken to A->B->C and A'->B'->C'
    Node ptr_old_list = head; // A->B->C
    Node ptr_new_list = head.next; // A'->B'->C'
    Node head_old = head.next;
    while (ptr_old_list != null) {
      ptr_old_list.next = ptr_old_list.next.next;
      ptr_new_list.next = (ptr_new_list.next != null) ? ptr_new_list.next.next : null;
      ptr_old_list = ptr_old_list.next;
      ptr_new_list = ptr_new_list.next;
    }
    return head_old;

    }
}