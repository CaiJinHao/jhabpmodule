using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Jh.Abp.Workflow
{
    public class WorkflowOptions
    {
        public List<Assembly> Assemblies { get; }

        public WorkflowOptions()
        { 
            Assemblies = new List<Assembly>();
        }
    }
}
