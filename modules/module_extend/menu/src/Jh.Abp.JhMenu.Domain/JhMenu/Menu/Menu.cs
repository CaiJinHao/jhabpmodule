
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Jh.SourceGenerator.Common.GeneratorAttributes;
using Volo.Abp;
using JetBrains.Annotations;
using System.Linq;
using Volo.Abp.MultiTenancy;
using Jh.Abp.Common;

namespace Jh.Abp.JhMenu
{
    [Description("菜单")]
    public class Menu : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        protected Menu() { }

        public Menu(
            string menuCode,
            string menuName,
            string menuIcon,
            int menuSort,
            Guid? tenantId = null)
        {
            MenuCode = menuCode;
            MenuName = menuName;
            MenuIcon = menuIcon;
            MenuSort = menuSort;
            TenantId = tenantId;
        }

        public virtual Guid? TenantId { get; set; }

        [Required]
        [MaxLength(200)]
        [Description("菜单编号")]
        [CreateOrUpdateInputDto]
        public string MenuCode { get; protected set; }

        [Required]
        [MaxLength(200)]
        [Description("菜单名称")]
        [CreateOrUpdateInputDto]
        public string MenuName { get; protected set; }

        [Required]
        [MaxLength(200)]
        [Description("菜单图标")]
        [CreateOrUpdateInputDto]
        public string MenuIcon { get; protected set; }

        [Required]
        [Description("菜单排序")]
        [CreateOrUpdateInputDto]
        public int MenuSort { get; protected set; }

        [MaxLength(200)]
        [Description("菜单上级菜单编号")]
        [CreateOrUpdateInputDto]
        public string MenuParentCode { get; set; }

        [MaxLength(200)]
        [Description("菜单导航路径")]
        [CreateOrUpdateInputDto]
        public string MenuUrl { get; set; }

        [MaxLength(200)]
        [Description("菜单描述")]
        [CreateOrUpdateInputDto]
        public string MenuDescription { get; set; }

        [Required]
        [Description("菜单所属平台")]
        [CreateOrUpdateInputDto]
        public int MenuPlatform { get; set; }

        private System.Collections.Generic.List<MenuRoleMap> menuRoleMap;

        /// <summary>
        /// Property for collection of MenuRoleMap
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<MenuRoleMap> MenuRoleMap
        {
            get
            {
                if (menuRoleMap == null)
                    menuRoleMap = new System.Collections.Generic.List<MenuRoleMap>();
                return menuRoleMap;
            }
            set
            {
                RemoveAllMenuRoleMap();
                if (value != null)
                {
                    foreach (MenuRoleMap oMenuRoleMap in value)
                        AddMenuRoleMap(oMenuRoleMap);
                }
            }
        }

        /// <summary>
        /// Add a new MenuRoleMap in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddMenuRoleMap(MenuRoleMap newMenuRoleMap)
        {
            if (newMenuRoleMap == null)
                return;
            if (this.menuRoleMap == null)
                this.menuRoleMap = new System.Collections.Generic.List<MenuRoleMap>();
            if (!this.menuRoleMap.Contains(newMenuRoleMap))
            {
                this.menuRoleMap.Add(newMenuRoleMap);
                newMenuRoleMap.Menu = this;
            }
        }

        /// <summary>
        /// Remove an existing MenuRoleMap from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveMenuRoleMap(MenuRoleMap oldMenuRoleMap)
        {
            if (oldMenuRoleMap == null)
                return;
            if (this.menuRoleMap != null)
                if (this.menuRoleMap.Contains(oldMenuRoleMap))
                {
                    this.menuRoleMap.Remove(oldMenuRoleMap);
                    oldMenuRoleMap.Menu = null;
                }
        }

        /// <summary>
        /// Remove all instances of MenuRoleMap from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllMenuRoleMap()
        {
            if (menuRoleMap != null)
            {
                System.Collections.ArrayList tmpMenuRoleMap = new System.Collections.ArrayList();
                foreach (MenuRoleMap oldMenuRoleMap in menuRoleMap)
                    tmpMenuRoleMap.Add(oldMenuRoleMap);
                menuRoleMap.Clear();
                foreach (MenuRoleMap oldMenuRoleMap in tmpMenuRoleMap)
                    oldMenuRoleMap.Menu = null;
                tmpMenuRoleMap.Clear();
            }
        }

    }
}
