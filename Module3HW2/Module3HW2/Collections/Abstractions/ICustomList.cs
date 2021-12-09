namespace Module3HW2.Collections.Abstractions
{
    public interface ICustomList<TKey, TValue>
    {
        void AddContact(TValue contact);
        void RemoveContact(TValue contact);
        void WriteContacts();
    }
}