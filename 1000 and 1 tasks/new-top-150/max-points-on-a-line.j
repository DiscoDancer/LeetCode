class Solution {
    // (x - x_1) / (x_2 - x1) = (y - y_1) / (y_2 - y_1)
    // https://ru.stackoverflow.com/questions/55734/%D0%9A%D0%B0%D0%BA-%D0%BE%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D0%B8%D1%82%D1%8C-%D0%BB%D0%B5%D0%B6%D0%B0%D1%82-%D0%BB%D0%B8-%D1%82%D0%BE%D1%87%D0%BA%D0%B8-%D0%BD%D0%B0-%D0%BE%D0%B4%D0%BD%D0%BE%D0%B9-%D0%BF%D1%80%D1%8F%D0%BC%D0%BE%D0%B9
    public int maxPoints(int[][] points) {

        var max = (points.length < 3) ? points.length : 0;

        for (var i = 0; i < points.length; i++) {
            var x1 = points[i][0];
            var y1 = points[i][1];
            for (var j = i+1; j < points.length; j++) {
                var x2 = points[j][0];
                var y2 = points[j][1];

                var count = 0;
                for (var k = 0; k < points.length; k++) {
                    var x3 = points[k][0];
                    var y3 = points[k][1];

                    if ((double)(x3-x1)*(y2-y1) == (double)(x2-x1)*(y3-y1)) {
                        count++;
                    }
                }

                max = Math.max(max, count);
            }
        }

        return max;
    }
}