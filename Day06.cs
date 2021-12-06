namespace AdventOfCode21;

public class Day06 : DayX
{
    public override void Part1()
    {
        var fishes = ParseInput(_input);

        int restartTimer = 7;
        int newBornTimer = restartTimer + 2;
        int simulationLength = 256;
        // main loop
        for(int day = 0; day < simulationLength - 1; ++day)
        {
            Console.WriteLine($"Day {day}");
            var newFishes = new List<Lanternfish>();

            Parallel.ForEach(fishes, fish =>
            {
                fish.Timer--;
                if(fish.Timer == 0)
                {
                    // reproduce
                    newFishes.Add(new (newBornTimer));
                    fish.Timer = restartTimer;
                }
            }
            );

            fishes.AddRange(newFishes);
        }

        Console.WriteLine(fishes.Count);
    }


    public override void Part2()
    {
        int restartTimer = 7 - 1;
        int newBornTimer = restartTimer + 2;
        
        long[] input = new long[newBornTimer + 1];

        foreach(var s in _input.Split(','))
        {
            input[long.Parse(s)]++;
        }

        int simulationLength = 256;

        for(int i = 0; i < simulationLength; ++i)
        {
            long dayZeroCount = input[0];

            // move to the next day
            for(int j = 1; j < input.Length; ++j)
            {
                input[j - 1] = input[j];
            }    

            input[restartTimer] = dayZeroCount + input[restartTimer];
            input[newBornTimer] = dayZeroCount;            

           // Console.WriteLine($"Day {i + 1}: {string.Join(',', input)}");
        }

        Console.WriteLine(input.Sum());
    }

    private class Lanternfish
    {
        public int Timer {get; set;}

        public Lanternfish(int timer)
        {
            Timer = timer;
        }
    }

    private List<Lanternfish> ParseInput(string input)
    {
        return input.Split(',').Select(x => new Lanternfish(int.Parse(x))).ToList();
    }

    private const string _exampleInput = @"3,4,3,1,2";
    private const string _input = @"4,3,3,5,4,1,2,1,3,1,1,1,1,1,2,4,1,3,3,1,1,1,1,2,3,1,1,1,4,1,1,2,1,2,2,1,1,1,1,1,5,1,1,2,1,1,1,1,1,1,1,1,1,3,1,1,1,1,1,1,1,1,5,1,4,2,1,1,2,1,3,1,1,2,2,1,1,1,1,1,1,1,1,1,1,4,1,3,2,2,3,1,1,1,4,1,1,1,1,5,1,1,1,5,1,1,3,1,1,2,4,1,1,3,2,4,1,1,1,1,1,5,5,1,1,1,1,1,1,4,1,1,1,3,2,1,1,5,1,1,1,1,1,1,1,5,4,1,5,1,3,4,1,1,1,1,2,1,2,1,1,1,2,2,1,2,3,5,1,1,1,1,3,5,1,1,1,2,1,1,4,1,1,5,1,4,1,2,1,3,1,5,1,4,3,1,3,2,1,1,1,2,2,1,1,1,1,4,5,1,1,1,1,1,3,1,3,4,1,1,4,1,1,3,1,3,1,1,4,5,4,3,2,5,1,1,1,1,1,1,2,1,5,2,5,3,1,1,1,1,1,3,1,1,1,1,5,1,2,1,2,1,1,1,1,2,1,1,1,1,1,1,1,3,3,1,1,5,1,3,5,5,1,1,1,2,1,2,1,5,1,1,1,1,2,1,1,1,2,1";
}