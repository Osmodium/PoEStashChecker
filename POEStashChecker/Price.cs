namespace POEStashChecker
{
    public struct Price
    {
        public double ChaosOrb;
        public double ExaltedOrb;

        public Price(double chaosOrb, double exaltedOrb)
        {
            ChaosOrb = chaosOrb;
            ExaltedOrb = exaltedOrb;
        }

        public override string ToString()
        {
            return $"C:{ChaosOrb},E:{ExaltedOrb}";
        }
    }
}
