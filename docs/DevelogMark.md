# ����ע��

## UEditorʹ��

��ǰ�˷�������ַ��Ϊ��https�ó���ַ  
��ǰ��nginx����������·��Ϊ��̨�ϴ��ļ��õ�ַ
location /articleUpload {
            alias G:/github/mygithub/jhabpmodule/modules/webapp/host/Jh.Abp.JhWebApp.HttpApi.Host/articleUpload;
        }
        ����
location /articleUpload {
            root G:/github/mygithub/jhabpmodule/modules/webapp/host/Jh.Abp.JhWebApp.HttpApi.Host;
        }