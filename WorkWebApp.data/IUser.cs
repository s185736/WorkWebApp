namespace WorkWebApp.data

{
    public interface IUser
    {
        Task<int> UpdateEmployee(_user user);
        Task<int> DeleteEmployee(int? record_id);
        _user? GetEmployeeById(int record_id);
        Task<List<_user>> GetEmployee();            
 
    }
}