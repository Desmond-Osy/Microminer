using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace microminer.KwicPlus
{
    public class CircularShift
    {
        private static String noiseString = "a an the and or of to be is in out by as at off";
        private string[] noiseWords = noiseString.Split(' ');
        char space = ' ', carriage_return = '\r', new_line = '\n';

        public List<Pair> circularShift(char[] input)
        {
            
            var offset = 0;
            var first = 0;
            List<Pair> offsets = new List<Pair>();
            var line = 0;
            

         
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == space)
                {
                    offsets.Add(new Pair(first, offset, line));
               
                    while (i < input.Length-1 && (input[i] == carriage_return || input[i] == space || input[i] == new_line))
                    {
                        i++;
                        if (i > 0 && input[i - 1] == carriage_return || input[i] == new_line)
                        {
                            first = i;
                            line++;
                        }
                    }

                    offset = i - first;
                }
         
                else if (input[i] == carriage_return || input[i] == new_line)
                {
                    offsets.Add(new Pair(first, offset, line));
                    while (i < input.Length-1 && (input[i] == carriage_return || input[i] == space || input[i] == new_line))
                    {
                        i++;
                    }

                    first = i;
                    line++;
                    offset = 0;
                }

            }

         
            offsets.Add(new Pair(first, offset, line));

          
            var noiseWordIndices = getNoiseIndices(offsets, input);
            offsets = offsets.Except(noiseWordIndices).ToList();

            return offsets;
        }

        private IEnumerable<Pair> getNoiseIndices(IEnumerable<Pair> circularlyShifted, char[] input)
        {
            var noiseWordLines = new List<Pair>();
            foreach (var index in circularlyShifted)
            {
                if (isNoiseWord(index, input))
                {
                    noiseWordLines.Add(index);
                }
            }

            return noiseWordLines;
        }

        private bool isNoiseWord(Pair index, char[] input)
        {
            var startingIndex = index.getOffset() + index.getFirst();
            var firstChar = input[startingIndex];

            if (firstChar == '\t' || firstChar == space || firstChar == new_line)
                return true;
            firstChar = char.ToLowerInvariant(firstChar);

     
            if (firstChar == 'a' || firstChar == 'i' || firstChar == 'o' || firstChar == 't' || firstChar == 'b')
            {
                var stringBuilder = new StringBuilder();
                int i = startingIndex;
                while (i < input.Length && !(input[i] == carriage_return || input[i] == space || input[i] == '\t'))
                {
                    stringBuilder.Append(char.ToLower(input[i]));
                    i++;

                    
                    if (stringBuilder.Length >= 4)
                    {
                        return false;
                    }
                }
                var possibleNoiseWord = stringBuilder.ToString();

                foreach (var noiseWord in noiseWords)
                {
                    if (possibleNoiseWord == noiseWord)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
