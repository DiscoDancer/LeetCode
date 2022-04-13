public class Solution {
    public string Interpret(string command) {
        var sb = new StringBuilder();
        
        for (int i = 0; i < command.Length; i++) {
            if (command[i] == 'G') {
                sb.Append('G');
                continue;
            }
            
            if (command[i] == '(') {
                i++;
                if (command[i] == ')') {
                    sb.Append('o');
                    continue;
                }
                
                if (command[i] == 'a') {
                    i+=2;
                    sb.Append("al");
                    continue;
                }
            }
        }
        
        return sb.ToString();
    }
}