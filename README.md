# LeetCode

## Check list:
1. overflow
2. namespaces (using)
3. always return
4. indexing based on 0 or 1
5. If "Given a 1-indexed", then increase indexes only in answer

## C# features:

Chars to string:
```
char[] chars = {'a', ' ', 's', 't', 'r', 'i', 'n', 'g'};
string s = new string(chars);
```

String to chars:
```
var a = s.ToCharArray();
```

2d array:
```
var visited = new bool[grid.Length][];
for (int i = 0; i < grid.Length; i++) {
  visited[i] = new bool[grid[0].Length];
}
```

## Didn't solve list:
- https://leetcode.com/problems/max-area-of-island/submissions/
