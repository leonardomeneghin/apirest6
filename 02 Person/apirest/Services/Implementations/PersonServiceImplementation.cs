using apirest.Controllers.Model;

namespace apirest.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        /*Nesta classe, iremos implementar e não apenas prever cada método. Assim, criaremos o que cada
         método pode fazer.
        */
        private int count=0;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++) 
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }

       

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Local - mg"
            };
        }

        public Person Update(Person person)
        {

            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro" +i,
                LastName = "Costa" + i,
                Address = "Local - mg" + i,
                Gender = "Gender" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
