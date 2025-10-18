using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Utilities
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }
            if (!await _context.Categories.AnyAsync())
            {
                await _context.Categories.AddRangeAsync(
                    new Category { Name = "Electronics" },
                    new Category { Name = "Home & Kitchen" },
                    new Category { Name = "Beauty & Health" },
                    new Category { Name = "Toys & Games" },
                    new Category { Name = "Men's Clothing" }
                );
            }
            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                    new Brand { Name = "Sanrio" },
                    new Brand { Name = "Nike" },
                    new Brand { Name = "Calvin Klein" }
                );
            }
            await _context.SaveChangesAsync();
        }

        public async Task IdentityDataSeedingAsync()
        {
            if(!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Super Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            if(!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email = "tariq.shreem@gmail.com",
                    FullName = "Tariq Shreem",
                    UserName = "tshreem",
                    PhoneNumber = "0598765432",
                    Country = "Palestine",
                    City = "Qalqilya",
                    Street = "AS-Salam Street",
                    EmailConfirmed = true
                };
                var user2 = new ApplicationUser()
                {
                    Email = "baraa.aboasal@gmail.com",
                    FullName = "Bara'a Abo-Asal",
                    UserName = "baboasal",
                    PhoneNumber = "0598765432",
                    Country = "Palestine",
                    City = "Ramallah",
                    Street = "AL-Ersal Street",
                    EmailConfirmed = true
                };
                var user3 = new ApplicationUser()
                {
                    Email = "afnanalaa49@gmail.com",
                    FullName = "Afnan Abo-Asal",
                    UserName = "implutogal",
                    PhoneNumber = "0598765432",
                    Country = "Palestine",
                    City = "Anabta",
                    Street = "Nablus-Tulkarm Street",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(user1, "Admin@123");
                await _userManager.CreateAsync(user2, "SuperAdmin@123");
                await _userManager.CreateAsync(user3, "Customer@123");

                await _userManager.AddToRoleAsync(user1, "Admin");
                await _userManager.AddToRoleAsync(user2, "Super Admin");
                await _userManager.AddToRoleAsync(user3, "Customer");
            }
            await _context.SaveChangesAsync();
        }
    }
}
