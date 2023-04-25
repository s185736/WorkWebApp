using Microsoft.AspNetCore.Mvc;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUser user ;
 
        public AdminController(IUser user)
        {
            this.user = user;
        }
 
        public IActionResult Index()
        {
            try
            {
                var result = user.GetEmployee().Result;
                ViewBag.Employee = result;
                //return View();
                Response.Redirect(Request.Path);
                return new RedirectResult("/Employees", permanent: true, preserveMethod: true);
            }
            catch (Exception)
            {
                throw;
            }
            //return View();
            return new RedirectResult("/Employees", permanent: true, preserveMethod: true);
        }

        public IActionResult Edit(int record_id)
        {
            UserViewModel userView = new UserViewModel()
            {
                viewUser = user.GetEmployeeById(record_id)
            }; 
            return View(userView);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel viewUser)
        {
            _user userModel = new _user()
            {
                record_id=viewUser.record_id,
                firstname = viewUser.firstname,
                lastname = viewUser.lastname,
                mail = viewUser.mail,
                phonenumber= viewUser.phonenumber,
                birthday= viewUser.birthday,
                role= viewUser.role,
                department= viewUser.department,
                password= viewUser.password
                
            };
            var result = user.UpdateEmployee(userModel);
            ModelState.Clear();
            Response.Redirect(Request.Path);
            return View();
            //return new RedirectResult("/Employees", permanent: true, preserveMethod: true);
        }
 
        public IActionResult Delete(int record_id)
        {
            UserViewModel userView = new UserViewModel()
            {
                viewUser = user.GetEmployeeById(record_id)
            };
            return View(userView);
        }
 
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(UserViewModel viewModel)
        {
            var result = user.DeleteEmployee(viewModel.record_id);
             
            return RedirectToAction(nameof(Index));
        }

    }
}