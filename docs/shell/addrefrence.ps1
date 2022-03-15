# dotnet add ./host/MyCompanyName.ProjectName.HttpApi.Host/MyCompanyName.ProjectName.HttpApi.Host.csproj reference $Pre/QuickComponents/Jh.Abp.QuickComponents/Jh.Abp.QuickComponents.csproj
[CmdletBinding()]
param (
    [string]$execPath = '..\..\modules\module_extend\menu',
    [string]$slnName='MyCompanyName.ProjectName',
    [string]$Pre= '..\..\modules'
)

dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj reference $Pre/libs/QuickComponents/Jh.Abp.QuickComponents/Jh.Abp.QuickComponents.csproj

dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/libs/Jh.AbpExtensions/Jh.Abp.IdentityServer/Jh.Abp.IdentityServer.csproj
dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/libs/QuickComponents/Jh.Abp.QuickComponents/Jh.Abp.QuickComponents.csproj


# src
dotnet add $execPath\src\$slnName.Application\$slnName.Application.csproj reference $Pre/libs/Jh.AbpExtensions/Jh.Abp.Application/Jh.Abp.Application.csproj
dotnet add $execPath\src\$slnName.Application.Contracts\$slnName.Application.Contracts.csproj reference $Pre/libs/Jh.AbpExtensions/Jh.Abp.Application.Contracts/Jh.Abp.Application.Contracts.csproj
dotnet add $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj reference $Pre/libs/Jh.AbpExtensions/Jh.Abp.EntityFrameworkCore/Jh.Abp.EntityFrameworkCore.csproj
dotnet add $execPath\src\$slnName.Domain\$slnName.Domain.csproj reference $Pre/libs/Jh.AbpExtensions/Jh.Abp.Domain/Jh.Abp.Domain.csproj
dotnet add $execPath\src\$slnName.Domain\$slnName.Domain.csproj reference $Pre/libs/GeneratorCoding/Jh.SourceGenerator.Common/Jh.SourceGenerator.Common.csproj
dotnet add $execPath\src\$slnName.Domain.Shared\$slnName.Domain.Shared.csproj reference $Pre/libs/Jh.AbpExtensions/Jh.Abp.Domain.Shared/Jh.Abp.Domain.Shared.csproj

# Volo
dotnet add $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj package Volo.Abp.Dapper

# 项目引用

dotnet add $execPath\src\$slnName.Application.Contracts\$slnName.Application.Contracts.csproj reference $execPath\src\$slnName.Domain\$slnName.Domain.csproj
dotnet add $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj reference $execPath\src\$slnName.Application.Contracts\$slnName.Application.Contracts.csproj

# 不应该使用Application/EntityFrameworkCore
# dotnet add $execPath\src\$slnName.HttpApi\$slnName.HttpApi.csproj reference $execPath\src\$slnName.Application\$slnName.Application.csproj
# dotnet add $execPath\src\$slnName.HttpApi\$slnName.HttpApi.csproj reference $execPath\src\$slnName.EntityFrameworkCore\$slnName.EntityFrameworkCore.csproj

# end module refrence


# # 身份服务扩展模块 overwrite
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/identity/src/Jh.Abp.JhIdentity.HttpApi/Jh.Abp.JhIdentity.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/auditlogging/src/Jh.Abp.JhAuditLogging.HttpApi/Jh.Abp.JhAuditLogging.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/permission/src/Jh.Abp.JhPermission.HttpApi/Jh.Abp.JhPermission.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/setting/src/Jh.Abp.JhSetting.HttpApi/Jh.Abp.JhSetting.HttpApi.csproj

# # 自定义扩展
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/menu/src/Jh.Abp.JhMenu.HttpApi/Jh.Abp.JhMenu.HttpApi.csproj

# 模块引用
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj reference $Pre/module_extend/workflow/src/Jh.Abp.Workflow.HttpApi/Jh.Abp.Workflow.HttpApi.csproj


# # 引用
# # IdentityServer HttpApi
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/identity/src/Jh.Abp.JhIdentity.HttpApi/Jh.Abp.JhIdentity.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/menu/src/Jh.Abp.JhMenu.HttpApi/Jh.Abp.JhMenu.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/permission/src/Jh.Abp.JhPermission.HttpApi/Jh.Abp.JhPermission.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/overwrite/auditlogging/src/Jh.Abp.JhAuditLogging.HttpApi/Jh.Abp.JhAuditLogging.HttpApi.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/workflow/src/Jh.Abp.Workflow.HttpApi/Jh.Abp.Workflow.HttpApi.csproj

# # Contracts
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/commodity/src/Jh.Abp.JhCommodity.Application.Contracts/Jh.Abp.JhCommodity.Application.Contracts.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/file/src/Jh.Abp.JhFile.Application.Contracts/Jh.Abp.JhFile.Application.Contracts.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/article/src/Jh.Abp.JhArticle.Application.Contracts/Jh.Abp.JhArticle.Application.Contracts.csproj
# dotnet add $execPath\host\$slnName.IdentityServer\$slnName.IdentityServer.csproj reference $Pre/module_extend/webapp/src/Jh.Abp.JhWebApp.Application.Contracts/Jh.Abp.JhWebApp.Application.Contracts.csproj

# # HttpApi.Host
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj reference $Pre/module_extend/commodity/src/Jh.Abp.JhCommodity.HttpApi/Jh.Abp.JhCommodity.HttpApi.csproj
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj reference $Pre/module_extend/file/src/Jh.Abp.JhFile.HttpApi/Jh.Abp.JhFile.HttpApi.csproj
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj reference $Pre/module_extend/article/src/Jh.Abp.JhArticle.HttpApi/Jh.Abp.JhArticle.HttpApi.csproj
# dotnet add $execPath\host\$slnName.HttpApi.Host\$slnName.HttpApi.Host.csproj reference $Pre/module_extend/webapp/src/Jh.Abp.JhWebApp.HttpApi/Jh.Abp.JhWebApp.HttpApi.csproj