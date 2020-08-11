using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class AddressBook
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public string Path { get; set; }

        public void Load(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Contacts.Add(new Contact(line));
                }
            }
        }

        public void Save(string fileName)
        {
            using (var sw = new StreamWriter(fileName))
            {
                foreach (Contact c in Contacts) {
                    sw.WriteLine(c.ToTabString());
                 }
            }
            
        }
    }
}
