namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main()
        {
            int[] taskTime = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> time = new Queue<int>(taskTime);
            int[] tasksNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> tasks = new Stack<int>(tasksNumber);
            int darthVaderDucky = 0;
            int thorDucky = 0;
            int bigBlueRubberDucky = 0;
            int smallYellowRubberDucky = 0;
            
            while (time.Count > 0 || tasks.Count > 0)
            {
                bool isValid = true;
                int rewardPoints = time.Peek() * tasks.Peek();

                if (rewardPoints >= 0 && rewardPoints <= 60)
                {
                    darthVaderDucky++;
                }
                else if (rewardPoints > 60 && rewardPoints <= 120)
                {
                    thorDucky++;
                }
                else if (rewardPoints > 120 && rewardPoints <= 180)
                {
                    bigBlueRubberDucky++;
                }
                else if (rewardPoints > 180 && rewardPoints <= 240)
                {
                    smallYellowRubberDucky++;
                }
                else if (rewardPoints > 240)
                {
                    isValid = false;
                }
                if (isValid)
                {
                    tasks.Pop();
                    time.Dequeue();

                }
                else
                {
                    int tempValueTask = tasks.Pop() -2 ;
                    tasks.Push(tempValueTask);
                    int tempValueTime = time.Dequeue();
                    time.Enqueue(tempValueTime);
                }

            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded: ");
            Console.WriteLine($"Darth Vader Ducky: {darthVaderDucky}") ;
            Console.WriteLine($"Thor Ducky: {thorDucky}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberDucky}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberDucky}");
        }
    }
}