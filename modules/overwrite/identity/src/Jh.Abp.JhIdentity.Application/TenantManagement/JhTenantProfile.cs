using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
    public class JhTenantProfile : Profile
	{
		public JhTenantProfile()
		{
			CreateMap<Tenant, TenantDto>()
				;
		}
	}
}
