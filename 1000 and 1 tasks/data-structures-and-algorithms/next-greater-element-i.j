import java.util.*;


class Solution {
    public int[] nextGreaterElement(int[] nums1, int[] nums2) {

        var firstBiggerThan = new int[nums2.length];
        // fill -1
        for (var i = 0; i < nums2.length; i++) {
            firstBiggerThan[i] = -1;
        }

        // тут будут лежать от большего к меньшему
        var bufferOfIndexes = new ArrayList<Integer>();
        for (var i = 0; i < nums2.length; i++) {
            if (i == 0) {
                // do nothing special
            }
            else {
                // пытаемся применить текущий элемент к тем, что остались
                while (!bufferOfIndexes.isEmpty() && nums2[bufferOfIndexes.getLast()] < nums2[i]) {
                    var lastIndex = bufferOfIndexes.removeLast();
                    firstBiggerThan[lastIndex] = i;
                }
            }
            bufferOfIndexes.add(i);
            var stop = true;
        }

        var hashMap = new HashMap<Integer, Integer>();
        for (var i = 0; i < nums2.length; i++) {
            hashMap.put(nums2[i], i);
        }

        var result = new int[nums1.length];
        for (var i = 0; i < nums1.length; i++) {
            var indexIn2 = hashMap.get(nums1[i]);
            result[i] = firstBiggerThan[indexIn2];
            if (result[i] > 0) {
                result[i] = nums2[result[i]];
            }
        }

        return result;
    }
}