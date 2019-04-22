using System.Collections.Generic;


namespace microminer.KwicPlus
{
    public class MasterControl
    {


        private char[] input;
        private char[] links;
        private List<Pair> circularShiftIndices;
        private List<Pair> alphabetizedIndices;
        private int[] linkindices;


        private  CircularShift circularShifter;
        private  Alphabetizer alphabetizer;
        private  OutputMedium outputManager;
        private  InputMedium inputManager;

        public MasterControl()
        {
            circularShifter = new CircularShift();
            alphabetizer = new Alphabetizer();
            inputManager = new InputMedium();
            outputManager = new OutputMedium();
        }

        public void Initialize(string input)
        {
            var inputs = inputManager.GetFormattedWords(input);

            this.input = inputs[0];
            this.links = inputs[1];
            this.linkindices = UrlIndices;

            outputManager.SetInputs(this.input, links, linkindices);

            GenerateResults();
        }

        private void GenerateResults()
        {
            circularShiftIndices = circularShifter.circularShift(this.input);
            alphabetizedIndices = alphabetizer.alphabetize( circularShiftIndices, this.input);
        }

        public string Alphabetized => outputManager.getString(alphabetizedIndices);

        public List<string> AlphabetizedAsList => outputManager.getList(alphabetizedIndices);

        public string CircularlyShifted => outputManager.getString(circularShiftIndices);

        public List<string> CircularlyShiftedAsList => outputManager.getList(circularShiftIndices);

        private int[] UrlIndices
        {
            get
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
}
