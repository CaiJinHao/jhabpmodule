using Jh.Abp.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
    public class TenantRetrieveInputDto : PagedAndSortedResultRequestDto, IRetrieveDelete
    {
        public string Name { get; set; }
        public int? Deleted { get; set; }
    }
}
