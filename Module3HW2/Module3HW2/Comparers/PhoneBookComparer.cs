using System.Collections.Generic;

namespace Module3HW2.Comparers
{
    public class PhoneBookComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == "#" || y == "#" || x == "0-9" || y == "0-9")
            {
                return y.CompareTo(x);
            }

            return x.CompareTo(y);
        }
    }
}