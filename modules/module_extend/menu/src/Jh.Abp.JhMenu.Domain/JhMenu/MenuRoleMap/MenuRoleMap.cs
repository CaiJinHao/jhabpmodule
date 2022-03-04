
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

namespace Jh.Abp.JhMenu
{

    //[GeneratorClass]
    [Description("角色菜单")]
    public class MenuRoleMap : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [Required]
        [MaxLength(200)]
        [Description("菜单Id")]
        [CreateOrUpdateInputDto]
        public Guid MenuId { get; set; }

        [Required]
        [MaxLength(200)]
        [Description("用户角色")]
        [CreateOrUpdateInputDto]
        public Guid RoleId { get; set; }

        public MenuRoleMap()
        {
        }

        public MenuRoleMap(Guid menuid, Guid roleid)
        {
            this.MenuId = menuid;
            this.RoleId = roleid;
        }

        private Menu menu;

        /// <summary>
        /// Property for Menu
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Menu Menu
        {
            get
            {
                return menu;
            }
            set
            {
                if (this.menu == null || !this.menu.Equals(value))
                {
                    if (this.menu != null)
                    {
                        Menu oldMenu = this.menu;
                        this.menu = null;
                        oldMenu.RemoveMenuRoleMap(this);
                    }
                    if (value != null)
                    {
                        this.menu = value;
                        this.menu.AddMenuRoleMap(this);
                    }
                }
            }
        }

    }
}
