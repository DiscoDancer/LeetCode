// naiive
class Solution {
    public ListNode mergeKLists(ListNode[] lists) {

        var fakeHead = new ListNode(-1);
        var fakeTail = fakeHead;

        while (true) {
            var minIndex = -1;
            var minValue = Integer.MAX_VALUE;
            for (var i = 0; i < lists.length; i++) {
                if (lists[i] != null && lists[i].val < minValue) {
                    minIndex = i;
                    minValue = lists[i].val;
                }
            }
            if (minIndex == -1) {
                break;
            }
            fakeTail.next = lists[minIndex];
            fakeTail = fakeTail.next;
            lists[minIndex] = lists[minIndex].next;
            fakeTail.next = null;
        }



        return fakeHead.next;
    }
}