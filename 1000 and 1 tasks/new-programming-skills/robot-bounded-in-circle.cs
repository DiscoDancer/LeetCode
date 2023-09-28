public class Solution {
    // fast slow
    // fast 2 инструкции, slow 1
    // инструкции бесконечные выполняем 10 раз например

    enum Directions {
        North,
        East,
        South,
        West
    }

    private int _x = 0;
    private int _y = 0;
    private Directions _direction = Directions.North;



    private void Execute(char c) {
        if (c == 'G') {
            if (_direction == Directions.North) {
                _y++;
            }
            else if (_direction == Directions.South) {
                _y--;
            }
            else if (_direction == Directions.West) {
                _x--;
            }
            else if (_direction == Directions.East) {
                _x++;
            }
        }
        else if (c == 'L') {
            if (_direction == Directions.North) {
                _direction = Directions.West;
            }
            else if (_direction == Directions.South) {
                _direction = Directions.East;
            }
            else if (_direction == Directions.West) {
                _direction = Directions.South;
            }
            else if (_direction == Directions.East) {
                _direction = Directions.North;
            }
        }
        else if (c == 'R') {
            if (_direction == Directions.North) {
                _direction = Directions.East;
            }
            else if (_direction == Directions.South) {
                _direction = Directions.West;
            }
            else if (_direction == Directions.West) {
                _direction = Directions.North;
            }
            else if (_direction == Directions.East) {
                _direction = Directions.South;
            }
        }
    }

    // editorial
    public bool IsRobotBounded(string instructions) {

        foreach (var c in instructions) {
            Execute(c);
        }

        return (_x == 0 && _y == 0 || _direction != Directions.North);
    }
}