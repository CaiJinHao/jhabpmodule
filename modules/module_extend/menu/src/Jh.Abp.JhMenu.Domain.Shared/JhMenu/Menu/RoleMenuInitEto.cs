using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EventBus;

namespace Jh.Abp.JhMenu
{
    [EventName("Menu.RoleMenuInitEto")]
    public class RoleMenuInitEto
    {
        public Guid[] RoleIds { get; set; }
    }
}
