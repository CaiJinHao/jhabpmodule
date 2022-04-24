using namespace System.Linq;
using namespace System.Xml;

[CmdletBinding()]
param (
    [string] $apiKey,
    [string] $execPath = '../../',
    [string] $outPath = 'G:\Publish\nuget-local',
    [string] $module = '',
    [string] $publishSource = "https://api.nuget.org/v3/index.json"
)

# 当前目录
# $CurrentyDir = Split-Path -Parent $MyInvocation.MyCommand.Definition;

$packagesDto =

# 公共类库
@{Name = "Jh.Abp.Common"; Module="libs"; },

# 快速启动组件
@{Name = "Jh.Abp.QuickComponents";  Module="libs"; },

# 身份服务类库
@{Name = "Jh.Abp.IdentityServer";  Module="libs"; },

# 代码生成类库
@{Name = "Jh.SourceGenerator.Common";  Module="libs"; },
@{Name = "Jh.SourceGenerator";  Module="libs"; },

# 基础设施类库
@{Name = "Jh.Abp.Application";  Module="libs"; },
@{Name = "Jh.Abp.Application.Contracts"; Module="libs";  },
@{Name = "Jh.Abp.Domain";  Module="libs"; },
@{Name = "Jh.Abp.Domain.Shared";   Module="libs";},
@{Name = "Jh.Abp.EntityFrameworkCore";  Module="libs"; },


# 身份模块

@{Name = "Jh.Abp.JhIdentity.Application";  Module="JhIdentity"; },
@{Name = "Jh.Abp.JhIdentity.Application.Contracts";  Module="JhIdentity";  },
@{Name = "Jh.Abp.JhIdentity.Domain";  Module="JhIdentity";  },
@{Name = "Jh.Abp.JhIdentity.Domain.Shared"; Module="JhIdentity";   },
@{Name = "Jh.Abp.JhIdentity.EntityFrameworkCore";  Module="JhIdentity";  },
@{Name = "Jh.Abp.JhIdentity.HttpApi";   Module="JhIdentity"; },
@{Name = "Jh.Abp.JhIdentity.HttpApi.Client";  Module="JhIdentity";  },

# 权限模块

# @{Name = "Jh.Abp.JhPermission.Application";  Module="JhPermission";  },
# @{Name = "Jh.Abp.JhPermission.Application.Contracts"; Module="JhPermission";  },
# @{Name = "Jh.Abp.JhPermission.Domain";  Module="JhPermission"; },
# @{Name = "Jh.Abp.JhPermission.Domain.Shared";  Module="JhPermission"; },
# @{Name = "Jh.Abp.JhPermission.HttpApi"; Module="JhPermission";  },

# 菜单模块

@{Name = "Jh.Abp.JhMenu.Application";  Module="JhMenu"; },
@{Name = "Jh.Abp.JhMenu.Application.Contracts";  Module="JhMenu";},
@{Name = "Jh.Abp.JhMenu.Domain"; Module="JhMenu"; },
@{Name = "Jh.Abp.JhMenu.Domain.Shared"; Module="JhMenu"; },
@{Name = "Jh.Abp.JhMenu.EntityFrameworkCore"; Module="JhMenu"; },
@{Name = "Jh.Abp.JhMenu.HttpApi";  Module="JhMenu";},

# 工作流模块

@{Name = "Jh.Abp.Workflow.HttpApi"; Module="Workflow"; },
@{Name = "Jh.Abp.Workflow.Application";Module="Workflow";  },
@{Name = "Jh.Abp.Workflow.Application.Contracts"; Module="Workflow"; },
@{Name = "Jh.Abp.Workflow.Domain"; Module="Workflow"; },
@{Name = "Jh.Abp.Workflow.Domain.Shared"; Module="Workflow"; },
@{Name = "Jh.Abp.Workflow.EntityFrameworkCore"; Module="Workflow"; }

# # 日志模块

# @{Name = "Jh.Abp.JhAuditLogging.Application";  },
# @{Name = "Jh.Abp.JhAuditLogging.Application.Contracts";  },
# @{Name = "Jh.Abp.JhAuditLogging.Domain";  },
# @{Name = "Jh.Abp.JhAuditLogging.Domain.Shared";  },
# @{Name = "Jh.Abp.JhAuditLogging.EntityFrameworkCore";  },
# @{Name = "Jh.Abp.JhAuditLogging.HttpApi";  },

