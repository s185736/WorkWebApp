using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserDataContext _context;

        public ShiftViewModel? ShiftViewModel { get; set; }
        public AdminController(UserDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Employees()
        {
            var employees = await _context._user.ToListAsync().ConfigureAwait(false);
            return View(employees);
        }

        public async Task<IActionResult> DeleteUser(int? record_id)
        {
            
            if (record_id != null)
            {
                var user = await _context._user.FirstOrDefaultAsync(m => m.record_id == record_id).ConfigureAwait(false);
                return user == null ? NotFound() : View(user);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int record_id)
        {
            var user = await _context._user.FindAsync(record_id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            var shifts = await _context._shift.Where(s => s.userid == record_id).ToListAsync().ConfigureAwait(false);
            if (shifts != null && shifts.Any())
            {
                _context._shift.RemoveRange(shifts);
            }
    
            _context._user.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Employees));
        }
        public async Task<IActionResult> ChangePassword()
        {
            return Redirect("/change-password");
        }
        
        public async Task<IActionResult> EditUser(int? record_id)
        {
            ViewBag.EditAbleTrue = true;
            var user = await _context._user.FindAsync(record_id).ConfigureAwait(false);
            return user == null ? NotFound() : View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int record_id, [Bind("record_id,firstname,lastname,mail,phonenumber,birthday,role,department")]
            _user userData)
        {
            var updateUser = await _context._user.FindAsync(record_id);
            if (updateUser == null)
            {
                return NotFound();
            }
        
            // updating shift
            var updateShift = await _context._shift.Where(s => s.userid == updateUser.record_id).ToListAsync();
            if (updateShift.Any())
            {
                foreach (var shift in updateShift)
                {
                    shift.userid = shift.userid;
                    shift.start_time = shift.start_time;
                    shift.end_time = shift.end_time;
                    shift.checked_in_time = shift.checked_in_time;
                    shift.checked_out_time = shift.checked_out_time;
                    shift.break_duration = shift.break_duration;
                    shift.dateofshift = shift.dateofshift;
                }
                _context._shift.UpdateRange(updateShift);
            }
        
            //Updating user
            updateUser.firstname = userData.firstname;
            updateUser.lastname = userData.lastname;
            updateUser.mail = userData.mail;
            updateUser.phonenumber = userData.phonenumber;
            updateUser.birthday = userData.birthday;
            updateUser.role = userData.role;
            updateUser.department = userData.department;
            _context._user.Update(updateUser);
        
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(Employees));
        }



        public async Task<IActionResult> InfoUser(int? record_id)
        {
            if (record_id != null)
            {
                var user = await _context._user.FirstOrDefaultAsync(m => m.record_id == record_id).ConfigureAwait(false);
                return user == null ? NotFound() : View(user);
            }

            return NotFound();
        }
    }
}
