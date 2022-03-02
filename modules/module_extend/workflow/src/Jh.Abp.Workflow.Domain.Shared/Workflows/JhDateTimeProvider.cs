using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;

namespace Jh.Abp.Workflow
{
    public class JhDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.Now;
    }
}
