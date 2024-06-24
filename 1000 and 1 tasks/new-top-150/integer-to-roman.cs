public class Solution {
    private string Get100(int i) {
        if (i == 9) {
            return "CM";
        }
        else if (i == 8) {
            return "DCCC";
        }
        else if (i == 7) {
            return "DCC";
        }
        else if (i == 6) {
            return "DC";
        }
        else if (i == 5) {
            return "D";
        }
        else if (i == 4) {
            return "CD";
        }
        else if (i == 3) {
            return "CCC";
        }
        else if (i == 2) {
            return "CC";
        }
        else if (i == 1) {
            return "C";
        }
        return "";
    }

    private string Get10(int i) {
        if (i == 9) {
            return "XC";
        }
        else if (i == 8) {
            return "LXXX";
        }
        else if (i == 7) {
            return "LXX";
        }
        else if (i == 6) {
            return "LX";
        }
        else if (i == 5) {
            return "L";
        }
        else if (i == 4) {
            return "XL";
        }
        else if (i == 3) {
            return "XXX";
        }
        else if (i == 2) {
            return "XX";
        }
        else if (i == 1) {
            return "X";
        }
        return "";
    }

    private string Get1(int i) {
        if (i == 9) {
            return "IX";
        }
        else if (i == 8) {
            return "VIII";
        }
        else if (i == 7) {
            return "VII";
        }
        else if (i == 6) {
            return "VI";
        }
        else if (i == 5) {
            return "V";
        }
        else if (i == 4) {
            return "IV";
        }
        else if (i == 3) {
            return "III";
        }
        else if (i == 2) {
            return "II";
        }
        else if (i == 1) {
            return "I";
        }
        return "";
    }

    public string IntToRoman(int num) {
        var sb = new StringBuilder();

        var i = num / 1000;
        while (i > 0) {
            sb.Append('M');
            i--;
        }
        num -= num / 1000 * 1000;

        sb.Append(Get100(num / 100));
        num -= num / 100 * 100;

        sb.Append(Get10(num / 10));
        num -= num / 10 * 10;

        sb.Append(Get1(num));

        return sb.ToString();
    }
}