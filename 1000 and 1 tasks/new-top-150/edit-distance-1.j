class Solution {

    private String word1;
    private String word2;

    private int F(int i1, int i2) {
        if (i1 == word1.length() && i2 == word2.length()) {
            return 0;
        }

        // still have both words
        if (i1 < word1.length() && i2 < word2.length()) {
            // they are the same, skip
            if (word1.charAt(i1) == word2.charAt(i2)) {
                return F(i1 + 1, i2 + 1);
            }
            else {
                var removeOption = 1 + F(1 + i1, i2);
                var insertOption = 1 + F(i1, 1 + i2);
                var replaceOption = 1 + F(1 + i1, 1 + i2);
                return Math.min(Math.min(removeOption, replaceOption), insertOption);
            }
        }
        // word1 is out - only insert
        else if (i1 == word1.length()) {
            return 1 + F(i1, 1 + i2);
        }
        // word2 is out - only remove
        else if (i2 == word2.length()) {
            return 1 + F(1 + i1, i2);
        }

        throw new RuntimeException("Should not reach here");
    }

    public int minDistance(String word1, String word2) {
        this.word1 = word1;
        this.word2 = word2;

        return F(0, 0);
    }
}
