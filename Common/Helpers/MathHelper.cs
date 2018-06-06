using System;

namespace Common.Helpers
{
    public class MathHelper
    {
        public static bool HasSameSign(decimal numero1, decimal numero2)
        {
            return Math.Sign(numero1) == Math.Sign(numero2);
        }
    }
}
