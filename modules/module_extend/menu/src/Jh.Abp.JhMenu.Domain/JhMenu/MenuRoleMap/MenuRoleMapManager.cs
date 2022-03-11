
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
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

        protected virtual IEnumerable<MenuRoleMap> CreateList(Guid[] RoleIds, Guid[] MenuIds)
        {
            Volo.Abp.Check.NotNull(RoleIds,nameof(RoleIds));
            MenuRoleMapRepository.DeleteListAsync(a => RoleIds.Contains(a.RoleId)).Wait();
            foreach (var roleid in RoleIds)
            {
                foreach (var menuid in MenuIds)
                {
                    yield return new MenuRoleMap(menuid, roleid);
                }
            }
        }

        public virtual async Task CreateAsync(Guid[] RoleIds, Guid[] MenuIds)
        {
            var entitys = CreateList(RoleIds,MenuIds);
            await MenuRoleMapRepository.CreateAsync(entitys.ToArray());
        }

        public virtual async Task InitMenuByRole(Guid[] roleids)
        {
            var menuIds = (await MenuRepository.GetQueryableAsync()).Select(x => x.Id).ToArray();
            if (menuIds.Length > 0)
            {
                if (!(await MenuRoleMapRepository.GetQueryableAsync()).Any())
                {
                    await CreateAsync(roleids, menuIds);
                }
            }
        }
    }
}
