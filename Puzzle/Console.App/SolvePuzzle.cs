internal class SolvePuzzle
{
    int[,,] theVolume = new int[5, 5, 5];

    public void run()
    {
        var variants = GetPositionVariants();

        var res = Solve(theVolume, variants);

        Helper.PrintVolume(res.Item2);

        Console.WriteLine(res.Item1 ? "Solution  found" : "Solution NOT found");
    }

    private (bool, int[,,]) Solve(int[,,] volume, List<IRun> variants, int counter = 1)
    {
        if (counter == 26) return (true, volume);
        if (variants == null) throw new Exception("variants null");

        var variantIndex = 0;
        var position = Helper.GetNextFreePosition(volume);
        if (position == null) return (true, volume);

        while (variantIndex <= (variants.Count - 1))
        {
            var copy = Helper.CopyVolume(volume);

            var variant = variants[variantIndex++];
            var resA = variant.Run(copy, position, counter);

            if (resA.Item1)
            {
                var newCounter = counter+1;
                var ret = Solve(resA.Item2, variants, newCounter);
                if (ret.Item1)
                {
                    return ret;
                }
            }
        }
        return (false, volume);
    }

    private List<IRun> GetPositionVariants()
    {
        var ret = new List<IRun>
        {
            new Action1(),
            new Action2(),
            new Action3(),
            new Action4(),
            new Action5(),
            new Action6(),
            new Action7(),
            new Action8(),
            new Action9(),
            new Action10(),

            new Actiony1(),
            new Actiony2(),
            new Actiony3(),
            new Actiony4(),
            new Actiony5(),
            new Actiony6(),

            new Actionz1(),
            new Actionz2(),
            new Actionz3(),
            new Actionz4(),
            new Actionz5(),
            new Actionz6(),
            new Actionz7(),
            new Actionz8(),
        };

        return ret;
    }

}


public class Position
{
    public int x, y, z;

    public Position(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Position Clone(int addX, int addY, int addZ)
    {
        var ret = new Position(x + addX, y + addY, z + addZ);

        return ret;
    }
}


interface IRun
{
    (bool, int[,,]) Run(int[,,] volume, Position position, int fillValue);
}


public abstract class Action : IRun
{
    public abstract List<Position> GetPositions(Position position);

    public (bool, int[,,]) Run(int[,,] volume, Position position, int fillValue)
    {
        var copy = Helper.CopyVolume(volume);

        var positions = GetPositions(position);

        if (Helper.FillVolume(ref copy, positions, fillValue))
        {
            return (true, copy);
        }
        return (false, volume);
    }

}

// Figure
//   -
// ----
//
public class Action1 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(1, 0, 0),
            position.Clone(2, 0, 0),
            position.Clone(3, 0, 0),
            
            position.Clone(1, 1, 0)
        };
        return positions;
    }
}

public class Action2 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(1, 0, 0),
            position.Clone(2, 0, 0),
            position.Clone(3, 0, 0),
            
            position.Clone(2, 1, 0)
        };
        return positions;
    }
}

public class Action3 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(1, 0, 0),
            position.Clone(2, 0, 0),
            position.Clone(3, 0, 0),

            position.Clone(1, 0, 1)
        };
        return positions;
    }
}

public class Action4 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(1, 0, 0),
            position.Clone(2, 0, 0),
            position.Clone(3, 0, 0),

            position.Clone(2, 0, 1)
        };
        return positions;
    }
}

//
// 
public class Action5 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),

            position.Clone(0, 0, 1),
            position.Clone(-1, 0, 1),
            position.Clone(-2, 0, 1),
            position.Clone(1, 0, 1)
        };
        return positions;
    }
}

public class Action6 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),

            position.Clone(0, 0, 1),
            position.Clone(-1, 0, 1),
            position.Clone(1, 0, 1),
            position.Clone(2, 0, 1)
        };
        return positions;
    }
}

public class Action7 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),

            position.Clone(0, 1, 0),
            position.Clone(-1, 1, 0),
            position.Clone(-2, 1, 0),
            position.Clone(1, 1, 0)
        };
        return positions;
    }
}

