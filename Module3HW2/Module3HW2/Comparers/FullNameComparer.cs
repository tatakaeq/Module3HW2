using System.Collections;
using System.Collections.Generic;
using Module3HW2.Models;

namespace Module3HW2.Comparers
{
    public class FullNameComparer : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            return x.FullName.CompareTo(y.FullName);
        }
    }
}