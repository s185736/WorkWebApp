using Microsoft.EntityFrameworkCore;

namespace WorkWebApp.data;

    public class Userdetail : IUser
    {
        private readonly UserDataContext _context;
 
        public Userdetail(UserDataContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteEmployee(int? id)
        {
            int result = 0;
 
            if (id!=null)
            {
                var record_id = await _context._user.FirstOrDefaultAsync(Uid => Uid.record_id == id);
                if(record_id !=null)
                {
                    _context.Remove(_context._user.Single(Uid => Uid.record_id == id));
                    result = await _context.SaveChangesAsync();
                }
                return result;
             
            }
            return result;
        }
          
 
        public  async  Task<int> UpdateEmployee(_user user)
        {
            if (true)
            {
                _context._user.Update(user);
                await _context.SaveChangesAsync();
                return user.record_id;
            }
        }
 
        public async Task<List<_user>> GetEmployee()
        {
            return await _context._user.ToListAsync();
        }
 
        public _user? GetEmployeeById(int id)
        {
            return  _context._user.FirstOrDefault(Uid=>Uid.record_id==id);
        }        
    }