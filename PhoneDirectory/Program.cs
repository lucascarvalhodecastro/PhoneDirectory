using PhoneDirectory.Models;

namespace PhoneDirectory
{
    public class Program
    {
        static void Main()
        {
            PhoneBookUtils utils = new PhoneBookUtils();

            PhoneBookEntry pbe1 = new PhoneBookEntry() { Number = "085-123456", Name = "Jemmy Ned", Address = "House 1" };
            PhoneBookEntry pbe2 = new PhoneBookEntry() { Number = "086-654321", Name = "Billy Ned", Address = "House 2" };
            PhoneBookEntry pbe3 = new PhoneBookEntry() { Number = "087-789456", Name = "John McBurty", Address = "House 3" };
            PhoneBookEntry pbe4 = new PhoneBookEntry() { Number = "088-654789", Name = "Holly Hunter", Address = "House 4" };
            PhoneBookEntry pbe5 = new PhoneBookEntry() { Number = "089-987321", Name = "Mary Maleady", Address = "House 5" };
            PhoneBookEntry pbe6 = new PhoneBookEntry() { Number = "081-112233", Name = "Dermot Boyle", Address = "House 6" };

            /*
            utils.CreateNewPBE(pbe1);
            utils.CreateNewPBE(pbe2);
            utils.CreateNewPBE(pbe3);
            utils.CreateNewPBE(pbe4);
            utils.CreateNewPBE(pbe5);
            utils.CreateNewPBE(pbe6);
            */

            utils.ReadAllPBE();
            Console.WriteLine("--------------------");

            pbe1.Address = "More Upmarket House 2";
            utils.UpdatePBE(pbe1);

            utils.ReadAllPBE();
            Console.WriteLine("--------------------");

            utils.DeletePBE(pbe6);

            utils.ReadAllPBE();
            Console.WriteLine("--------------------");

            // The actual lab requirements

            List<PhoneBookEntry> recordsByName = utils.ctx.Directory.OrderBy(p => p.Name).ToList();
            foreach (PhoneBookEntry record in recordsByName)
            {
                Console.WriteLine(record);
            }

            Console.WriteLine("**********************************");

            PhoneBookEntry found = utils.ctx.Directory.FirstOrDefault(p => p.Number.Equals("087-789456"));
            if (found != null)
            {
                Console.WriteLine($"That phone number belongs to: {found.Name}");
            }

            Console.WriteLine("**********Number and Address*************");

            var records = utils.ctx.Directory.Where(p => p.Name.Equals("Jemmy Ned")).Select(p => new {p.Number, p.Address});  
            foreach (var record in records)
            {
                Console.WriteLine($"Number: {record.Number} | Address: {record.Address}");
            }
        }
    }
}