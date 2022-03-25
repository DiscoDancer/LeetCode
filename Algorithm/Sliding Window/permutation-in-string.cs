using System.Linq;

public class Solution {
    
    // same length
    public static bool ArePermutation(string template, string target, int i, int j)
    {
        var arr = new int[26];

        for (int k = 0; k < template.Length; k++)
        {
            arr[(int)(template[k] - 'a')]++;
        }

        while (i <= j)
        {
            arr[(int)(target[i] - 'a')]--;
            i++;
        }

        for (int k = 0; k < 26; k++)
        {
            if (arr[k] != 0)
            {
                return false;
            }
        }

        return true;
    }
    
    public bool CheckInclusion(string s1, string s2) {
        if (s2.Length < s1.Length) {
            return false;
        }
        
        var goalSum = s1.Sum(x => x);
        var a = s2.ToCharArray();
        
        var left = 0;
        var right = s1.Length - 1;
        
        
        // todo не пересчитывать всю сумму
        // permutation нельзя считать суммой abc = bbb
        
        int sum = 0;
        for (right = s1.Length - 1; right < s2.Length; right++) {
            
            var res = ArePermutation(s1,s2,left, right);
            if (res) {
                return true;
            }
            
            left++;
        }
        
        return false;
    }
}