using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jh.SourceGenerator.Common
{
    public class ReactAntdEditCodeBuilder : CodeBuilderBase
    {
        protected Type DomainType { get; }
        protected string JhModuleName { get; set; }
        protected string ModuleNamespace { get; }
        protected GeneratorService GeneratorService { get; }
        protected string DomainDescription { get; set; }
        public ReactAntdEditCodeBuilder(Type domainType, string filePath, string moduleNamespace, string jhModuleName, string domainDescription, GneratorType generatorType)
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
            JhModuleName = jhModuleName;
            GeneratorService = new GeneratorService(generatorType);
        }

        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine(@"
import ProForm, { ModalForm, ProFormSelect, ProFormText } from '@ant-design/pro-form';
import type { FC , useMemo} from 'react';
import { useEffect, useState } from 'react';
import { ViewOperator } from '@/services/jhabp/app.enums';
import { useIntl } from 'umi';
");

            stringBuilder.AppendLine($"import * as defaultService from '@/services/jhabp/{JhModuleName}/{DomainType.Name}/{DomainType.Name.ToLower()}.service';");

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
  const [extraProperties, setExtraProperties] = useState<any>();
");
            stringBuilder.AppendLine(@"
  const modalFormFinish = async (values: any) => {
    values.extraProperties = extraProperties;
    if (current) {
      const _data = Object.assign(current, values);");
            stringBuilder.AppendLine($"const updateDto = await defaultService.Update(current.id,_data as {ComponentUpdateInputDtoName});");
            stringBuilder.AppendLine(@"
      if (updateDto) {
        onSubmit(updateDto);
      }
    } else {");
            stringBuilder.AppendLine($"const _data = values as {ComponentCreateInputDtoName};");
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

            stringBuilder.AppendLine($"  const operatorTitle = useMemo(() => {{ let _t = intl.formatMessage({{id: 'DisplayName:{DomainType.Name}',defaultMessage: '{DomainDescription}'}});");
            stringBuilder.AppendLine(@"
   switch (operator) {
      case ViewOperator.Add:
        {
          _t = `${_t} ${intl.formatMessage({
            id: 'Permission:Create',
            defaultMessage: '创建',
          })}`;
        }
        break;
      case ViewOperator.Edit:
        {
          _t = `${_t} ${intl.formatMessage({
            id: 'Permission:Edit',
            defaultMessage: '编辑',
          })}`;
        }
        break;
      case ViewOperator.Detail:
        {
          _t = `${_t} ${intl.formatMessage({
            id: 'Permission:Detail',
            defaultMessage: '详情',
          })}`;
        }
        break;
      default:
        break;
    }
    return _t;
  }, [operator]);

/*
  const leaderSelectedChange = (value: any, option: any) => {
    setExtraProperties({
      ...extraProperties,
      LeaderId: value ?? null,
      LeaderName: value ? option.label : null,
    });
  };
*/

  useEffect(() => {
    setTitle(operatorTitle);
    setExtraProperties(current?.extraProperties);
  }, [current]);

  if (!current && operator != ViewOperator.Add) {
    return <></>;
  }
");
            stringBuilder.AppendLine(@"
 return (
    <>
");
            stringBuilder.AppendLine($"<ModalForm<{ComponentDtoName}>");
            stringBuilder.AppendLine(@"width={378}
        visible={visible}
        title={title}
        onFinish={modalFormFinish}
        initialValues={operator == ViewOperator.Add ? {} : current}
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
                var fieldDescription = item.Description;
                var _lable = @$"name=""{item.Name.ToCamelCase(CamelCaseType.LowerCamelCase)}"" label={{intl.formatMessage({{id: 'DisplayName:{DomainType.Name}:{item.Name}', defaultMessage: '{fieldDescription}',}})}} ";
                if (item.IsRequired)
                {
                    stringBuilder.AppendLine(@$"<ProFormText width=""md"" {_lable} rules={{[{{required: true,message: `${{intl.formatMessage({{id: 'Form.rules.message',defaultMessage: '请输入',}})}}\${{label}}`}},]}} />");
                }
                else
                {
                    stringBuilder.AppendLine(@$"<ProFormText width=""md"" {_lable} />");
                }
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