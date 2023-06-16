using ContactAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiContactController : ControllerBase
    {
        private ContactDbApiContext _context;
        public ApiContactController(ContactDbApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<ContactListTable> GetContactLists()
        {
            List<ContactListTable> list = _context.ContactListTables.ToList();
            return list;
        }
    }
}
