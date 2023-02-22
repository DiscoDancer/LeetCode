/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    // мб все таки стек?

    private Stack<NestedInteger> _stack = new ();

    public NestedIterator(IList<NestedInteger> nestedList) {
        var size = nestedList.Count();
        for (int i = size - 1; i >= 0; i--) {
            _stack.Push(nestedList[i]);
        }
    }

    public bool HasNext() {
        if (!_stack.Any()) {
            return false;
        }

        while (_stack.Any()) {
            var top = _stack.Peek();
            if (top.IsInteger()) {
                return true;
            }
            top = _stack.Pop();
            var size = top.GetList().Count();
            for (int i = size - 1; i >= 0; i--) {
                _stack.Push(top.GetList()[i]);
            }
        }

        return false;
    }

    public int Next() {
        return _stack.Pop().GetInteger();
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */