public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var key = (_currX, _currY);
        if (!_mazeMap.ContainsKey(key) || !_mazeMap[key][0])
            throw new InvalidOperationException("Can't go that way!");
        _currX -= 1;
    }

    public void MoveRight()
    {
        var key = (_currX, _currY);
        if (!_mazeMap.ContainsKey(key) || !_mazeMap[key][1])
            throw new InvalidOperationException("Can't go that way!");
        _currX += 1;
    }

    public void MoveUp()
    {
        var key = (_currX, _currY);
        if (!_mazeMap.ContainsKey(key) || !_mazeMap[key][2])
            throw new InvalidOperationException("Can't go that way!");
        _currY -= 1;
    }

    public void MoveDown()
    {
        var key = (_currX, _currY);
        if (!_mazeMap.ContainsKey(key) || !_mazeMap[key][3])
            throw new InvalidOperationException("Can't go that way!");
        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
