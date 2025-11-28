import java.util.*;


class Solution {

    public record Record(int score, boolean label) {}

    public int getOptimalClassification(int[] scores, String labels) {


        var records = new Record[scores.length];
        var count1 = 0;
        for (int i = 0; i < scores.length; i++) {
            records[i] = new Record(scores[i], labels.charAt(i) == '1');
            if (labels.charAt(i) == '1') {
                count1++;
            }
        }
        Arrays.sort(records, (a, b) -> Integer.compare(a.score(), b.score()));

        var count0 = scores.length - count1;

        var result = 0;

        var countActualLeftZeroes = 0;
        var countActualRightOnes = count1;

        // +1 потому что на 1 больше интервал, см картинку
        for (int i = 0; i < records.length + 1; i++) {
            int rightBound;

            int correctAmount0 = i;
            int correctAmount1 = records.length - i;

            // normal case
            if (i != records.length) {
                rightBound = records[i].score;

                if (i == 0) {
                    // сколько единиц - столько правильно
                    result = Math.max(result, count1);
                }
                else {
                    var currentScore = Math.min(countActualLeftZeroes, correctAmount0) + Math.min(countActualRightOnes, correctAmount1);
                    result = Math.max(result, currentScore);

                    var stop = true;
                }
                if (!records[i].label) {
                    countActualLeftZeroes++;
                }
                else {
                    countActualRightOnes--;
                }
            }
            // last - special case
            else {
                // plus infinity
                rightBound = Integer.MAX_VALUE;

                // сколько нулей - столько правильно
                result = Math.max(result, count0);
            }
            // debug
            var stop = true;
        }



        return result;

//        var result = 0;
//        long min = Arrays.stream(scores).min().getAsInt();
//        long max = Arrays.stream(scores).max().getAsInt();
//
//        for (var threshold = min - 1; threshold <= max + 1; threshold++) {
//            var currentResult = 0;
//            for (var i = 0; i < scores.length; i++) {
//                if (scores[i] >= threshold && labels.charAt(i) == '1') {
//                    currentResult++;
//                }
//                else if (scores[i] < threshold && labels.charAt(i) == '0') {
//                    currentResult++;
//                }
//            }
//            result = Math.max(result, currentResult);
//        }
//        return result;
    }
}