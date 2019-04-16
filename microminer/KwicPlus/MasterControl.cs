using System.Collections.Generic;


namespace microminer.KwicPlus
{
    public class MasterControl
    {
        private readonly CircularShift circularShifter;
        private readonly Alphabetizer alphabetizer;
        private readonly OutputMedium outputManager;
        private readonly InputMedium inputManager;

        private char[] input;
        private char[] links;
        private List<Pair> circularShiftIndices;
        private List<Pair> alphabetizedIndices;
        private int[] linkindices;

        public MasterControl()
        {
            circularShifter = new CircularShift();
            alphabetizer = new Alphabetizer();
            inputManager = new InputMedium();
            outputManager = new OutputMedium();
        }

        public void SetInput(string input)
        {
            var inputs = inputManager.GetFormattedWords(input);

            this.input = inputs[0];
            this.links = inputs[1];
            this.linkindices = GetUrlIndices();

            outputManager.SetInputs(this.input, links, linkindices);

            GenerateResults();
        }

        private void GenerateResults()
        {
            circularShiftIndices = circularShifter.circularShift(this.input);
            alphabetizedIndices = alphabetizer.alphabetize( circularShiftIndices, this.input);
        }

        public string GetAlphabetized()
        {
            return outputManager.getString(alphabetizedIndices);
        }

        public List<string> GetAlphabetizedAsList()
        {
            return outputManager.getList(alphabetizedIndices);
        }

        public string GetCircularlyShifted()
        {
            return outputManager.getString(circularShiftIndices);
        }

        public List<string> GetCircularlyShiftedAsList()
        {
            return outputManager.getList(circularShiftIndices);
        }

        private int[] GetUrlIndices()
        {
            var urlIndices = new List<int>();
            int startIndex = 0;
            for (int i = 0; i < this.links.Length; i++)
            {
                if (this.links[i] == '\n')
                {
                    urlIndices.Add(startIndex);
                    i++;
                    startIndex = i;
                }
            }
            
            urlIndices.Add(startIndex);

            return urlIndices.ToArray();
        }

    }
}
