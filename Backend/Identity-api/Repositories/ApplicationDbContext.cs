using Identity_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_api.Repositories;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<UserModel>(options);