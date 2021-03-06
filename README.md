# LeetCode

- Started in 20th of March 2022
- Goal is to have 360 tasks solved in 180 days
- Current plan: ```((DateTime.Now - DateTime.Parse("03/20/2022")).Days + 1) *2```
- Current debt (16.04) is ```-34``` tasks
- https://leetcode.com/DiscoDancer

## Check list:
1. overflow
2. namespaces (using)
3. always return
4. indexing based on 0 or 1
5. If "Given a 1-indexed", then increase indexes only in answer

## Combination Math

1. ```P = n!``` (just amount of combinations, without choosing)
2. ```A = n! / (n - m)!``` (choose m from n, all positions matter)
3. ```C = n! / ((n - m)! * m!)``` (choose m from n, positions don't matter)

## Geometry
- Check if a point belongs to a line: ```(x - x_1) / (x_2 - x1) = (y - y_1) / (y_2 - y_1)```

## C# features:

string API:
```
char[] chars = {'a', ' ', 's', 't', 'r', 'i', 'n', 'g'};
string s = new string(chars);
var a = s.ToCharArray();
char c = s[i];
```

Tuples:
```
var stack = new Stack<(TreeNode node, int acc)>();
stack.Push((root, 0));
```

2d array:
```
var visited = new bool[grid.Length][];
for (int i = 0; i < grid.Length; i++) {
  visited[i] = new bool[grid[0].Length];
}
```

Queue API:
```
q.Enqueue();
q.Dequeue();
q.Peek(); // get first, but not remove
q.Any();
q.Count; 
```

List API:
```
l.RemoveAt();
l.AddRange();
l.Reverse():void;
```

Char API:
```
char.IsLetter(); // static
char.ToLower(char; string, int); // static
char.ToUpper(char; string, int); // static
```

String API:
```
// support of linq
```

Pow and Log:
```
System.Math.Log(8, 2); // 3
System.Math.Pow(8, 2); // 64 
```
Bits API:
```
1 << 1 // left shift 01 -> 10
2 >> 1 // right 10 -> 01
2 & 1 // 10 & 01 = 1
// x = 100; ~x = 011; !x = ~x + 1 = 100;
```

## ASCII
- 'A' < 'a'

## Didn't solve list:
- https://leetcode.com/problems/max-area-of-island/submissions/
- https://leetcode.com/problems/01-matrix/submissions/
- https://leetcode.com/problems/combinations/
- https://leetcode.com/problems/merge-sorted-array/solution/
- https://leetcode.com/problems/reverse-bits/submissions/
- https://leetcode.com/problems/two-sum-iv-input-is-a-bst/submissions/
- https://leetcode.com/problems/maximum-subarray
- https://leetcode.com/problems/maximum-sum-circular-subarray
- https://leetcode.com/problems/maximum-product-subarray
- https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product/
- https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/submissions/
- https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/submissions/
- https://leetcode.com/problems/word-break/