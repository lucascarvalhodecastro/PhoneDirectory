using PhoneDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    public class PhoneBookUtils
    {
        public PhoneBookContext ctx;

        public PhoneBookUtils()
        {
            ctx = new PhoneBookContext();
            ctx.Database.EnsureCreated();
        }

        public void CreateNewPBE(PhoneBookEntry pbe)
        {
            ctx.Directory.Add(pbe);
            ctx.SaveChanges();
        }

        public void UpdatePBE(PhoneBookEntry pbe)
        {
            PhoneBookEntry found = ctx.Directory.Find(pbe.Number);
            if (found != null)
            {
                found.Address = pbe.Address;
                found.Name = pbe.Name;
                ctx.Update(found);
                ctx.SaveChanges();
            }
        }

        public void DeletePBE(PhoneBookEntry pbe)
        {
            PhoneBookEntry found = ctx.Directory.Find(pbe.Number);
            if (found != null)
            {
                ctx.Directory.Remove(found);
                ctx.SaveChanges();
            }
        }

        public void ReadAllPBE()
        {
            foreach (PhoneBookEntry pbe in ctx.Directory)
            {
                Console.WriteLine(pbe);
            }
        }
    }
}
