using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeProfileAPI.Models;
using EmployeeProfileAPI.Data;

namespace EmployeeProfileAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly ApiContext _context;

        public EmployeeProfileController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(EmployeeProfile profile)
        {
            if (profile.Id == 0)
            {
                _context.Profiles.Add(profile);
            }
            else
            {
                var profileInDb = _context.Profiles.Find(profile.Id);

                if (profileInDb == null)
                    return new JsonResult(NotFound());

                profileInDb = profile;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(profile));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Profiles.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Profiles.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Profiles.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get All
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Profiles.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
