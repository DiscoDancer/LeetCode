
// TL
class Solution {
    // trie
    private boolean isPerm(String s, String[] words) {
        var hashmap = new HashMap<String, Integer>();
        for (var word : words) {
            hashmap.put(word, hashmap.getOrDefault(word, 0) + 1);
        }

        for (int i = 0; i < s.length() / words[0].length(); i++) {
            var substring = s.substring(i * words[0].length(), (i + 1) * words[0].length());
            if (!hashmap.containsKey(substring)) {
                return false;
            }
            hashmap.put(substring, hashmap.get(substring) - 1);
        }

        for (var value : hashmap.values()) {
            if (value != 0) {
                return false;
            }
        }

        return true;
    }

    public List<Integer> findSubstring(String s, String[] words) {
        var result = new ArrayList<Integer>();
        var totalLength = words[0].length() * words.length;
        for (var i = 0; i < s.length() - totalLength + 1; i++) {
            var substring = s.substring(i, i + totalLength);
            if (isPerm(substring, words)) {
                result.add(i);
            }
        }

        return result;
    }
}