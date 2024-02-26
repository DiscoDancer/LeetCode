public class SnakeGame
{
    // хвост - это наши предыдущие ходы

    private int _length = 0;
    private int _X;
    private int _Y;
    private int[,] _map;

    public const int EMPTY = 0;
    public const int FOOD = 1;
    public const int SNAKE = 2;

    private Queue<(int x, int y)> _moves = new();
    private Queue<(int x, int y)> _food = new();
    
    private int _x = 0;
    private int _y = 0;

    private void TrySetNextFood()
    {
        if (_food.Count > 0)
        {
            // When a piece of food appears on the screen, it is guaranteed that it will not appear on a block occupied by the snake.
            var nextFood = _food.Dequeue();
            _map[nextFood.x, nextFood.y] = FOOD;
        }
    }
    
    public SnakeGame(int width, int height, int[][] food)
    {
        _X = height;
        _Y = width;

        _map = new int[_X, _Y];
        foreach (var xy in food)
        {
            var x = xy[0];
            var y = xy[1];
            
            _food.Enqueue((x,y));
        }

        TrySetNextFood();

        _map[0, 0] = SNAKE;
        _moves.Enqueue((0, 0));
    }

    public int Move(string direction)
    {
        if (direction == "D")
        {
            _x++;
        }
        else if (direction == "R")
        {
            _y++;
        }
        else if (direction == "L")
        {
            _y--;
        }
        else if (direction == "U")
        {
            _x--;
        }

        // hit a wall aka went outside
        if (_x < 0 || _x == _X || _y < 0 || _y == _Y)
        {
            return -1;
        }

        // unsnake
        if (_moves.Count() > _length)
        {
            var (x0, y0) = _moves.Dequeue();
            _map[x0, y0] = EMPTY;
        }
        // went to itself
        if (_map[_x, _y] == SNAKE)
        {
            return -1;
        }
        else if (_map[_x, _y] == FOOD)
        {
            _length++;
            TrySetNextFood();
        }
        
        _moves.Enqueue((_x, _y));
        _map[_x, _y] = SNAKE;
        
        return _length;
    }
}