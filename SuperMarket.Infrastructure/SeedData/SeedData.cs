using Microsoft.AspNetCore.Identity;
using SuperMarket.Application.ApplicationConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Infrastructure.SeedData
{
	public class SeedData
	{
        public static async Task AddRolesAsync(RoleManager<IdentityRole> roleManager)
		{
			var roles = new List<string> { CustomeRole.Admin, CustomeRole.Customer, CustomeRole.Manager };

			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new IdentityRole(role));
				}
			}
		}
	}
}
