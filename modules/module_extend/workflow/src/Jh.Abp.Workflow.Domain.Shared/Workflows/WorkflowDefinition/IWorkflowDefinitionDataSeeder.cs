﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionDataSeeder
    {
        Task SeedAsync();
    }
}
