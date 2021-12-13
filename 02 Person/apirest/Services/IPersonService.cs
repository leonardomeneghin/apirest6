using apirest.Controllers.Model;

namespace apirest.Services
{
    public interface IPersonService
    {
        /*Aqui define-se todas as implementações do serviço que vamos oferecer.
         CREATE -> Método POST http e C(reate) de CRUD, para criar e persistir dados.
         FINDBYID or FINDALL -> Método GET http e R(read) de CRUD para obter os dados
         UPDATE -> Método PUT http e U(pdate) de CRUD, para atualizar um dado
         DELETE -> Método Delete http e D(elete) de CRUD, para remover um registro.*/

        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);



    }
}
