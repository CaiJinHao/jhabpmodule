# 初始化新项目引用和更新项目版本
[CmdletBinding()]
param (
    [string]$execPath = '../../modules/demo/aspnet-core',
    [string]$slnName = 'YourCompany.YourProjectName'
)

# host
dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj package Jh.Abp.QuickComponents

dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.IdentityServer
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.QuickComponents

# src
dotnet add $execPath\src\$slnName.Application\$slnName.Application.csproj package Jh.Abp.Application
dotnet add $execPath\src\$slnName.Application.Contracts\$slnName.Application.Contracts.csproj package Jh.Abp.Application.Contracts
dotnet add $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj package Jh.Abp.EntityFrameworkCore
dotnet add $execPath\src\$slnName.Domain\$slnName.Domain.csproj package Jh.Abp.Domain
dotnet add $execPath\src\$slnName.Domain\$slnName.Domain.csproj package Jh.SourceGenerator.Common
dotnet add $execPath\src\$slnName.Domain.Shared\$slnName.Domain.Shared.csproj package Jh.Abp.Domain.Shared

# Volo
dotnet add $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj package Volo.Abp.Dapper

# 项目引用

dotnet add $execPath\src\$slnName.Application.Contracts\$slnName.Application.Contracts.csproj reference $execPath\src\$slnName.Domain\$slnName.Domain.csproj



# 模块引用
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhIdentity.HttpApi
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhIdentity.Application
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhIdentity.EntityFrameworkCore

dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhMenu.HttpApi
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhMenu.Application
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhMenu.EntityFrameworkCore

# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj package Jh.Abp.Workflow.HttpApi
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj package Jh.Abp.Workflow.Application
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj package Jh.Abp.Workflow.EntityFrameworkCore

# 模块引用
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhAuditLogging.HttpApi
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhPermission.HttpApi
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj package Jh.Abp.JhSetting.HttpApi

# 如果需要重写模块 例如：workflow
# dotnet add $execPath\src\$slnName.Application\$slnName.Application.csproj package Jh.Abp.Workflow.Application
# dotnet add $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj package Jh.Abp.Workflow.EntityFrameworkCore


# workflow需要引用IdentityServer， typeof(JhIdentityApplicationContractsModule),typeof(JhIdentityApplicationModule),typeof(JhIdentityEntityFrameworkCoreModule)


Write-Output "success ok"