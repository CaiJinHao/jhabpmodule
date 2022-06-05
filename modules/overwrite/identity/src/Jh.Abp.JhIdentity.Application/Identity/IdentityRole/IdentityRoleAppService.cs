using Jh.Abp.Application;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Jh.Abp.Common.Utils;
using Jh.Abp.Application.Contracts;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleAppService
		: CrudApplicationService<IdentityRole, IdentityRoleDto, IdentityRoleDto, System.Guid, IdentityRoleRetrieveInputDto, IdentityRoleCreateInputDto, IdentityRoleUpdateInputDto, IdentityRoleDeleteInputDto>,
		IJhIdentityRoleAppService
	{
		private readonly IJhIdentityRoleRepository IdentityRoleRepository;
		private readonly IIdentityRoleDapperRepository IdentityRoleDapperRepository;
		public JhIdentityRoleAppService(IJhIdentityRoleRepository repository, IIdentityRoleDapperRepository identityroleDapperRepository) : base(repository)
		{
		IdentityRoleRepository = repository;
		IdentityRoleDapperRepository = identityroleDapperRepository;
		}

        public override Task<PagedResultDto<IdentityRoleDto>> GetListAsync(IdentityRoleRetrieveInputDto input)
        {
            input.MethodInput = new MethodDto<IdentityRole>()
            {
                QueryAction = (entity) =>
                {
                    return entity.Where(a => a.Name != JhIdentity.JhIdentityConsts.AdminRoleName);
                }
            };
            return base.GetListAsync(input);
        }

        public async Task<Guid?> GetAdminRoleIdAsync()
        {
            var role = await (await IdentityRoleRepository.GetQueryableAsync()).AsNoTracking().FirstOrDefaultAsync(a => a.Name == JhIdentity.JhIdentityConsts.AdminRoleName);
            if (role!=null)
            {
				return role.Id;
            }
			return null;
        }

        public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name)
        {
            var query = await IdentityRoleRepository.GetQueryableAsync(true);
            query = query.Where(a => a.Name != JhIdentityConsts.AdminRoleName);
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }
            return new ListResultDto<OptionDto<Guid>>(query.Select(a => new OptionDto<Guid> { Label = a.Name, Value = a.Id }).ToList());
        }
    }
}
