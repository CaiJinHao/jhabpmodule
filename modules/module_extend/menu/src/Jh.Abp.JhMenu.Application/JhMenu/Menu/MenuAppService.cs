using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
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
        protected readonly IMenuRepository MenuRepository;
        protected IMenuDapperRepository MenuDapperRepository => LazyServiceProvider.LazyGetRequiredService<IMenuDapperRepository>();
        public MenuAppService(IMenuRepository repository) : base(repository)
        {
            MenuRepository = repository;
            CreatePolicyName = JhMenuPermissions.Menus.Create;
            UpdatePolicyName = JhMenuPermissions.Menus.Update;
            DeletePolicyName = JhMenuPermissions.Menus.Delete;
            GetPolicyName = JhMenuPermissions.Menus.Detail;
            GetListPolicyName = JhMenuPermissions.Menus.Default;
            BatchDeletePolicyName = JhMenuPermissions.Menus.BatchDelete;
        }

        public override async Task<PagedResultDto<MenuDto>> GetListAsync(MenuRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync();
            if (!string.IsNullOrEmpty(input.OrMenuCode))
            {
                input.MethodInput = new MethodDto<Menu>()
                {
                    QueryAction = entity => entity.Where(a => a.MenuParentCode == input.OrMenuCode || a.MenuCode == input.OrMenuCode)
                };
            }
            return await base.GetListAsync(input);
        }

        public virtual async Task RecoverAsync(System.Guid id)
        {
            await CheckPolicyAsync(JhMenuPermissions.Menus.Recover);
            using (DataFilter.Disable<ISoftDelete>())
            {
                var entity = await crudRepository.FindAsync(id, false);
                entity.IsDeleted = false;
                entity.DeleterId = CurrentUser.Id;
                entity.DeletionTime = Clock.Now;
            }
        }

        public virtual async Task<string> GetMaxMenuCodeAsync(string parentCode)
        {
            return await MenuRepository.GetMaxMenuCodeAsync(parentCode);
        }
    }
}
