using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace microminer.KwicPlus
{
    public class OutputMedium
    {
        private char[] input;
        private char[] links;
        private int[] linkIndices;

        public void SetInputs(char[] input, char[] links, int[] linkIndices)
        {
            this.input = input;
            this.links = links;
            this.linkIndices = linkIndices;
        }

        public List<string> getList(List<Pair> indices)
        {
            var result = new List<string>();
            foreach (var index in indices)
            {
                result.Add(getUrlLine(index));
            }

            return result;
        }

        public string getString(List<Pair> indices)
        {
            var stringBuilder = new StringBuilder();
            foreach (var index in indices)
            {
                stringBuilder.Append(getUrlLine(index));
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private string getUrlLine(Pair index)
        {
            var stringBuilder = new StringBuilder();

            var first = index.getFirst();
            var offset = index.getOffset();
            var i = first + offset;
            var k = first;

            while (i != this.input.Length && this.input[i] != '\r' && this.input[i] != '\n')
            {
                stringBuilder.Append(this.input[i]);
                i++;
            }

            if (offset != 0)
            {
                stringBuilder.Append(' ');
            }

            while (k < first + offset - 1)
            {
                stringBuilder.Append(this.input[k]);
                k++;
            }

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(' ');

            var indexer = index.getLine();
            var matchingUrlIndex = this.linkIndices[indexer];

            for (int j = matchingUrlIndex; j < this.links.Length; j++)
            {

                if (this.links[j] == '\n')
                {
                    break;
                }

                urlBuilder.Append(this.links[j]);
            }

            stringBuilder.Append(urlBuilder);

            return stringBuilder.ToString();
        }
    }

}
