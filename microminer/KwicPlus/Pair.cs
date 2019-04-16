namespace microminer.KwicPlus
{
    public class Pair
    {

        private int first;
        private int offset;
        private int line;

        public Pair(int first, int offset, int line)
        {
            this.first = first;
            this.offset = offset;
            this.line = line;
        }

        public int getOffset()
        {
            return offset ;
        }

        public int getFirst()
        {
            return first;
        }

        public int getLine()
        {
            return line;
        }
    }
}
