using System;
using Microsoft.Extensions.DependencyInjection;
using Module3HW2.Collections;
using Module3HW2.Collections.Abstractions;
using Module3HW2.Models;
using Module3HW2.Services;
using Module3HW2.Services.Abstractions;

namespace Module3HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICustomList<string, Contact>, CustomList<string, Contact>>()
                .AddTransient<IWriterService<string, Contact>, WriterService<string, Contact>>()
                .AddTransient<IGroupContactsService<Contact>, GroupContactsService<Contact>>()
                .AddTransient<Startup>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Startup>();
            start?.Run();
        }
    }
}