# # 系统设置模块

# @{Name = "Jh.Abp.JhSetting.Application";  },
# @{Name = "Jh.Abp.JhSetting.Application.Contracts";  },
# @{Name = "Jh.Abp.JhSetting.Domain";  },
# @{Name = "Jh.Abp.JhSetting.Domain.Shared";  },
# @{Name = "Jh.Abp.JhSetting.EntityFrameworkCore";  },
# @{Name = "Jh.Abp.JhSetting.HttpApi";  },




# # 文件系统

# @{Name = "Jh.Abp.JhFile.Application";  },
# @{Name = "Jh.Abp.JhFile.Application.Contracts";  },
# @{Name = "Jh.Abp.JhFile.Domain";  },
# @{Name = "Jh.Abp.JhFile.Domain.Shared";  },
# @{Name = "Jh.Abp.JhFile.EntityFrameworkCore";  },
# @{Name = "Jh.Abp.JhFile.HttpApi";  },

# # 商品系统

# @{Name = "Jh.Abp.JhCommodity.Application";  },
# @{Name = "Jh.Abp.JhCommodity.Application.Contracts";  },
# @{Name = "Jh.Abp.JhCommodity.Domain";  },
# @{Name = "Jh.Abp.JhCommodity.Domain.Shared";  },
# @{Name = "Jh.Abp.JhCommodity.EntityFrameworkCore";  },
# @{Name = "Jh.Abp.JhCommodity.HttpApi";  },

# # 文章系统

# @{Name = "Jh.Abp.JhArticle.Application";  },
# @{Name = "Jh.Abp.JhArticle.Application.Contracts";  },
# @{Name = "Jh.Abp.JhArticle.Domain";  },
# @{Name = "Jh.Abp.JhArticle.Domain.Shared";  },
# @{Name = "Jh.Abp.JhArticle.EntityFrameworkCore";  },
# @{Name = "Jh.Abp.JhArticle.HttpApi";  }


# Web基础配置 todo

# @{Name = "Jh.Abp.JhWebApp.Application";  },
# @{Name = "Jh.Abp.JhWebApp.Application.Contracts";  },
# @{Name = "Jh.Abp.JhWebApp.Domain";  },
# @{Name = "Jh.Abp.JhWebApp.Domain.Shared";  },
# @{Name = "Jh.Abp.JhWebApp.EntityFrameworkCore";  },
# @{Name = "Jh.Abp.JhWebApp.HttpApi";  }
;


function New-PackByNupkg() {
    # 查找指定的文件
    $files = Get-ChildItem -Path $execPath -Recurse | Where-Object -FilterScript { $_.Mode -EQ "-a----" -and $_.Extension -eq '.csproj' };

    foreach ($pack in $packagesDto) {
        if($module!=''){
            if($pack.Module -ne $module){
                $module
                retrun;
            }
        }
        $file = $files | Where-Object -FilterScript { $_.BaseName -eq $pack.Name };
        if ($file.Exists) {
            # 三种执行命令的方式
            dotnet pack $file.FullName -o $outPath
            # powershell.exe "dotnet pack $($file.FullName) -o $outPath"
            # pwsh -Command "dotnet pack $($file.FullName) -o $outPath"
            # cmd /c "dotnet pack $($file.FullName) -o $outPath"
        }
    }

    Publish-PackNuget;
}

function Publish-PackNuget() {
    if (![System.String]::IsNullOrEmpty($apiKey)) {
        $files = Get-ChildItem -Path $outPath | Where-Object -FilterScript { $_.Extension -eq '.nupkg' };
        foreach ($item in $files) {
            # pwsh -Command "dotnet nuget push $($item.FullName) --api-key $apiKey --source $publishSource --skip-duplicate";
            dotnet nuget push $item.FullName --api-key $apiKey --source $publishSource --skip-duplicate
        }
    }
}


Write-Host '正在处理，请稍后。。。';
New-PackByNupkg;
Write-Host "处理完成"