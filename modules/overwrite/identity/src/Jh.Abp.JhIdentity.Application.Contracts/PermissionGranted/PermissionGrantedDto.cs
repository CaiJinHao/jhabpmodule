using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.JhPermission
{
    public class PermissionGrantedDto 
    {
        public string Name { get; set; }

        public bool IsGranted { get; set; }
    }
}
