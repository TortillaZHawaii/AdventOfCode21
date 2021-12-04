namespace AdventOfCode21;

public class Day01 : DayX
{
    public override void Part1()
    {
        var rawMeasurements = @"199
200
208
210
200
207
240
269
260
263";
        var measurements = rawMeasurements.Split(Environment.NewLine).Select(x => int.Parse(x)).ToList();
        
        // larger measurements
        int answer = 0;
        for (int i = 1; i < measurements.Count; ++i)
        {
            int prev = measurements[i - 1];
            int current = measurements[i];

            bool isLarger = current > prev;

            if(isLarger)
            {
                ++answer;
            }
        }

        Console.WriteLine(answer);
    }

    public override void Part2()
    {
        var rawMeasurements = @"199
200
208
210
200
207
240
269
260
263";
        var measurements = rawMeasurements.Split(Environment.NewLine).Select(x => int.Parse(x)).ToList();
        
        // larger measurements

        /*
        note we only need to check first A and last B to see if they are larger
        the rest of the measurements are the same
        199  A      
        200  A B    
        208  A B C  
        210    B C D
        */
        int answer = 0;
        int windowSize = 3;

        for (int i = windowSize; i < measurements.Count; ++i)
        {
            int prev = measurements[i - windowSize];
            int current = measurements[i];

            bool isLarger = current > prev;

            if(isLarger)
            {
                ++answer;
            }
        }

        Console.WriteLine(answer);
    }
}