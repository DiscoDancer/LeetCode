/**
 * // This is the ImmutableListNode's API interface.
 * // You should not implement it, or speculate about its implementation.
 * class ImmutableListNode {
 *     public void PrintValue(); // print the value of this node.
 *     public ImmutableListNode GetNext(); // return the next node.
 * }
 */

public class Solution {
    public void PrintLinkedListInReverse(ImmutableListNode head) {
        var stack = new Stack<ImmutableListNode>();
        var cur = head;
        while (cur != null) {
            stack.Push(cur);
            cur = cur.GetNext();
        }

        while (stack.Any()) {
            var top = stack.Pop();
            top.PrintValue();
        }
    }
}