using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Workflow
{
    public class PushNotificationsStepDto
    {
        public string UserId { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
    }
}
