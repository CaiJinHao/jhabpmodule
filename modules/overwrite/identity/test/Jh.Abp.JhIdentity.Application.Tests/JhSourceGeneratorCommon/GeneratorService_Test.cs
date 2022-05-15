﻿using Jh.Abp.JhIdentity.v1;
using Jh.SourceGenerator.Common;
using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jh.Abp.JhIdentity.JhSourceGeneratorCommon
{
    public class GeneratorService_Test
    {
        [Fact]
        public void ReactProxyServiceCodeBuilder_Test()
        {
            var generatorPath = @"F:\Temp";
            var service = new GeneratorService(new GeneratorOptions(generatorPath));
            service.GeneratorCodeByAppService("API.JhIdentity", "API", "Identity_API", new Type[] { typeof(OrganizationUnitController) });
        }
    }
}
