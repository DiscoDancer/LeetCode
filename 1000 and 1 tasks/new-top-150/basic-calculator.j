import java.util.*;

class Solution {

    enum TokenType {
        NUMBER,
        PLUS,
        MINUS,
        OPEN_BRACKET,
        CLOSE_BRACKET,
    }

    private class Token {
        TokenType type;
        Integer value;

        Token(TokenType type, Integer value) {
            this.type = type;
            this.value = value;
        }

        Token(TokenType type) {
            this.type = type;
            this.value = null;
        }
    }

    // remove spaces
    // нету умножения
    // токенизация
    public int calculate(String s) {

        var tokens = new ArrayList<Token>();
        for (var i = 0; i < s.length(); i++) {
            var c = s.charAt(i);

            if (c == ' ') {
                continue;
            } else if (c == '+') {
                tokens.add(new Token(TokenType.PLUS));
            } else if (c == '-') {
                tokens.add(new Token(TokenType.MINUS));
            } else if (c == '(') {
                tokens.add(new Token(TokenType.OPEN_BRACKET));
            } else if (c == ')') {
                tokens.add(new Token(TokenType.CLOSE_BRACKET));
            } else {
                var sb = new StringBuilder();
                var j = i;
                while (j < s.length() && Character.isDigit(s.charAt(j))) {
                    sb.append(s.charAt(j));
                    j++;
                }
                var num = Integer.parseInt(sb.toString());
                if (!tokens.isEmpty() && tokens.get(tokens.size() - 1).type == TokenType.MINUS) {
                    num *= -1;
                    tokens.removeLast();
                } else if (!tokens.isEmpty() && tokens.get(tokens.size() - 1).type == TokenType.PLUS) {
                    tokens.removeLast();
                }

                tokens.add(new Token(TokenType.NUMBER, num));

                i = j - 1;
            }
        }

        // round 1: remove brackets
        var stack = new Stack<Token>();
        for (var token : tokens) {
            if (token.type == TokenType.CLOSE_BRACKET) {
                var result = 0;
                while (stack.peek().type != TokenType.OPEN_BRACKET) {
                    var t = stack.pop();
                    if (t.type == TokenType.NUMBER) {
                        result += t.value;
                    } else {
                        throw new RuntimeException("Unexpected token");
                    }
                }
                stack.pop();

                if (!stack.isEmpty() && stack.getLast().type == TokenType.MINUS) {
                    stack.removeLast();
                    result *= -1;
                }
                else if (!stack.isEmpty() && stack.getLast().type == TokenType.PLUS) {
                    stack.removeLast();
                }

                stack.push(new Token(TokenType.NUMBER, result));

            } else {
                stack.push(token);
            }
        }

        var result = 0;
        while (!stack.isEmpty()) {
            var t = stack.pop();
            if (t.type == TokenType.NUMBER) {
                result += t.value;
            } else {
                throw new RuntimeException("Unexpected token");
            }
        }

        return result;
    }
}