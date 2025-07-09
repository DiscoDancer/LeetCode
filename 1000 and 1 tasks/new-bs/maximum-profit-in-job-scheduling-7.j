import java.math.BigInteger;
import java.util.*;


class Solution {
    private ArrayList<Entry> entries;

    private record Entry(int start, int end, int profit) implements Comparable<Entry> {
        @Override
        public int compareTo(Entry o) {
            return Integer.compare(this.start, o.start);
        }
    }

    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {

        this.entries = new ArrayList<>(startTime.length);
        for (int i = 0; i < startTime.length; i++) {
            entries.add(new Entry(startTime[i], endTime[i], profit[i]));
        }
        entries.sort(Entry::compareTo);

        // в начале просто записываем в массив profit
        // мы строим функцию не для каждой точки, а глобальный результат
        var table = new long[entries.size()];
        for (int i = 0; i < entries.size(); i++) {
            table[i] = entries.get(i).profit;
        }

        for (int i = entries.size() - 2; i >= 0; i--) {
            // простая propogation самого большого результата
            // это нужно для того, чтобы оставновиться и не искать другие значения - break ниже
            /*
                    Пример:

                    1-2PM 30; 3-8PM 20; 5-6PM 100
                    Для 1-2PM 30 нам придется проверить все варианты, но если 3-8PM 20; уже будет иметь 100, а не 20, то мы сразу можем остановиться !!!
             */
            table[i] = Math.max(table[i], table[i + 1]);
            for (var j = i + 1; j < entries.size(); j++) {
                if (entries.get(i).end <= entries.get(j).start) {
                    table[i] = Math.max(table[i], entries.get(i).profit + table[j]);
                    // это самое важное здесь!
                    break;
                }
            }
        }

        return (int)table[0];
    }
}