using Jh.Abp.Application.Contracts.Extensions;
using Jh.Abp.Common;
using Jh.Abp.Domain.Extensions;
using Jh.Abp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        }

        public override Task<PagedResultDto<MenuDto>> GetListAsync(MenuRetrieveInputDto input, string methodStringType = "Contains", bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(input.OrMenuCode))
            {
                input.MethodInput = new MethodDto<Menu>()
                {
                    QueryAction = entity => entity.Where(a => a.MenuParentCode == input.OrMenuCode || a.MenuCode == input.OrMenuCode)
                };
            }
            return base.GetListAsync(input, methodStringType, includeDetails, cancellationToken);
        }

        public override async Task<Menu> CreateAsync(MenuCreateInputDto inputDto, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            if (inputDto.RoleIds != null)
            {
                inputDto.MethodInput = new MethodDto<Menu>()
                {
                    CreateOrUpdateEntityAction = entity =>
                    {
                        entity.AddOrUpdateMenuRoleMap(inputDto.RoleIds);
                    }
                };
            }
            return await base.CreateAsync(inputDto, true, cancellationToken);
        }

        protected virtual IEnumerable<Menu> EnumerableCreateAsync(MenuCreateInputDto[] inputDtos, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var item in inputDtos)
            {
                yield return this.CreateAsync(item, autoSave, cancellationToken).Result;
            }
        }

        public override Task<Menu[]> CreateAsync(MenuCreateInputDto[] inputDtos, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(EnumerableCreateAsync(inputDtos, autoSave, cancellationToken).ToArray());
        }

        public override async Task<MenuDto> UpdateAsync(Guid id, MenuUpdateInputDto updateInput)
        {
            if (updateInput.RoleIds != null)
            {
                updateInput.MethodInput = new MethodDto<Menu>()
                {
                    CreateOrUpdateEntityAction = (entity) =>
                    {
                        entity.AddOrUpdateMenuRoleMap(updateInput.RoleIds);
                    }
                };
            }
            return await base.UpdateAsync(id, updateInput);
        }
    }
}
