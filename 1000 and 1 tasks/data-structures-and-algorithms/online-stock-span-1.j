import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

// editorial

class StockSpanner {

    record Pair<A, B>(A first, B second) {}

    private Stack<Pair<Integer, Integer>> stack;

    public StockSpanner() {
        stack = new Stack<>();
    }

    public int next(int price) {
        var result = 1;

        while (!stack.isEmpty() && stack.peek().first <= price) {
            var popped = stack.pop();
            var score = popped.second;
            result += score;
        }

        stack.push(new Pair<>(price, result));

        return result;
    }
}