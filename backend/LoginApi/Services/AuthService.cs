using LoginApi.Data;
using LoginApi.DTOs.Auth;
using LoginApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Services;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> SignupAsync(SignupRequest request)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(user => user.Email == request.Email);

        if (existingUser != null)
        {
            throw new InvalidOperationException("Email is already registered.");
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }
}