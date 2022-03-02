using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

[ConnectionStringName(JhMenuDbProperties.ConnectionStringName)]
public interface IJhMenuDbContext : IEfCoreDbContext
{
    DbSet<Menu> Menus { get; }
    DbSet<MenuRoleMap> MenuRoleMaps { get; }
}
