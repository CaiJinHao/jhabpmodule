# 开发注意

## UEditor使用

将前端服务器地址改为带https得长地址  
将前端nginx上配置虚拟路径为后台上传文件得地址
location /articleUpload {
            alias G:/github/mygithub/jhabpmodule/modules/webapp/host/Jh.Abp.JhWebApp.HttpApi.Host/articleUpload;
        }
        或者
location /articleUpload {
            root G:/github/mygithub/jhabpmodule/modules/webapp/host/Jh.Abp.JhWebApp.HttpApi.Host;
        }

## 升级包版本

code G:\github\mygithub\jhmodule\modules\overwrite\identity\common.props  
code G:\github\mygithub\jhmodule\modules\libs\common.props  
code G:\github\mygithub\jhmodule\modules\module_extend\menu\common.props  
code G:\github\mygithub\jhmodule\modules\module_extend\workflow\common.props  
