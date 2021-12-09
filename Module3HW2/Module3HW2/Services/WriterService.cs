using System;
using System.Collections.Generic;
using Module3HW2.Models;
using Module3HW2.Services.Abstractions;

namespace Module3HW2.Services
{
    public class WriterService<TKey, TValue> : IWriterService<TKey, TValue>
    {
        public void WriteContactList(SortedList<TKey, List<TValue>> sortedСontacts)
        {
            var list = sortedСontacts as SortedList<string, List<Contact>>;
            foreach (var item in list)
            {
                if (item.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"{item.Key}:");
                foreach (var contact in item.Value)
                {
                    Console.WriteLine($"{contact.FullName} {contact.PhoneNumber}");
                }
            }
        }
    }
}