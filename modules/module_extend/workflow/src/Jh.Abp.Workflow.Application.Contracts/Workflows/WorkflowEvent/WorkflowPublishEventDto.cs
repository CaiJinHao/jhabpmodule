using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jh.Abp.Workflow
{
    public class WorkflowPublishEventDto
    {
        //public string EventName { get; set; }

        //public string EventKey { get; set; }

        public object EventData { get; set; }

        /// <summary>
        /// 待办事项主键
        /// </summary>
        [Required]
        public Guid BacklogId { get; set; }
    }
}
