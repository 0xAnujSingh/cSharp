using mvc_practice.Models;

namespace mvc_practice.Interface
{
    public interface IEmployeeInterface
    {
        public List<EmployeeClass> Get();

        public EmployeeClass GetById(string LoginName);

        public void Insert(EmployeeClass employee);
        public void Update(EmployeeClass employee);
        public void Delete(string LoginName);
    }
}
