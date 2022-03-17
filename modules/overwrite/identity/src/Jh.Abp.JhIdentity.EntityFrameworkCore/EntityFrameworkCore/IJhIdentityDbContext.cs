using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public interface IJhIdentityDbContext : IEfCoreDbContext
{
    DbSet<JhOrganizationUnit> OrganizationUnits { get; }
}
