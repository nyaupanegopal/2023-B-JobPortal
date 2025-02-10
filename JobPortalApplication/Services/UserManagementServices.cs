using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApplication.Services
{
    public class UserManagementServices
    {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary>
    /// Create a new user and assign a role
    /// </summary>
    public async Task<(bool Success, string Message, ApplicationUser User)> CreateUserAsync(string email, string password, string phoneNumber, string roleName)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            PhoneNumber = phoneNumber
        };

        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return (false, string.Join("; ", result.Errors.Select(e => e.Description)), null);
        }

        // Assign role
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        await _userManager.AddToRoleAsync(user, roleName);
        return (true, "User created successfully", user);
    }

    /// <summary>
    /// Get a user by their ID
    /// </summary>
    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    /// <summary>
    /// Assign an existing user to a role
    /// </summary>
    public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
            await _roleManager.CreateAsync(new IdentityRole(roleName));

        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded;
    }

    /// <summary>
    /// Get all users by role as SelectListItem for dropdowns
    /// </summary>
    public async Task<List<SelectListItem>> GetUsersByRoleAsync(string roleName)
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
        return usersInRole.Select(u => new SelectListItem
        {
            Value = u.Id,
            Text = u.Email
        }).ToList();
    }

    /// <summary>
    /// Get all roles as SelectListItem for dropdowns
    /// </summary>
    public async Task<List<SelectListItem>> GetAllRolesAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return roles.Select(r => new SelectListItem
        {
            Value = r.Name,
            Text = r.Name
        }).ToList();
    }
}
