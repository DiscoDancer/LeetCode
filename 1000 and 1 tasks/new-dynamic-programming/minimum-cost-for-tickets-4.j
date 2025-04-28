import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public int mincostTickets(int[] days, int[] costs) {
        var table = new int[days.length + 1];
        for (var i = days.length - 1; i >= 0; i--) {
            // если я здесь, то нужно купить билет
            var day1 = table[i+1] + costs[0];

            var day7ValidUntilIncluding = days[i] + 7 - 1;
            var day7NextIndex = i + 1;
            while (day7NextIndex < days.length && days[day7NextIndex] <= day7ValidUntilIncluding) {
                day7NextIndex++;
            }
            var day7 = table[day7NextIndex] + costs[1];

            var day30ValidUntilIncluding = days[i] + 30 - 1;
            var day30NextIndex = i + 1;
            while (day30NextIndex < days.length && days[day30NextIndex] <= day30ValidUntilIncluding) {
                day30NextIndex++;
            }
            var day30 = table[day30NextIndex] + costs[2];

            table[i] = Math.min(day7, Math.min(day1, day30));
        }

        return table[0];
    }
}
