public class Solution {
    public static void FillArray(int[,] array, int val)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = val;
            }
        }
    }
    
    private int Calc1(int table)
    {
        var count = 0;
        while (table > 0)
        {
            if (table % 2 == 1)
            {
                count++;
            }

            table /= 2;
        }

        return count;
    }

    public int MaxStudents(char[][] seats)
    {
        int m = seats.Length, n = seats[0].Length;
        int[] validRows = new int[m];
        for (int i = 0; i < m; i++)
        for (int j = 0; j < n; j++)
            validRows[i] = (validRows[i] << 1) + (seats[i][j] == '.' ? 1 : 0);
        int stateSize = 1 << n; // There are 2^n states for n columns in binary format
        var dp = new int[m, stateSize];
        FillArray(dp, -1);
        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < stateSize; j++)
            {
                // (j & valid) == j: check if j is a subset of valid
                // !(j & (j >> 1)): check if there is no adjancent students in the row
                if (((j & validRows[i]) == j) && ((j & (j >> 1)) == 0))
                {
                    if (i == 0)
                    {
                        dp[i,j] = Calc1(j);
                    }
                    else
                    {
                        for (int k = 0; k < stateSize; k++)
                        {
                            // !(j & (k >> 1)): no students in the upper left positions
                            // !((j >> 1) & k): no students in the upper right positions
                            // dp[i-1][k] != -1: the previous state is valid
                            if ((j & (k >> 1)) == 0 && ((j >> 1) & k) == 0 && dp[i - 1,k] != -1)
                            {
                                dp[i,j] = Math.Max(dp[i,j], dp[i - 1,k] + Calc1(j));
                            }
                        }
                    }

                    ans = Math.Max(ans, dp[i,j]);
                }
            }
        }

        return ans;
    }
}