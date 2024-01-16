/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) {
        var iKnowCount = new int[n];
        var knowsMeCount = new int[n];

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (Knows(i, j)) {
                    iKnowCount[i]++;
                    knowsMeCount[j]++;
                }
                if (Knows(j, i)) {
                    iKnowCount[j]++;
                    knowsMeCount[i]++;
                }
            }
        }

        for (int i = 0; i < n; i++) {
            if (iKnowCount[i] == 0 && knowsMeCount[i] == n - 1) {
                return i;
            }
        }

        return -1;
    }
}