using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 工作流数据传入对象 注意值类型空判断
    /// </summary>
    public class WorkflowDynamicData
    {
        public Dictionary<string, dynamic> Storage { get; set; } = new Dictionary<string, dynamic>();

        public dynamic this[string propertyName]
        {
            get => Storage.TryGetValue(propertyName, out var value) ? value : null;
            set => Storage[propertyName] = value;
        }
    }
}
