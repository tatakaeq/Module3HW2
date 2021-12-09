using System.Collections.Generic;

namespace Module3HW2.Services.Abstractions
{
    public interface IWriterService<TKey, TValue>
    {
        void WriteContactList(SortedList<TKey, List<TValue>> sortedСontacts);
    }
}