using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

     class Goals 
    {
        private List<string> _goals = new List<string> ();

        public int Count => _goals.Count;
         
        public virtual void Add(string  Goal)
        {
            _goals.Add(Goal);
        }

        public virtual string Get(int Number)
        {

            return _goals.Count == 0 || _goals.Count < Number ? "Empty" : _goals[Number];
        }
    }
    
    class GoalsWriter
    {
        private List<Goals> _goals;
        public GoalsWriter(List<Goals> Goals)
        {
            _goals = Goals;
        }
        public void  GoalsWrite()
        {
            int max = Math.Max(_goals[0].Count, Math.Max(_goals[1].Count, _goals[2].Count));
            int i = 0;
            do
            {
                Console.WriteLine(_goals[0].Get(i) + " | " + _goals[1].Get(i) + " | " + _goals[2].Get(i));
                i++;
            } while (i < max);

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Goals goalsIndividual = new Goals();
            Goals goalsWork = new Goals();
            Goals goalsFamilly = new Goals();
            GoalsWriter writer = new GoalsWriter(new List<Goals> { goalsIndividual, goalsWork, goalsFamilly });
            Dictionary<string, Goals> states = new Dictionary<string, Goals> {
                { "рабочий", goalsWork },
                { "личный", goalsIndividual},
                { "семейный", goalsWork }

            };

            while (true)
            {
                Console.Clear();
                writer.GoalsWrite();

                Console.WriteLine("Куда вы хотите добавить цель?");
                string listName = Console.ReadLine().ToLower();

                Console.WriteLine("Что это за цель?");
                string goal = Console.ReadLine();


                if (states.ContainsKey(listName))
                    states[listName].Add(goal);
                


            }
        }
    }
}
