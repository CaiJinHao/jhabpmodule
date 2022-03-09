using Jh.Abp.Application.Contracts.Extensions;
using Jh.Abp.Common;
using Jh.Abp.Domain.Extensions;
using Jh.Abp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Jh.Abp.JhMenu
{
	public class MenuAppService
		: CrudApplicationService<Menu, MenuDto, MenuDto, System.Guid, MenuRetrieveInputDto, MenuCreateInputDto, MenuUpdateInputDto, MenuDeleteInputDto>,
		IMenuAppService
	{
        private readonly IMenuRepository MenuRepository;
        private readonly IMenuDapperRepository MenuDapperRepository;
        public MenuAppService(IMenuRepository repository, IMenuDapperRepository menuDapperRepository) : base(repository)
        {
            MenuRepository = repository;
            MenuDapperRepository = menuDapperRepository;
            CreatePolicyName = JhMenuPermissions.Menus.Create;
            UpdatePolicyName = JhMenuPermissions.Menus.Update;
            DeletePolicyName = JhMenuPermissions.Menus.Delete;
            GetPolicyName = JhMenuPermissions.Menus.Detail;
            GetListPolicyName = JhMenuPermissions.Menus.Default;
            BatchDeletePolicyName = JhMenuPermissions.Menus.BatchDelete;
        }

        public override Task<PagedResultDto<MenuDto>> GetListAsync(MenuRetrieveInputDto input, string methodStringType = ObjectMethodConsts.ContainsMethod, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            CheckPolicyAsync(GetListPolicyName);
            if (!string.IsNullOrEmpty(input.OrMenuCode))
            {
                input.MethodInput = new MethodDto<Menu>()
                {
                    QueryAction = entity => entity.Where(a => a.MenuParentCode == input.OrMenuCode || a.MenuCode == input.OrMenuCode)
                };
            }
            return base.GetListAsync(input, methodStringType, includeDetails, cancellationToken);
        }

        public virtual async Task RecoverAsync(System.Guid id)
        {
            await CheckPolicyAsync(JhMenuPermissions.Menus.Recover).ConfigureAwait(false);
            using (DataFilter.Disable<ISoftDelete>())
            {
                var entity = await crudRepository.FindAsync(id, false);
                entity.IsDeleted = false;
                entity.DeleterId = CurrentUser.Id;
                entity.DeletionTime = Clock.Now;
            }
        }
    }
}
