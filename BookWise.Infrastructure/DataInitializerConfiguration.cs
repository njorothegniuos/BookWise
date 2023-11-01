using BookWise.Domain.Common;
using BookWise.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Core.web.Mvc.Identity
{
    public static class DataInitializerConfiguration
    {

        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("sam").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Sam@bookwise.com".ToUpper();
                user.Email = "Sam@bookwise.com".ToUpper();
                user.NormalizedEmail = "Sam@bookwise.com".ToUpper();
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = false;
                user.CreatedDate = DateTime.Now;
                user.RecordStatus = (byte)UserRecordStatus.Approved;
                user.IsEnabled = true;
                user.IsExternalUser = false;
                user.LastPasswordChangedDate = DateTime.Now;
                user.PhoneNumber = "254707318620";
                user.PhoneNumberConfirmed = true;
                user.FirstName = "Sam";
                user.OtherNames = "Mburu";
                user.LastLoginDateTime = DateTime.Now;
                user.ApprovedDate = DateTime.Now;
                user.IsExternalUser = true;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = false;
                user.ApprovedBy = "System";
                user.CreatedBy = "System";

                IdentityResult result = userManager.CreateAsync
                (user, "Abc.123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "StandardUser").Wait();
                }
            }


            if (userManager.FindByNameAsync("su").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Sami@bookwise.com".ToUpper();
                user.Email = "Sami@bookwise.com".ToUpper();
                user.NormalizedEmail = "Sami@bookwise.com".ToUpper();
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = false;
                user.CreatedDate = DateTime.Now;
                user.RecordStatus = (byte)UserRecordStatus.Approved;
                user.IsEnabled = true;
                user.IsExternalUser = false;
                user.LastPasswordChangedDate = DateTime.Now;
                user.PhoneNumber = "254707318620";
                user.PhoneNumberConfirmed = true;
                user.FirstName = "Sami";
                user.OtherNames = "Mburu";
                user.LastLoginDateTime = DateTime.Now;
                user.ApprovedDate = DateTime.Now;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = false;
                user.ApprovedBy = "System";
                user.CreatedBy = "System";
                IdentityResult result = userManager.CreateAsync
                (user, "Abc.123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "SuperAdministrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("StandardUser").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "StandardUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("SuperAdministrator").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "SuperAdministrator";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }

    public static class ApplicationDomainName
    {
        public static string CurrentDomainName { get; set; }
    }
}
