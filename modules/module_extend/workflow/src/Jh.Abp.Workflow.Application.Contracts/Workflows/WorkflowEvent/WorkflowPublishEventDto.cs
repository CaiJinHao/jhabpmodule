using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jh.Abp.Workflow
{
    public class WorkflowPublishEventDto
    {
        //public string EventName { get; set; }

        //public string EventKey { get; set; }

        public dynamic EventData { get; set; }

        /// <summary>
        /// 待办事项主键
        /// </summary>
        [Required]
        public Guid BacklogId { get; set; }
    }
}
