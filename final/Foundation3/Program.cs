using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "90210");
        Address address2 = new Address("456 Sunset Blvd", "Sunville", "TX", "75001");
        Address address3 = new Address("789 Maple Ave", "Greenwood", "NY", "10001");

        Event lecture = new Lecture("C# Fundamentals", "Learn the basics of C#", "2025-04-10", "10:00 AM", address1, "Jane Doe", 50);
        Event reception = new Reception("Tech Mixer", "A night to network with tech professionals", "2025-04-11", "6:30 PM", address2, "rsvp@techmixer.com");
        Event outdoor = new OutdoorGathering("Park Picnic", "Community picnic with games and food", "2025-04-12", "12:00 PM", address3, "Sunny with mild breeze");

        List<Event> events = new List<Event> { lecture, reception, outdoor };

        foreach (Event ev in events)
        {
            Console.WriteLine("=== Standard Details ===");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine("\n=== Full Details ===");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine("\n=== Short Description ===");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine("\n--------------------------\n");
        }
    }
}
