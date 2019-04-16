using System.Collections.Generic;

namespace microminer.KwicPlus
{
    public class KwicComparer : IComparer<Pair>
    {
        private char[] input;
        char space = ' ', carriage_return = '\r', new_line = '\n';

        public KwicComparer(char[] input)
        {
            this.input = input;
        }

        public int Compare(Pair a, Pair b)
        {
            var indexA = a.getFirst() + a.getOffset();
            var indexB = b.getFirst() + b.getOffset();

            var firstIteration = true;

            var indexAStart = indexA;
            var indexBStart = indexB;

            while (true)
            {
                while (this.input[indexA] == '\r' || this.input[indexA] == '\n' || this.input[indexA] == ' ')
                {
                    indexA = GoNextIndex(indexA, a);
                }
                while (this.input[indexB] == '\r' || this.input[indexB] == '\n' || this.input[indexB] == ' ')
                {
                    indexB = GoNextIndex(indexB, b);
                }

                if (!firstIteration && indexA == indexAStart && indexB == indexBStart)
                {
                    return 0;
                }

                if (this.input[indexA] == this.input[indexB])
                {
                    indexA = GoNextIndex(indexA, a);
                    indexB = GoNextIndex(indexB, b);
                }
                else
                {
                    int comparisonInteger = char.ToUpperInvariant(this.input[indexA]).CompareTo(char.ToUpperInvariant(this.input[indexB]));

                    if (char.ToUpperInvariant(this.input[indexA]) == char.ToUpperInvariant(this.input[indexB]))
                    {
                        comparisonInteger = this.input[indexA].CompareTo(this.input[indexB]);
                        return comparisonInteger * -1;
                    }

                    return comparisonInteger;
                }

                firstIteration = false;
            }
        }
        private int GoNextIndex(int currentIndex, Pair index)
        {
            var nextIndex = currentIndex + 1;

      
            if (nextIndex >= this.input.Length || this.input[nextIndex] == '\r' || this.input[nextIndex] == '\n')
            {
                return index.getFirst();
            }
            return nextIndex;
        }
    }
}
