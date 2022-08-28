using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitExtension : Entity<Guid>
    {
        /// <summary>
        /// 领导id
        /// </summary>
        public virtual Guid? LeaderId { get; set; }
        /// <summary>
        /// 领导类型，可以使用多选枚举判断
        /// </summary>
        public virtual int? LeaderType { get; set; }
        public OrganizationUnitExtension(Guid OrganizationUnitId)
        {
            Id = OrganizationUnitId;
        }
        public OrganizationUnitExtension(Guid OrganizationUnitId, Guid? leaderId,int? leaderType)
        { 
            Id = OrganizationUnitId;
            LeaderId = leaderId;
            LeaderType = leaderType;
        }
    }
}