public class Action8 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),

            position.Clone(0, 0, 1),
            position.Clone(-1, 0, 1),
            position.Clone(1, 0, 1),
            position.Clone(2, 0, 1)
        };
        return positions;
    }
}

public class Action9 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),

            position.Clone(0, 1, 0),
            position.Clone(-1, 1, 0),
            position.Clone(-2, 1, 0),
            position.Clone(1, 1, 0)
        };
        return positions;
    }
}

public class Action10 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),

            position.Clone(0, 1, 0),
            position.Clone(-1, 1, 0),
            position.Clone(1, 1, 0),
            position.Clone(2, 1, 0)
        };
        return positions;
    }
}

public class Actiony1 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 1, 0),
            position.Clone(0, 2, 0),
            position.Clone(0, 3, 0),

            position.Clone(-1, 1, 0)
        };
        return positions;
    }
}

public class Actiony2 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 1, 0),
            position.Clone(0, 2, 0),
            position.Clone(0, 3, 0),

            position.Clone(-1, 2, 0)
        };
        return positions;
    }
}

public class Actiony3 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 1, 0),
            position.Clone(0, 2, 0),
            position.Clone(0, 3, 0),

            position.Clone(0, 1, 1)
        };
        return positions;
    }
}

public class Actiony4 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 1, 0),
            position.Clone(0, 2, 0),
            position.Clone(0, 3, 0),

            position.Clone(0, 2, 1)
        };
        return positions;
    }
}

public class Actiony5 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 1, 0),
            position.Clone(0, 2, 0),
            position.Clone(0, 3, 0),

            position.Clone(1, 1, 0)
        };
        return positions;
    }
}

public class Actiony6 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 1, 0),
            position.Clone(0, 2, 0),
            position.Clone(0, 3, 0),

            position.Clone(1, 2, 0)
        };
        return positions;
    }
}


public class Actionz1 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(1, 0, 1),
        };
        return positions;
    }
}

public class Actionz2 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(1, 0, 2),
        };
        return positions;
    }
}

public class Actionz3 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(0, -1, 1),
        };
        return positions;
    }
}

public class Actionz4 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(0, -1, 2),
        };
        return positions;
    }
}

public class Actionz5 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(-1, 0, 1),
        };
        return positions;
    }
}


public class Actionz6 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(-1, 0, 2),
        };
        return positions;
    }
}

public class Actionz7 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(0, 1, 1),
        };
        return positions;
    }
}

public class Actionz8 : Action
{
    public override List<Position> GetPositions(Position position)
    {
        var positions = new List<Position>
        {
            position.Clone(0, 0, 0),
            position.Clone(0, 0, 1),
            position.Clone(0, 0, 2),
            position.Clone(0, 0, 3),

            position.Clone(0, 1, 2),
        };
        return positions;
    }
}



public static class Helper
{
    public static int[,,] CopyVolume(int[,,] volume)
    {
        int[,,] ret = new int[5, 5, 5];
        Array.Copy(volume, ret, 5 * 5 * 5);
        return ret;
    }

    public static bool FillVolume(ref int[,,] volume, List<Position> positions, int fillValue)
    {
        foreach (var pos in positions)
        {
            if (!FillVolume(ref volume, pos, fillValue))
            {
                return false;
            }
        }

        return true;
    }

    public static bool FillVolume(ref int[,,] volume, Position pos, int fillValue)
    {
        if (pos.x >= 5 || pos.x < 0 ||
            pos.y >= 5 || pos.y < 0 ||
            pos.z >= 5 || pos.z <0 )
        {
            return false;
        }

        if (volume[pos.x, pos.y, pos.z] != 0)
        {
            return false;
        }

        volume[pos.x, pos.y, pos.z] = fillValue;

        return true;
    }

    public static Position? GetNextFreePosition(int[,,] volume)
    {
        for (int z = 0; z < 5; z++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                   if (volume[x, y, z] == 0) return new Position(x, y, z);
                }
            }
        }

        return null;
    }

    public static void PrintVolume(int[,,] volume)
    {
        for (int z = 0; z < 5; z++)
        {
            for (int y = 4; y >= 0; y--)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write($"{volume[x,y,z],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}

