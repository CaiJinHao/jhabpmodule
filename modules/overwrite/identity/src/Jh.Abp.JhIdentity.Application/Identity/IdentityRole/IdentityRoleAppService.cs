using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using Jh.Abp.Common.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleAppService
		: CrudApplicationService<IdentityRole, IdentityRoleDto, IdentityRoleDto, System.Guid, IdentityRoleRetrieveInputDto, IdentityRoleCreateInputDto, IdentityRoleUpdateInputDto, IdentityRoleDeleteInputDto>,
		IJhIdentityRoleAppService
	{
		private readonly IJhIdentityRoleRepository IdentityRoleRepository;
		public JhIdentityRoleAppService(IJhIdentityRoleRepository repository) : base(repository)
		{
		IdentityRoleRepository = repository;
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
            var query = await IdentityRoleRepository.GetTrackingAsync((await IdentityRoleRepository.GetQueryableAsync()), false);
            var role = (await IdentityRoleRepository.GetListAsync(query.Where(a => a.Name == JhIdentity.JhIdentityConsts.AdminRoleName))).FirstOrDefault();
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

        public virtual async Task<ListResultDto<TreeAntdDto>> GetTreesAsync()
        {
            var query = await IdentityRoleRepository.GetQueryableAsync(true);
            query = query.Where(a => a.Name != JhIdentityConsts.AdminRoleName);
            return new ListResultDto<TreeAntdDto>(query.Select(a => new TreeAntdDto(a.Id.ToString(), a.Name, a.NormalizedName) { isLeaf = true }).ToList());
        }
    }
}
