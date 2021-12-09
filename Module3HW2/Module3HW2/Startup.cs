using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Module3HW2.Collections;
using Module3HW2.Collections.Abstractions;
using Module3HW2.Models;
using Module3HW2.Services;
using Module3HW2.Services.Abstractions;

namespace Module3HW2
{
    public class Startup
    {
        private readonly ICustomList<string, Contact> _phoneBook;

        public Startup(ICustomList<string, Contact> phoneBook)
        {
            _phoneBook = phoneBook;
        }

        public void Run()
        {
            _phoneBook.AddContact(new Contact() { FirstName = "Andrew", LastName = "Kara", PhoneNumber = "12344534563" });
            _phoneBook.AddContact(new Contact() { FirstName = "Sawa", LastName = "Sharyi", PhoneNumber = "32141241241" });
            _phoneBook.AddContact(new Contact() { FirstName = "Kolya", LastName = "Olizarenko", PhoneNumber = "5435363463" });
            _phoneBook.AddContact(new Contact() { FirstName = "Лера", LastName = "Сороколетова", PhoneNumber = "7657658568" });
            _phoneBook.AddContact(new Contact() { FirstName = "Саша", LastName = "Рогач", PhoneNumber = "876876967967" });
            _phoneBook.AddContact(new Contact() { FirstName = "Андрюша", LastName = "Кара", PhoneNumber = "12344534563" });
            _phoneBook.AddContact(new Contact() { FirstName = ":абобус", LastName = "Каво", PhoneNumber = "12344534563" });
            _phoneBook.AddContact(new Contact() { FirstName = "123124", LastName = "3242323", PhoneNumber = "12344534563" });
            _phoneBook.AddContact(new Contact() { FirstName = "?*:?:(*:?", LastName = "(*?(*)?", PhoneNumber = "12344534563" });
            _phoneBook.AddContact(new Contact() { FirstName = "(?*:(*?", LastName = "*(?)?)(*", PhoneNumber = "12344534563" });

            _phoneBook.WriteContacts();
        }
    }
}