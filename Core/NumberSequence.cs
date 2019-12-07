namespace AdventOfCode2019.Core
{
    public class NumberSequence
    {
        private int maxValue;
        private int[] sequence;
        private int numberIndex;
        private int[] multiplyMapping = {1000000000,100000000,10000000,1000000,100000,10000,1000,100,10,1};

        public NumberSequence(int numbers, int maxValue)
        {
            sequence = new int[numbers];
            this.maxValue = maxValue;
            numberIndex = numbers-1;

            if(numbers > multiplyMapping.Length)
                throw new System.Exception("Sequence uses too many numbers!");
        }

        public void SetValue(int index, int value)
        {
            sequence[index] = value;
        }

        public bool Increase()
        {
            sequence[numberIndex]++;
            if (sequence[numberIndex] == maxValue+1)
            {
                for (int i=numberIndex; i<sequence.Length; i++)
                    sequence[i] = 0;

                int index = numberIndex - 1;
                while (index >= 0)
                {
                    sequence[index]++;

                    if (sequence[index] == maxValue+1)
                    {
                        if(index == 0)
                            return false;

                        sequence[index] = 0;
                        index--;
                    }
                    else
                        break;
                }
                numberIndex = sequence.Length-1;
            }

            return true;
        }

        public bool IsUnique()
        {
            for(int i=0; i<sequence.Length; i++)
            {
                for(int j=0; j<sequence.Length; j++)
                {
                    if(i==j)
                        continue;

                    if(sequence[i] == sequence[j])
                        return false;
                }
            }

            return true;
        }

        public int[] GetSequence()
        {
            return sequence;
        }

        public int GetFullNumber()
        {
            int lengthDiff = multiplyMapping.Length - sequence.Length;
            int fullNumber = 0;
            for (int i=0; i<sequence.Length; i++)
                fullNumber += sequence[i] * multiplyMapping[i+lengthDiff];

            return fullNumber;
        }
    }
}