namespace MVCImplementation
{
    public static class IsPropertyEqualChecher
    {
        public static bool isPropertyEqualCheck (string firstProperty, string secondProperty)
        {
            return firstProperty == secondProperty ?  true : false;
        }
        public static bool isPropertyEqualCheck(int firstProperty, int secondProperty)
        {
            return firstProperty == secondProperty ? true : false;
        }
    }
}
