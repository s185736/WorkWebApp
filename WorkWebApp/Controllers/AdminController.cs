using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;

namespace WorkWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserDataContext _context;

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
            _context._user.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Employees));
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
            bool doUserExist = false;

            _user? user = await _context._user.FindAsync(record_id);

            switch (user)
            {
                case null:
                    user = new Employee();
                    break;
                default:
                    doUserExist = true;
                    break;
            }

            if (!ModelState.IsValid) return View(userData);
            user.firstname = userData.firstname;
            user.lastname = userData.lastname;
            user.mail = userData.mail;
            user.phonenumber = userData.phonenumber;
            user.birthday = userData.birthday;
            user.role = userData.role;
            user.department = userData.department;

            switch (doUserExist)
            {
                case false:
                    _context.Add(user);
                    break;
                default:
                    _context.Update(user);
                    break;
            }

            if (await TryUpdateModelAsync(
                    user,
                    "USER", 
                    c => c.record_id, c => c.firstname, c => c.lastname,
                    c => c.mail, c => c.phonenumber, c => c.birthday,
                    c => c.role, c => c.department
                ))
            {
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Employees");
            }
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
