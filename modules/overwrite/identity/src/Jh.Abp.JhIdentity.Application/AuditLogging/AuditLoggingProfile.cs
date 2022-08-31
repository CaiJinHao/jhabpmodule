using AutoMapper;
using Jh.Abp.AuditLogging;
using Volo.Abp.AuditLogging;

namespace Jh.Abp.JhIdentity
{
    public class AuditLoggingProfile : Profile
	{
		public AuditLoggingProfile()
		{
		CreateMap<AuditLog, AuditLogDto>();
		}
	}
}
