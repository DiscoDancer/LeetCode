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
    
    public bool AreDicksMatches(int[] a, int[] b) {
        for (int i = 0; i< a.Length; i++) {
            if (a[i] != b[i]) {
                return false;
            }
        }
        
        return true;
    }
    
    public bool CheckInclusion(string s1, string s2) {
        if (s2.Length < s1.Length) {
            return false;
        }
        
        var dic1 = new int[26];
        var dic2 = new int[26];
        
        for (int k = 0; k < s1.Length; k++)
        {
            dic1[(int)(s1[k] - 'a')]++;
            dic2[(int)(s2[k] - 'a')]++;
        }
        
        var left = 0;
        var right = s1.Length - 1;
        
        for (right = s1.Length - 1; right < s2.Length; right++)  {
            if (AreDicksMatches(dic1, dic2)) {
                return true;
            }
            
            if (right < s2.Length - 1) {
                dic2[(int)(s2[left] - 'a')]--;
                dic2[(int)(s2[right + 1] - 'a')]++;
            }
            
            left++;
        }
        
            if (AreDicksMatches(dic1, dic2)) {
                return true;
            }
           
        return false;
    }
}