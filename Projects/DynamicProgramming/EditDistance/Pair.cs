namespace DynamicProgramming
{
    public struct Pair
    {
        private int i;
        private int j;

        public Pair(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public override int GetHashCode()
        {
            return (i << 16) ^ j;
        }
    }
}
