using System.Collections.Generic;
using System.Globalization;
using Module3HW2.Models;

namespace Module3HW2.Services.Abstractions
{
    public interface IGroupContactsService<T>
    {
        CultureInfo CultureInfo { set; }
        SortedList<string, List<Contact>> GroupedContactList { get; }
        void GroupByAlphabet(List<T> values);
        void GroupByAlphabet(List<T> values, CultureInfo cultureInfo);
    }
}