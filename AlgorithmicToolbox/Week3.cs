namespace AlgorithmicToolbox
{
    class Week3
    {
        public static int ChangingMoney(int m)
        {
            int[] nominals = new[] { 10, 5, 1 };
            int result = 0;

            foreach (var nominal in nominals)
            {
                result += m / nominal;
                m %= nominal;
            }

            return result;
        }
    }
}
