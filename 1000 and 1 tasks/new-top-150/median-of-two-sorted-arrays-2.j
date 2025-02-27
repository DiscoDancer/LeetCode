import java.util.Arrays;

class Solution {

    // find-first-and-last-position-of-element-in-sorted-array
    public int findLeft(int[] nums, int target) {
        var n = nums.length;
        var l = 0;
        var r = n-1;
        // >= потому массив может быть [1]
        while (l <= r) {
            var m = l + (r-l)/2;
            if (nums[m] == target && (m == 0 || nums[m-1] != target)) {
                return m;
            }
            if (nums[m] < target) {
                l = m+1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
            else if (nums[m] == target) {
                r = m - 1;
            }
        }

        return -1;
    }
    // find-first-and-last-position-of-element-in-sorted-array
    public int findRight(int[] nums, int target) {
        var n = nums.length;
        var l = 0;
        var r = n-1;
        // >= потому массив может быть [1]
        while (l <= r) {
            var m = l + (r-l)/2;
            if (nums[m] == target && (m == n-1 || nums[m+1] != target)) {
                return m;
            }
            if (nums[m] < target) {
                l = m+1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
            else if (nums[m] == target) {
                l = m + 1;
            }
        }

        return -1;
    }

    // find-first-and-last-position-of-element-in-sorted-array
    public int[] searchRange(int[] nums, int target) {
        var n = nums.length;
        var l = findLeft(nums, target);
        var r = findRight(nums, target);

        if (l == n) {
            return new int[] {-1, -1};
        }

        return new int[]{l,r};
    }

    // search-insert-position
    // editorial (just in cases)
    public int searchInsert(int[] nums, int target) {
        int pivot, left = 0, right = nums.length - 1;
        while (left <= right) {
            pivot = left + (right - left) / 2;
            if (nums[pivot] == target) return pivot;
            if (target < nums[pivot]) right = pivot - 1;
            else left = pivot + 1;
        }
        return left;
    }

    public static int findFirstGreater(int[] arr, int target) {
        int left = 0, right = arr.length - 1;
        int result = -1; // Default to -1 if no element is greater

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (arr[mid] > target) {
                result = mid;  // Store the index and keep searching to the left
                right = mid - 1;
            } else {
                left = mid + 1; // Continue searching to the right
            }
        }

        return result; // Returns the first index with a value greater than target
    }

    public double tryFindInFirst(int[] nums1, int[] nums2) {
        // мы перебираем первый массив, и ищем по второму

        var n = nums1.length;

        var l = 0;
        var r = n - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            var rangeMinNum2 = searchRange(nums2, nums1[m]);
            var rangeMinNum1 = searchRange(nums1, nums1[m]);

            var nums1ContainsLessThanM = rangeMinNum1[0];
            var nums1ContainsMoreThanM = nums1.length - rangeMinNum1[1] - 1;

            int nums2ContainsLessThanM;
            int nums2ContainsMoreThanM;

            if (rangeMinNum2[0] == -1) {
                var insertPosition = searchInsert(nums2, nums1[m]);
                nums2ContainsLessThanM = insertPosition;
                nums2ContainsMoreThanM = nums2.length - insertPosition;
            }
            // nums2 contains nums1[m]
            else {
                nums2ContainsLessThanM = rangeMinNum2[0];
                nums2ContainsMoreThanM = nums2.length - 1 - rangeMinNum2[1];
            }

            var totalLeft = nums1ContainsLessThanM + nums2ContainsLessThanM;
            var totalRight = nums1ContainsMoreThanM + nums2ContainsMoreThanM;
            // >= 1
            var totalMs = nums1.length + nums2.length - totalLeft - totalRight;

            var mMinIndex = totalLeft;
            var mMaxIndex = totalLeft + totalMs - 1;

            var totalNumbers = nums1.length + nums2.length;
            var targetIndex = totalNumbers / 2;


            if (totalNumbers % 2 == 1 && targetIndex >= mMinIndex && targetIndex <= mMaxIndex) {
                return nums1[m];
            }
            // м должно быть первым или втором элементом, потом разберемся
            else if (totalNumbers % 2 == 0 && (targetIndex >= mMinIndex && targetIndex <= mMaxIndex || targetIndex - 1 >= mMinIndex && targetIndex - 1 <= mMaxIndex)) {
                // если оба лежат в м - то берем м
                if (targetIndex >= mMinIndex && targetIndex <= mMaxIndex && targetIndex - 1 >= mMinIndex && targetIndex - 1 <= mMaxIndex) {
                    return nums1[m];
                }

                // для обоих этих случае будет всегда одним из кадидатов - число из первого массива
                // а второй надо найти во втором массиве

                // если в м лежит правое число, надо найти левое
                else if (targetIndex >= mMinIndex && targetIndex <= mMaxIndex) {
                    // вероятно тут ошибка TODO
                    var insertPosition = searchInsert(nums2, nums1[m]) - 1;
                    var candidateFromNums2 = Integer.MAX_VALUE;
                    if (insertPosition >= 0) {
                        candidateFromNums2 = nums2[insertPosition];
                    }

                    var candidateFromNums1 = Integer.MAX_VALUE;
                    if (m - 1 >= 0) {
                        candidateFromNums1 = nums1[m - 1];
                    }

                    if (candidateFromNums1 == Integer.MAX_VALUE) {
                        return (nums1[m] + candidateFromNums2)/2.0;
                    }
                    if (candidateFromNums2 == Integer.MAX_VALUE) {
                        return (nums1[m] + candidateFromNums1)/2.0;
                    }

                    // max: тот кто ближе, тот больше подходит
                    return (nums1[m] + Math.max(candidateFromNums1, candidateFromNums2))/2.0;
                }
                // если в м лежит левое число, надо найти правое
                else if (targetIndex - 1 >= mMinIndex && targetIndex - 1 <= mMaxIndex) {
                    var firstGreaterIndex = findFirstGreater(nums2, nums1[m]);
                    var candidateFromNums2 = Integer.MAX_VALUE;
                    if (firstGreaterIndex != -1) {
                        candidateFromNums2 = nums2[firstGreaterIndex];
                    }

                    var candidateFromNums1 = Integer.MAX_VALUE;
                    if (m + 1 < nums1.length) {
                        candidateFromNums1 = nums1[m + 1];
                    }

                    if (candidateFromNums1 == Integer.MAX_VALUE) {
                        return (nums1[m] + candidateFromNums2)/2.0;
                    }
                    if (candidateFromNums2 == Integer.MAX_VALUE) {
                        return (nums1[m] + candidateFromNums1)/2.0;
                    }

                    // min: тот кто ближе, тот больше подходит
                    return (nums1[m] + Math.min(candidateFromNums1, candidateFromNums2))/2.0;
                }
            }
            else if (mMaxIndex < targetIndex) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return -1;
    }

    public double findMedianSortedArrays(int[] nums1, int[] nums2) {

        var normal = tryFindInFirst(nums1, nums2);
        if (normal != -1) {
            return normal;
        }
        // then do reverse
        return tryFindInFirst(nums2, nums1);
    }
}