// records can be struct now after compilation
public readonly record struct DailyTemperature(double HighTemp, double LowTemp);
public record class DailyTemp(double HighTemp, double LowTemp);

class Program
{
    public static void Main(string[] args)
    {
        //DateOnly and TimeOnly
        DateOnly date = new DateOnly(2021, 5, 5);
        TimeOnly time = new TimeOnly(9, 5);
        // ^ is not supported by jsonserializer, no DateOnly.Now, TimeOnly.Now :(
        
        // global usings file

        //Priority queue type
        var queue = new PriorityQueue<string, int>();
        queue.Enqueue("Item A", 0);
        queue.Enqueue("Item B", 60);
        queue.Enqueue("Item C", 2);
        queue.Enqueue("Item D", 1);
        queue.Enqueue("Item aa", -100);
        
        while (queue.TryDequeue(out string item, out int priority))
        {
            Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
        }
    }
}

