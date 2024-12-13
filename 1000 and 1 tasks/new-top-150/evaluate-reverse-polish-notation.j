import java.util.*;

class Solution {

    private static boolean isOperator(String token) {
        return token.equals("+") || token.equals("-") || token.equals("*") || token.equals("/");
    }

    public int evalRPN(String[] tokens) {
        var stack = new Stack<Integer>();

        for (var token : tokens) {
            if (isOperator(token)) {
                var operand2 = stack.pop();
                var operand1 = stack.pop();

                switch (token) {
                    case "+":
                        stack.push(operand1 + operand2);
                        break;
                    case "-":
                        stack.push(operand1 - operand2);
                        break;
                    case "*":
                        stack.push(operand1 * operand2);
                        break;
                    case "/":
                        stack.push(operand1 / operand2);
                        break;
                }
            } else {
                stack.push(Integer.parseInt(token));
            }
        }


        return stack.pop().intValue();
    }
}