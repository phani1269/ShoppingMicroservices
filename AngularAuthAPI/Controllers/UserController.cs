using AngularAuthAPI.Context;
using AngularAuthAPI.Helpers;
using AngularAuthAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [Route("[action]")]
        [HttpPost]
        //   [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            

          //  var Stringpass = PasswordHasher.VerifyPassword(userObj.Password, )

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password==userObj.Password);

            if (user == null)
            {
                return NotFound(new { Message= "User Not Found!"});
            }

            return Ok(new { 
                Message = "Login Success!"
            });

        }

        // [HttpPost("Register")]
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj==null)
            {
                return BadRequest();
            }

            //check username

            if (await CheckUsernameExist(userObj.UserName))
            {
                return BadRequest(new { Message = "Username Already Exists !!"});
            }


            //check email
            if (await CheckEmailExist(userObj.Email))
            {
                return BadRequest(new { Message = "Email Already Exists !!" });
            }

            //check password strength
            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
            {
                return BadRequest(new { Message = pass.ToString() });

            }

            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";

            await _context.Users.AddAsync(userObj);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = " User Registered!"
            });
        }


        private async Task<bool> CheckUsernameExist(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName);
        }
        private async Task<bool> CheckEmailExist(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8 )
            {
                sb.Append("Minimum password lengthshould be 8 " + Environment.NewLine);
            }

            if (!(Regex.IsMatch(password, "[a-z]")&& Regex.IsMatch(password,"[A-Z]")
                && Regex.IsMatch(password,"[0-9]")))
            {
                sb.Append("Password should be alphanumeric" + Environment.NewLine);
            }

            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,-,/,.,?,=,`,~]"))
            {
                sb.Append("Password should contain special character" + Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
