    internal class Program
    {
        public static void Main(string[] args)
        {
            //petshop1 only wants dogs with 4 legs
            var petShop1 = new PetShop
            {
                Name = "4-legged dogland",
                ShouldLetPetIn = dog => dog.NumberOfPaws == 4
            };

            //petshop2 only wants dogs that are shibas
            var petShop2 = new PetShop
            {
                Name = "Vincenzo's Shibaland",
                ShouldLetPetIn = dog => dog.IsShiba
            };

            var petShop3 = new PetShop
            {
                Name = "Kristen's 1-legged Shibaland",
                ShouldLetPetIn = dog => dog.IsShiba && dog.NumberOfPaws == 1
            };

            var pupper = new Dog { Name = "pupper", IsShiba = false, NumberOfPaws = 4 };
            var doge = new Dog { Name = "Doge", IsShiba = true, NumberOfPaws = 3 };


            WriteLog(petShop1, pupper, doge);
            WriteLog(petShop2, pupper, doge);
            WriteLog(petShop3, pupper, doge);
            
            Console.ReadKey();
        }

        public static void WriteLog(PetShop petShop, Dog dog1, Dog dog2)
        {
            Console.WriteLine(petShop.Name);
            Console.WriteLine($"Should let in {dog1.Name}?");
            Console.WriteLine(petShop.ShouldLetPetIn(dog1));
            Console.WriteLine($"Should let in {dog2.Name}?");
            Console.WriteLine(petShop.ShouldLetPetIn(dog2));
        }
    }


    public class PetShop
    {
        public string Name { get; set; }
        //Given a dog, what about the dog should let the pet in?
        public Func<Dog, bool> ShouldLetPetIn { get; set; }
    }

    public class Dog
    {
        public string Name { get; set; }
        public int NumberOfPaws { get; set; }
        public bool IsShiba { get; set; }
    }
