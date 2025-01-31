import java.util.HashMap;
import java.util.List;

class Solution {

    public record Measurement(String unit, double coefficient) {}

    private HashMap<String, Measurement> table = new HashMap<>();

    private void squeeze(String b) {
        // ensure that b is root
        var bMeasurement = table.get(b);
        var bUnit = bMeasurement.unit;
        var bCoefficient = bMeasurement.coefficient;
        while (table.get(bUnit).unit != bUnit) {
            bCoefficient *= table.get(bUnit).coefficient;
            bUnit = table.get(bUnit).unit ;
        }
        // rewrite in any case
        table.put(b, new Measurement(bUnit, bCoefficient));
    }

    public double[] calcEquation(List<List<String>> equations, double[] values, List<List<String>> queries) {

        for (var equation : equations) {
            var a = equation.get(0);
            var b = equation.get(1);

            table.put(a, new Measurement(a, 1.0));
            table.put(b, new Measurement(b, 1.0));
        }

        for (int i = 0; i < equations.size(); i++) {
            var equation = equations.get(i);
            var value = values[i];

            var a = equation.get(0);
            var b = equation.get(1);

            squeeze(a);
            squeeze(b);

            // a / b = 2.0
            // a = 2.0 * b + у них еще коэффициенты есть!
            table.put(table.get(a).unit, new Measurement(table.get(b).unit, value * table.get(b).coefficient / table.get(a).coefficient));
        }

        var result = new double[queries.size()];
        for (int i = 0; i < queries.size(); i++) {
            var query = queries.get(i);
            var a = query.get(0);
            var b = query.get(1);
            if (!table.containsKey(a) || !table.containsKey(b)) {
                result[i] = -1.0;
            }
            else {
                // ensure that a is root
                squeeze(a);
                // ensure that b is root
                squeeze(b);

                if (table.get(a).unit == table.get(b).unit ) {
                    result[i] = table.get(a).coefficient / table.get(b).coefficient ;
                }
                else {
                    result[i] = -1.0;
                }
            }
        }

        return result;
    }
}