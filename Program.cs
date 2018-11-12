using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Her er der implementeret DI - Dependency Injection (Pattern) med property injection.
// Som tilfældet var med Dependency Injection (Pattern) med constructor injection, kan dette eksempel
// med Dependency Injection også udbygges, så der kan mikses klasser fra Business logik laget med 
// klasser fra Data Access laget på kryds og på tværs.

namespace Dependency_Injection4c_DI_Property_Injection
{
    public interface ICustomerDataAccess
    {
        string GetCustomerData(int id);
    }

    public class CustomerBusinessLogic
    {
        public CustomerBusinessLogic()
        {

        }

        public string ProcessCustomerData(int id)
        {
            return DataAccess.GetCustomerData(id);
        }

        public ICustomerDataAccess DataAccess {get; set;}
    }

    public class CustomerService
    {
        CustomerBusinessLogic _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic();
            _customerBL.DataAccess = new CustomerDataAccess();
        }

        public string GetCustomerName(int id)
        {
            return _customerBL.ProcessCustomerData(id);
        }
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public CustomerDataAccess()
        {
        }

        public string GetCustomerData(int id)
        {
            //get the customer name from the db in real application        
            return "Dummy Customer Name DI - Property Injection " + id.ToString();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService CustomerService_Object = new CustomerService();
            Console.WriteLine(CustomerService_Object.GetCustomerName(14));
            Console.ReadLine();
        }
    }
}
