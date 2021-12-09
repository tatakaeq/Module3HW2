using System.Collections.Generic;
using Module3HW2.Collections.Abstractions;
using Module3HW2.Services.Abstractions;

namespace Module3HW2.Collections
{
    public class CustomList<TKey, TValue> : ICustomList<TKey, TValue>
    {
        private IGroupContactsService<TValue> _groupContactsService;
        private List<TValue> _contacts;
        private SortedList<TKey, List<TValue>> _sortedContactList;
        private IWriterService<TKey, TValue> _writerService;

        public CustomList(IGroupContactsService<TValue> groupContactsService, IWriterService<TKey, TValue> writerService)
        {
            _contacts = new List<TValue>();
            _groupContactsService = groupContactsService;
            _writerService = writerService;
            _sortedContactList = new SortedList<TKey, List<TValue>>();
        }

        public void AddContact(TValue contact)
        {
            _contacts.Add(contact);
        }

        public void RemoveContact(TValue contact)
        {
            _contacts.Remove(contact);
        }

        public void WriteContacts()
        {
            _groupContactsService.GroupByAlphabet(_contacts);
            _sortedContactList = _groupContactsService.GroupedContactList as SortedList<TKey, List<TValue>>;
            _writerService.WriteContactList(_sortedContactList);
        }
    }
}