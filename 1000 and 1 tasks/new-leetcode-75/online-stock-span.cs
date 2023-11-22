public class StockSpanner {
    // да тут все таки похоже, надо просто сделать 2d
    // нам надо как-то чистить стек
    private Stack<(int val, int score)> _stack = new ();

    public StockSpanner() {
        
    }
    
    public int Next(int price) {
        if (!_stack.Any()) {
            _stack.Push((price, 1));
            return 1;
        }
        
        if (price >= _stack.Peek().val) {
            var result = 1;
            while (_stack.Any() && price >= _stack.Peek().val) {
                var (val, score) = _stack.Pop();
                result += score;
            }
            _stack.Push((price, result));
            return result;
            // var (val, score) = _stack.Peek();
            // _stack.Push((price, score + 1));
            // return score + 1;
        }
        else if (price < _stack.Peek().val) {
            // var (val, score) = _stack.Peek();
            _stack.Push((price, 1));
            return 1;
        }


        return -1;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */