using namespace System.Linq;
using namespace System.Xml;

[CmdletBinding()]
param (
    [string] $apiKey,
    [string] $execPath = '.',
    [string] $outPath = 'G:\Publish\nuget-local',
    [string] $publishSource = "https://api.nuget.org/v3/index.json"
)

# 当前目录
$CurrentyDir = Split-Path -Parent $MyInvocation.MyCommand.Definition;

$packagesDto =

# 公共类库
@{Name = "Jh.Abp.Common"; Version = "5.2.3"; },

# 快速启动组件
@{Name = "Jh.Abp.QuickComponents"; Version = "5.2.3"; },

# 身份服务类库
@{Name = "Jh.Abp.IdentityServer"; Version = "5.2.3"; },

# 代码生成类库
@{Name = "Jh.SourceGenerator.Common"; Version = "5.2.3"; },
@{Name = "Jh.SourceGenerator"; Version = "5.2.3"; },

# 基础设施类库
@{Name = "Jh.Abp.Application"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Application.Contracts"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Domain"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Domain.Shared"; Version = "5.2.3"; },
@{Name = "Jh.Abp.EntityFrameworkCore"; Version = "5.2.3"; },


# 身份模块

@{Name = "Jh.Abp.JhIdentity.Application"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhIdentity.Application.Contracts"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhIdentity.Domain"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhIdentity.Domain.Shared"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhIdentity.EntityFrameworkCore"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhIdentity.HttpApi"; Version = "5.2.3"; },


# 菜单模块

@{Name = "Jh.Abp.JhMenu.Application"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhMenu.Application.Contracts"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhMenu.Domain"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhMenu.Domain.Shared"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhMenu.EntityFrameworkCore"; Version = "5.2.3"; },
@{Name = "Jh.Abp.JhMenu.HttpApi"; Version = "5.2.3"; },

# 工作流模块

@{Name = "Jh.Abp.Workflow.HttpApi"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Workflow.Application"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Workflow.Application.Contracts"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Workflow.Domain"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Workflow.Domain.Shared"; Version = "5.2.3"; },
@{Name = "Jh.Abp.Workflow.EntityFrameworkCore"; Version = "5.2.3"; }

# # 日志模块

# @{Name = "Jh.Abp.JhAuditLogging.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhAuditLogging.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhAuditLogging.Domain"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhAuditLogging.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhAuditLogging.EntityFrameworkCore"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhAuditLogging.HttpApi"; Version = "5.2.3"; },

# # 系统设置模块

# @{Name = "Jh.Abp.JhSetting.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhSetting.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhSetting.Domain"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhSetting.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhSetting.EntityFrameworkCore"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhSetting.HttpApi"; Version = "5.2.3"; },

# # 权限模块

# @{Name = "Jh.Abp.JhPermission.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhPermission.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhPermission.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhPermission.HttpApi"; Version = "5.2.3"; },


# # 文件系统

# @{Name = "Jh.Abp.JhFile.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhFile.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhFile.Domain"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhFile.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhFile.EntityFrameworkCore"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhFile.HttpApi"; Version = "5.2.3"; },

# # 商品系统

# @{Name = "Jh.Abp.JhCommodity.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhCommodity.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhCommodity.Domain"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhCommodity.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhCommodity.EntityFrameworkCore"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhCommodity.HttpApi"; Version = "5.2.3"; },

# # 文章系统

# @{Name = "Jh.Abp.JhArticle.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhArticle.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhArticle.Domain"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhArticle.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhArticle.EntityFrameworkCore"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhArticle.HttpApi"; Version = "5.2.3"; }


# Web基础配置 todo

# @{Name = "Jh.Abp.JhWebApp.Application"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhWebApp.Application.Contracts"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhWebApp.Domain"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhWebApp.Domain.Shared"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhWebApp.EntityFrameworkCore"; Version = "5.2.3"; },
# @{Name = "Jh.Abp.JhWebApp.HttpApi"; Version = "5.2.3"; }
;


function New-PackByNupkg() {
    # 查找指定的文件
    $files = Get-ChildItem -Path $execPath -Recurse | Where-Object -FilterScript { $_.Mode -EQ "-a----" -and $_.Extension -eq '.csproj' };

    foreach ($pack in $packagesDto) {
        $file = $files | Where-Object -FilterScript { $_.BaseName -eq $pack.Name };
        if ($file.Exists) {
            # 三种执行命令的方式
            # powershell.exe "dotnet pack $($file.FullName) -o $outPath"
            pwsh -Command "dotnet pack $($file.FullName) -o $outPath"
            # cmd /c "dotnet pack $($file.FullName) -o $outPath"
            if (![System.String]::IsNullOrEmpty($apiKey)) {
                $publishFile = "$outPath\$($file.BaseName).$($pack.Version).nupkg";
                pwsh -Command "dotnet nuget push $publishFile --api-key $apiKey --source $publishSource --skip-duplicate";
            }
        }
    }
}


Write-Host '正在处理，请稍后。。。';
New-PackByNupkg;
Write-Host "处理完成"