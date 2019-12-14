using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day14
{
    public class Chemical
    {
        private string element;
        public string Element => element;

        private int defaultQuantity;

        private int availableAmount;
        public int AvailableAmount => availableAmount;
        private int requestedAmount;

        private Dictionary<Chemical, int> requirements;

        public Chemical(string element)
        {
            requirements = new Dictionary<Chemical, int>();
            this.element = element;
        }

        public void SetDefaultQuantity(int quantity)
        {
            defaultQuantity = quantity;
        }

        public void AddRequirement(Chemical chemical, int amount)
        {
            if (requirements.ContainsKey(chemical))
                requirements[chemical] += amount;
            else
                requirements.Add(chemical, amount);
        }

        public void Produce(int amount)
        {
            requestedAmount += amount;

            if(availableAmount >= requestedAmount)
                return;

            if(requirements.Keys.Count == 0)
            {
                availableAmount = requestedAmount;
                return;
            }

            while(availableAmount < requestedAmount)
            {
                foreach(var pair in requirements)
                    pair.Key.Produce(pair.Value);

                availableAmount += defaultQuantity;
            }
        }

        public string GetDebugInfo()
        {
            string info = defaultQuantity + " " + element + " requires: ";

            foreach(Chemical chemical in requirements.Keys)
                info += chemical.Element + " " + requirements[chemical] +", ";

            return info;
        }

        public override int GetHashCode()
        {
            return element.GetHashCode();
        }
    }
}

