﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using FoodAPI.Auth;
using FoodAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FoodAPI.Controllers
{
    public class AuthControllercs
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            private readonly ILogger<AccountController> logger;
            private readonly SignInManager<Account> signInManager;
            private readonly UserManager<Account> userManager;
            private readonly IConfiguration config;

            public AccountController(ILogger<AccountController> logger,
                SignInManager<Account> signInManager,
                UserManager<Account> userManager,
                IConfiguration config)
            {
                this.logger = logger;
                this.signInManager = signInManager;
                this.userManager = userManager;
                this.config = config;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterAcc model)
            {
                if (ModelState.IsValid)
                {
                    var existingUser = await this.userManager.FindByEmailAsync(model.Email);
                    if (existingUser == null)
                    {
                        Account acc = new Account();
                        acc.Fullname = model.Fullname;
                        acc.Email = model.Email;
                        acc.PhoneNum = model.PhoneNum;
                        acc.Password = model.Password;
                        acc.Address = model.Address;
                        acc.Gender = model.Gender;

                        IdentityResult result = userManager.CreateAsync(acc, model.Password).Result;

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(acc, "Account");
                            return Created("", model);
                        }
                    }

                }

                return BadRequest();
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginAcc model)
            {
                if (ModelState.IsValid)
                {
                    var user = await this.userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var passwordCheck = await this.signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                        if (passwordCheck.Succeeded)
                        {
                            var claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Fullname)
                        };
                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Tokens:Key"]));
                            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                            var token = new JwtSecurityToken(
                                this.config["Tokens:Issuer"],
                                this.config["Tokens:Audience"],
                                claims,
                                expires: DateTime.UtcNow.AddHours(3),
                                signingCredentials: credentials
                                );

                            return Ok(new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                                expiration = token.ValidTo
                            });
                        }

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }

                return BadRequest();
            }
        }
    }
}
