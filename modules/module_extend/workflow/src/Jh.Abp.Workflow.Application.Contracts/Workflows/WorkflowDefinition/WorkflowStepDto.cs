using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Workflow
{
    public class WorkflowStepDto
    {
        /// <summary>
        /// 步骤ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 步骤功能逻辑描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 步骤类型 ClassName+AssemblyName
        /// </summary>
        public string StepType { get { return $"{ClassName },{ AssemblyName}"; } }
        /// <summary>
        /// 步骤输入属性 键值对
        /// </summary>
        public dynamic Inputs { get; set; }
        /// <summary>
        /// 步骤输出属性 键值对
        /// </summary>
        public dynamic Outputs { get; set; }
        /// <summary>
        /// 命名空间+类名
        /// </summary>
        public string ClassName { get; set; }   
        /// <summary>
        /// 程序集名称
        /// </summary>
        public string AssemblyName { get; set; }
    }
}
