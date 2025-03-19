class Solution {
    public int minDistance(String word1, String word2) {
        var table = new int[word1.length() + 1][word2.length() + 1];

        for (var i1 = word1.length(); i1 >= 0; i1--) {
            for (var i2 = word2.length(); i2 >= 0; i2--) {
                if (i1 == word1.length() && i2 == word2.length()) {
                    table[i1][i2] = 0;
                }
                else if (i1 < word1.length() && i2 < word2.length()) {
                    if (word1.charAt(i1) == word2.charAt(i2)) {
                        table[i1][i2] = table[i1 + 1][i2 + 1];
                    }
                    else {
                        var removeOption = 1 + table[i1 + 1][i2];
                        var insertOption = 1 + table[i1][i2 + 1];
                        var replaceOption = 1 + table[i1 + 1][i2 + 1];
                        table[i1][i2] = Math.min(Math.min(removeOption, replaceOption), insertOption);
                    }
                }
                else if (i1 == word1.length()) {
                    table[i1][i2] = 1 + table[i1][i2 + 1];
                }
                else if (i2 == word2.length()) {
                    table[i1][i2] = 1 + table[i1 + 1][i2];
                }
            }
        }

        return table[0][0];
    }
}
