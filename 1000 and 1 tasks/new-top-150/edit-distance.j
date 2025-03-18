class Solution {

    private String word1;
    private String word2;

    private int min = Integer.MAX_VALUE;

    private void F(int i1, int i2, int score) {
        if (i1 == word1.length() && i2 == word2.length()) {
            min = Math.min(min, score);
            return;
        }

        // still have both words
        if (i1 < word1.length() && i2 < word2.length()) {
            // they are the same, skip
            if (word1.charAt(i1) == word2.charAt(i2)) {
                F(i1 + 1, i2 + 1, score);
                return;
            }
            else {
                // remove
                F(1 + i1, i2, score + 1);
                // insert
                F(i1, 1 + i2, score + 1);
                // replace
                F(1 + i1, 1 + i2, score + 1);
            }
        }
        // word1 is out - only insert
        else if (i1 == word1.length()) {
            // insert
            F(i1, 1 + i2, score + 1);
        }
        // word2 is out - only remove
        else if (i2 == word2.length()) {
            // remove
            F(1 + i1, i2, score + 1);
        }
        else {
            throw new RuntimeException("Not implemented");
        }
    }

    public int minDistance(String word1, String word2) {
        this.word1 = word1;
        this.word2 = word2;

        F(0, 0, 0);

        return this.min;
    }
}
