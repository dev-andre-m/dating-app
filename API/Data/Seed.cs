﻿using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;
            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach ( var user in users )
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
    }
}
