using System.Collections.Generic;
using System.Globalization;
using Module3HW2.Comparers;
using Module3HW2.Models;
using Module3HW2.Services.Abstractions;

namespace Module3HW2.Services
{
    public class GroupContactsService<T> : IGroupContactsService<T>
    {
        private const string _digitGroup = "0-9";
        private const string _otherGroup = "#";
        private string _english;
        private string _russian;
        private CultureInfo _currentCulture;
        private List<string> _keys;
        private List<Contact> _values;
        private SortedList<string, List<Contact>> _contactList;

        public GroupContactsService()
        {
            _currentCulture = new CultureInfo("en-US");
        }

        public CultureInfo CultureInfo
        {
            set { _currentCulture = value; }
        }

        public SortedList<string, List<Contact>> GroupedContactList => _contactList;

        public void GroupByAlphabet(List<T> values)
        {
            ResetContactList();
            GroupByAlphabet(values, _currentCulture);
        }

        public void GroupByAlphabet(List<T> values, CultureInfo cultureInfo)
        {
            _values = values as List<Contact>;
            var language = ChooseAlphabet(cultureInfo);
            FillKeysList(language);
            FillContactList();
            GroupByFullName();
        }

        private string ChooseAlphabet(CultureInfo cultureInfo)
        {
            switch (cultureInfo.ToString())
            {
                case "ru-Ru":
                    if (string.IsNullOrEmpty(_russian))
                    {
                        _russian = CultureService.ChooseLanguage(new CultureInfo("ru-Ru"));
                    }

                    return _russian;
                default:
                    if (string.IsNullOrEmpty(_english))
                    {
                        _english = CultureService.ChooseLanguage(new CultureInfo("en-Us"));
                    }

                    return _english;
            }
        }

        private void GroupByFullName()
        {
            var comparer = new FullNameComparer();

            foreach (var item in _values)
            {
                var key = item.FullName[0].ToString().ToUpper();

                if (char.IsDigit(key, 0))
                {
                    AddContact(_digitGroup, item, comparer);
                }
                else if (!_contactList.ContainsKey(key))
                {
                    AddContact(_otherGroup, item, comparer);
                }
                else
                {
                    AddContact(key, item, comparer);
                }
            }
        }

        private void FillKeysList(string language)
        {
            foreach (var item in language)
            {
                _keys.Add(item.ToString());
            }

            _keys.Add(_digitGroup);
            _keys.Add(_otherGroup);
        }

        private void FillContactList()
        {
            foreach (var item in _keys)
            {
                _contactList.Add(item, new List<Contact>());
            }
        }

        private void AddContact(string key, Contact newContact, IComparer<Contact> comparer)
        {
            var value = _contactList[key];
            value.Add(newContact);
            value.Sort(comparer);
        }

        private void ResetContactList()
        {
            _keys = new List<string>();
            _contactList = new SortedList<string, List<Contact>>(new PhoneBookComparer());
        }
    }
}