# Module

菜单模块是针对前端后台展示设计的，如果不用现在的前端框架展示了，有可能会更换或更改菜单模块。

## USE

abp new Jh.Abp.JhMenu -t module -d ef -cs "server=127.0.0.1;database=jh_menu;uid=root;pwd=123456"  

.\addrefrence.ps1 -execPath ..\..\modules\module_extend\menu\ -slnName Jh.Abp.JhMenu  

`
<Import Project="..\..\common.props" />
`
域服务代码生成，域服务存在的目的
可单独模块启动  
