using System.Collections.Generic;
using System.Linq;

namespace microminer.KwicPlus
{
    public class Alphabetizer
    {
        public List<Pair> alphabetize(List<Pair> shiftedInput, char[] charInput)
        {
            return shiftedInput.OrderBy(s => s, new KwicComparer(charInput)).ToList();
        }
    }
}
