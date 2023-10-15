using System.Threading.Tasks;

namespace _01._Apocalypse_Preparation
{
    public class Program
    {
        static void Main()
        {
            int[] textileInput = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            Queue<int> textiles = new Queue<int>(textileInput);
            int[] medInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> medicaments = new Stack<int>(medInput);
            Dictionary<string, int> createdMeds = new Dictionary<string, int>
            {
                { "Patch", 0 },
                { "Bandage", 0 },
                { "MedKit", 0}
            };
            while (textiles.Count > 0 && medicaments.Count >0)
            {
                int points = textiles.Peek() + medicaments.Peek();

                if (points == 30)
                {
                    createdMeds["Patch"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (points == 40)
                {
                    createdMeds["Bandage"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (points >= 100)
                {
                    createdMeds["MedKit"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (points - 100 > 0)
                    {
                        points -= 100;
                        int tempValue = medicaments.Pop() + points;
                        medicaments.Push(tempValue);
                    }
                }
                else
                {
                    textiles.Dequeue();
                    int tempValue = medicaments.Pop() + 10;
                    medicaments.Push(tempValue);
                }
            }
            if (!medicaments.Any() && !textiles.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!medicaments.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            foreach (var med in createdMeds.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (med.Value > 0)
                {
                    Console.WriteLine($"{med.Key} - {med.Value}");
                }
            }
            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}