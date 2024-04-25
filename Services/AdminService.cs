using CarsCRUD.Commens.Helpers;
using DataAccessLayer.AuthDTOs;
using DataAccessLayer.Roles;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Trainers.Interfaces;

namespace Trainers.Services;
public class AdminService(IConfiguration configuration,
                          RoleManager<ApplicationRole> roleManager,
                          UserManager<ApplicationUser> userManager) : IAdminService
                        
{
    private readonly IConfiguration _configuration = configuration;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    public async Task DeleteAccountAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new Exception("User not found");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
            throw new Exception("Invalid email/password");

        await _userManager.RemoveAuthenticationTokenAsync(user, _configuration["Jwt:Issuer"] ?? "", "Token");

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            throw new ValidationException("Failed to delete user");
    }

    public async Task<LoginResponse> LoginAdminAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new Exception("User not found");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
            throw new Exception("Invalid email/password");

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains(IdentityRoles.ADMIN))
            throw new Exception("User is not an admin");

        var tokenString = JwtHelper.GenerateJwtToken(user, roles, _configuration);

        return new LoginResponse { Success = true, AccessToken = tokenString };
    }

    public async Task<LoginResponse> LoginSuperAdminAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new Exception("User not found");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
            throw new Exception("Invalid email/password");

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains(IdentityRoles.SUPER_ADMIN))
            throw new Exception("User is not a super admin");

        var tokenString = JwtHelper.GenerateJwtToken(user, roles, _configuration);

        return new LoginResponse { Success = true, AccessToken = tokenString };
    }

    public async Task<RegisterResponse> RegisterAdminAsync(RegistrationRequest request)
    {
        try
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                throw new Exception("Admin already exists");

            var user = new ApplicationUser
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email
            };

            var createUserResult = await _userManager.CreateAsync(user, request.Password);
            if (!createUserResult.Succeeded)
                throw new ValidationException($"Create admin failed {createUserResult?.Errors?.First()?.Description}");

            if (!await _roleManager.RoleExistsAsync(IdentityRoles.ADMIN))
                await _roleManager.CreateAsync(new ApplicationRole(IdentityRoles.ADMIN));

            await _userManager.AddToRoleAsync(user, IdentityRoles.ADMIN);

            return new RegisterResponse { Success = true, Message = "User registered successfully" };
        }
        catch (ValidationException ex)
        {
            return new RegisterResponse { Success = false, Message = ex.Message };
        }
        catch (Exception ex)
        {
            return new RegisterResponse { Success = false, Message = ex.Message };
        }
    }

    public async Task<RegisterResponse> RegisterSuperAdminAsync(RegistrationRequest request)
    {
        try
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                throw new Exception("SuperAdmin already exists");

            var user = new ApplicationUser
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email
            };

            var createUserResult = await _userManager.CreateAsync(user, request.Password);
            if (!createUserResult.Succeeded)
                throw new ValidationException($"Create SuperAdmin failed {createUserResult?.Errors?.First()?.Description}");


            if (!await _roleManager.RoleExistsAsync(IdentityRoles.SUPER_ADMIN))
                await _roleManager.CreateAsync(new ApplicationRole(IdentityRoles.SUPER_ADMIN));

            await _userManager.AddToRoleAsync(user, IdentityRoles.SUPER_ADMIN);


            return new RegisterResponse { Success = true, Message = "SuperAdmin registered successfully" };
        }
        catch (ValidationException ex)
        {
            return new RegisterResponse { Success = false, Message = ex.Message };
        }
        catch (Exception ex)
        {
            return new RegisterResponse { Success = false, Message = ex.Message };
        }
    }
}