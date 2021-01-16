using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : ControllerBaseMy
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [Authorize]
        [HttpGet("{idd}")]
        public async Task<ActionResult<AppUser>> GetUser(int idd)
        {
            return await _context.Users.FindAsync(idd);

        }
    }
}