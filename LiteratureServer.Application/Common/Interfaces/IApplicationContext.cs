using LiteratureServer.Domain.Entities;
using LiteratureServer.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Common.Interfaces;

public interface IApplicationContext
{
    #region Identities

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    #endregion

    #region Entities

    public DbSet<Author> Authors { get; set; }
    public DbSet<LiteraryType> LiteraryTypes { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<Literary> Literaries { get; set; }

    #endregion


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}