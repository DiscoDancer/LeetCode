public class Solution {
    public string GetHint(string secret, string guess) {
        var bulls = 0;
        var cows = 0;
        
        var table = new int[10];
        // secret делает +, guess делает -

        for (int i = 0; i < secret.Length; i++) {
            if (secret[i] == guess[i]) {
                bulls++;
            } else {
                // есть, что списать? списываем
                if (table[guess[i]-'0'] > 0) {
                    cows++;
                }
                if (table[secret[i]-'0'] < 0) {
                    cows++;
                }

                table[secret[i]-'0']++;
                table[guess[i]-'0']--;
            }
        }

        return $"{bulls}A{cows}B";
    }
}