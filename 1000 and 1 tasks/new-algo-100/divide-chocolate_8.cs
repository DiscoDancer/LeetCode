public class Solution {
    // editorial
    public int MaximizeSweetness(int[] sweetness, int k) {
        int numberOfPeople = k + 1;
        int left = sweetness.Min();
        int right = sweetness.Sum() / numberOfPeople;

        while (left < right) {
            int mid = (left + right + 1) / 2;
            int curSweetness = 0;
            int peopleWithChocolate = 0;

            foreach (var s in sweetness) {
                curSweetness += s;
                if (curSweetness >= mid) {
                    peopleWithChocolate += 1;
                    curSweetness = 0;
                }
            }

            if (peopleWithChocolate >= numberOfPeople) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }

        return right;
    }
}