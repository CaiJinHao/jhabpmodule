using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jh.SourceGenerator.Common
{
    public class ReactAntdEditCodeBuilder : CodeBuilderBase
    {
        protected Type DomainType { get; }
        protected string ModuleNamespace { get; }
        protected GeneratorService GeneratorService { get; }
        protected string DomainDescription { get; set; }
        public ReactAntdEditCodeBuilder(Type domainType, string filePath, string moduleNamespace, string domainDescription)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FilePath = Path.Combine(filePath, $"pages/{domainType.Name}/components");//以表名称为上级文件名创建路径
            }
            DomainDescription = domainDescription;
            FileName = "OperationModal";
            Suffix = ".tsx";
            DomainType = domainType;
            ModuleNamespace = moduleNamespace;
            GeneratorService = new GeneratorService();
        }

        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine(@"
import ProForm, { ModalForm, ProFormSelect, ProFormText } from '@ant-design/pro-form';
import { FC, useEffect, useState } from 'react';
import { ViewOperator } from '@/services/jhabp/app.enums';
import { useIntl } from 'umi';
");

            stringBuilder.AppendLine($"import * as defaultService from '@/services/jhabp/identity/{DomainType.Name}/{DomainType.Name.ToLower()}.service';");

            var ComponentName = $"OperationModal{DomainType.Name}";//组件名称
            var ComponentDtoName = $"{ModuleNamespace}.{DomainType.Name}Dto";//组件Dto
            var ComponentCreateInputDtoName = $"{ModuleNamespace}.{DomainType.Name}CreateInputDto";//组件Dto
            var ComponentUpdateInputDtoName = $"{ModuleNamespace}.{DomainType.Name}UpdateInputDto";//组件Dto

            stringBuilder.AppendLine(@"
type OperationModalProps = {
  operator: ViewOperator;
  visible: boolean;
  onCancel: () => void;");
            stringBuilder.AppendLine($"current?: {ComponentDtoName};");
            stringBuilder.AppendLine($"onSubmit: (values: {ComponentDtoName}) => void;");
            stringBuilder.AppendLine("};");

            stringBuilder.AppendLine($"const {ComponentName}: FC<OperationModalProps> = (props) => {{");
            stringBuilder.AppendLine(@"const { operator, visible, current, onCancel, onSubmit, children } = props;
  const [title, setTitle] = useState<string>();
  const intl = useIntl();
");
            stringBuilder.AppendLine(@"
  const modalFormFinish = async (values: any) => {
    if (current) {");
            stringBuilder.AppendLine($"const _data = values as {ComponentUpdateInputDtoName};");
            stringBuilder.AppendLine(@"_data.concurrencyStamp = current.concurrencyStamp;
      const updateDto = await defaultService.Update(current.id, _data);
      if (updateDto) {
        onSubmit(updateDto);
      }
    } else {");
            stringBuilder.AppendLine($"const _data = values as {ComponentCreateInputDtoName});");
            stringBuilder.AppendLine(@"const createDto = await defaultService.Create(_data);
      if (createDto) {
        onSubmit(createDto);
      }
    }
  };");

            stringBuilder.AppendLine(@"
/* select-demo
  const requestOrganizationUnitOptions = async () => {
    const data = await defaultService.GetOptions('');
    const items = data.items as API.OptionDto<string>[];
    return items;
  };
*/");

            stringBuilder.AppendLine($"const initTitle = () => {{ let _t = '{DomainDescription}';");
            stringBuilder.AppendLine(@"switch (operator) {
      case ViewOperator.Add:
        {
          _t = `${_t}${intl.formatMessage({
            id: 'Permission:Create',
            defaultMessage: '创建',
          })}`;
        }
        break;
      case ViewOperator.Edit:
        {
          _t = `${_t}${intl.formatMessage({
            id: 'Permission:Edit',
            defaultMessage: '编辑',
          })}`;
        }
        break;
      case ViewOperator.Detail:
        {
          _t = `${_t}${intl.formatMessage({
            id: 'Permission:Detail',
            defaultMessage: '详情',
          })}`;
        }
        break;
    }
    setTitle(_t);
  };

  useEffect(() => {
    initTitle();
  }, [operator]);

  if (!current) {
    return <></>;
  }
");
            stringBuilder.AppendLine(@"
 return (
    <>
");
            stringBuilder.AppendLine($"<ModalForm<{ComponentDtoName}>");
            stringBuilder.AppendLine(@"
        visible={visible}
        title={title}
        onFinish ={modalFormFinish}
        initialValues={current}
        trigger={<>{children}</>}
        modalProps={{
          onCancel: () => onCancel(),
          destroyOnClose: true,
        }}
        submitter={operator == ViewOperator.Detail ? false : {}}
      >
        <>
");
            stringBuilder.AppendLine("<ProForm.Group>");
            foreach (var item in GeneratorService.GetFieldDto(GeneratorService.GetMembers<GeneratorAttributes.CreateOrUpdateInputDtoAttribute>(DomainType)))
            {
                var fieldName = item.Name;
                var fieldDescription = item.Description;
                stringBuilder.AppendLine(@$"<ProFormText width=""md"" name=""{fieldName}"" label=""{fieldDescription}""  rules={{[{{ required: true, message: '请输入{fieldDescription}' }}]}} placeholder=""请输入"" />");
            }
            stringBuilder.AppendLine("</ProForm.Group>");

            stringBuilder.AppendLine(@"
        </>
      </ModalForm>
    </>
  );
};");
            stringBuilder.AppendLine($"export default {ComponentName};");
            return stringBuilder.ToString();
        }
    }
}