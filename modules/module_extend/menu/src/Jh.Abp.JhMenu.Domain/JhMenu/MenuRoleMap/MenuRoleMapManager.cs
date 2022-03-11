
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapManager : DomainService
    {
        protected IMenuRoleMapRepository MenuRoleMapRepository { get; }
        protected IMenuRepository MenuRepository { get; }
        public MenuRoleMapManager(IMenuRoleMapRepository menuRoleMapRepository, IMenuRepository menuRepository)
        {
            MenuRoleMapRepository = menuRoleMapRepository;
            MenuRepository = menuRepository;
        }

        protected virtual IEnumerable<MenuRoleMap> CreateList(Guid roleid, Guid[] MenuIds)
        {
            Volo.Abp.Check.NotNull(roleid, nameof(roleid));
            foreach (var menuid in MenuIds)
            {
                yield return new MenuRoleMap(menuid, roleid);
            }
        }

        protected virtual async Task CreateAsync(Guid roleId, Guid[] MenuIds)
        {
            await MenuRoleMapRepository.DeleteListAsync(a => roleId == a.RoleId);
            var entitys = CreateList(roleId, MenuIds);
            if (entitys.Any())
            {
                await MenuRoleMapRepository.CreateAsync(entitys.ToArray());
            }
        }

        public virtual async Task CreateAsync(Guid[] RoleIds, Guid[] MenuIds)
        {
            foreach (var item in RoleIds)
            {
                await CreateAsync(item,MenuIds);
            }
        }

        [UnitOfWork]
        public virtual async Task InitMenuByRole(Guid roleId)
        {
            var menuIds = (await MenuRepository.GetQueryableAsync()).Select(x => x.Id).ToArray();
            if (menuIds.Any())
            {
                if (!(await MenuRoleMapRepository.GetQueryableAsync()).Any(a => a.RoleId == roleId))
                {
                    await CreateAsync(roleId, menuIds);
                }
            }
        }
    }
}
