public class Solution {
    public string GetHint(string secret, string guess) {
        var bulls = 0;
        var tableGuess = new int[10];
        var tableSecret = new int[10];
        for (int i = 0; i < secret.Length; i++) {
            if (secret[i] == guess[i]) {
                bulls++;
            } else {
                tableGuess[guess[i]-'0']++;
                tableSecret[secret[i]-'0']++;
            }
        }

        var cows = 0;

        for (int i = 0; i < 10; i++) {
            cows += Math.Min(tableGuess[i], tableSecret[i]);
        }

        return $"{bulls}A{cows}B";
    }
}