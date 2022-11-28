public class Solution {
    // бинарный ускорит перебор, если сделаем сортирвку
    // count sort даст супер буст
    public bool CheckIfExist(int[] arr) {
        // мб не важно, плюс или минус ? Важно!
        var positiveValues = new int[1001];
        var negativeValues = new int[1001];
        
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] >= 0) {
                positiveValues[arr[i]]++;
            } else {
                negativeValues[-arr[i]]++;
            }
        }
        
        if (positiveValues[0] > 1) {
            return true;
        }
        
        // такс, и 0.5 и не обязательно искать
        // но можно и то, и то
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] > 0) {
                if (arr[i] * 2 <= 1000) {
                    if (positiveValues[arr[i] * 2] > 0) {
                        return true;
                    }
                }
                else if (arr[i] % 2 == 0) {
                    if (positiveValues[arr[i] / 2] > 0) {
                        return true;
                    }
                }
            }
            else if (arr[i] < 0) {
                if (arr[i]*2 >= -1000) {
                    if (negativeValues[(- arr[i]) * 2] > 0) {
                        return true;
                    }
                }
                else if (arr[i] % 2 == 0) {
                    if (negativeValues[(- arr[i]) / 2] > 0) {
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
}