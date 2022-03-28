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

Queue API:
```
q.Enqueue();
q.Dequeue();
q.Peek(); // get first, but not remove
q.Any();
q.Count; 
```

Pow and Log:
```
System.Math.Log(8, 2); // 3
System.Math.Pow(8, 2); // 64 
```

## Didn't solve list:
- https://leetcode.com/problems/max-area-of-island/submissions/
- https://leetcode.com/problems/01-matrix/submissions/
