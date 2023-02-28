public class Solution {
  // если индекс выше, то сильнее при равных
  // переводить двоичную в десятичную
  // считать единички можно бинарным поиском
  // можно отсорировать матрицу по строка и тогда получить индексы за О(1)
  // матрицу представить как массив или инвертировать

  // матрица не квадратная !
  public int[] KWeakestRows(int[][] mat, int k) {
    var left = k;
    var result = new List < int > ();

    // нужно баннить строки

    var isBanned = new bool[mat.Length];

    // столбец
    for (int i = 0; i < mat[0].Length; i++) {
      // строка
      for (int j = 0; j < mat.Length; j++) {
        if (!isBanned[j] && mat[j][i] == 0) {
          result.Add(j);
          left--;
          isBanned[j] = true;

          if (left == 0) {
            return result.ToArray();
          }
        }
      }
    }

    for (int i = 0; i < mat.Length && left > 0; i++) {
      if (!isBanned[i]) {
        result.Add(i);
        isBanned[i] = true;
        left--;
      }
    }

    return result.ToArray();
  }
}