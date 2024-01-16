/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) {
        var iKnowTable = new List<int>[n];
        var knowsMeTable = new List<int>[n];

        for (int i = 0; i < n; i++) {
            iKnowTable[i] = new ();
            knowsMeTable[i] = new ();
        }

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (Knows(i, j)) {
                    iKnowTable[i].Add(j);
                    knowsMeTable[j].Add(i);
                }
                if (Knows(j, i)) {
                    iKnowTable[j].Add(i);
                    knowsMeTable[i].Add(j);
                }
            }
        }

        for (int i = 0; i < n; i++) {
            if (iKnowTable[i].Count() == 0 && knowsMeTable[i].Count() == n - 1) {
                return i;
            }
        }

        return -1;
    }
}