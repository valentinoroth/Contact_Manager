using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Addresse { get; set; }
        public string NPA { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

        public Contact(string name, string surname, string addresse, string NPA, string location, string email)
        {
            this.Surname = surname;
            this.Name = name;
            this.Addresse = addresse;
            this.NPA = NPA;
            this.Location = location;
            this.Email = email;
        }
        public Contact(string line)
        {
            FromTabString(line);
        }

        public string ToTabString()
        {
            return $"{Surname}\t{Name}\t{Addresse}\t{NPA}\t{Location}\t{Email}";
        }

        public void FromTabString(string tabString)
        {
            var fields = tabString.Split('\t');

            for(int i = 0; i < fields.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Surname = fields[i];
                        break;
                    case 1:
                        Name = fields[i];
                        break;
                    case 2:
                        Addresse = fields[i];
                        break;
                    case 3:
                        NPA = fields[i];
                        break;
                    case 4:
                        Location = fields[i];
                        break;
                    case 5:
                        Email = fields[i];
                        break;
                }
            }
        }
    }
}
