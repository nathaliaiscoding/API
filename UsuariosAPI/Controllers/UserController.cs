using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsuariosAPI.Models;
using UsuariosAPI.Service;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll() =>
        EditUsers.GetAll();

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = EditUsers.Get(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            EditUsers.Add(user);
            return CreatedAtAction(nameof(Create), new { id = user.UserId }, user);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest();

            var existingUser = EditUsers.Get(id);
            if (existingUser is null)
                return NotFound();

            EditUsers.Update(user);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = EditUsers.Get(id);

            if (user is null)
                return NotFound();

            EditUsers.Delete(id);
            return NoContent();
        }

    }

}
