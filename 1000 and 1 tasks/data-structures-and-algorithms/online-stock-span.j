import java.util.ArrayList;
import java.util.List;

// passes, but feels not effective

class StockSpanner {

    private List<Integer> data;

    public StockSpanner() {
        data = new ArrayList<>();
    }

    public int next(int price) {
        var count = 1;
        if (!data.isEmpty()) {

            var i = data.size() - 1;
            while (i >= 0) {
                if (data.get(i) <= price) {
                    count++;
                }
                else {
                    break;
                }
                i--;
            }
        }

        data.add(price);
        return count;
    }
}