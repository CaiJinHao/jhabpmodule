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
import type { FC } from 'react';
import { useState } from 'react';");
            stringBuilder.AppendLine($"import * as defaultService from '@/services/jhabp/identity/{DomainType.Name}/{DomainType.Name.ToLower()}.service';");

            var ComponentName = $"OperationModal{DomainType.Name}";//组件名称
            var ComponentDtoName = $"{ModuleNamespace}.{DomainType.Name}Dto";//组件Dto
            var ComponentCreateInputDtoName = $"{ModuleNamespace}.{DomainType.Name}CreateInputDto";//组件Dto

            stringBuilder.AppendLine(@"
type OperationModalProps = {
  detail: boolean;
  visible: boolean;
  onCancel: () => void;");
            stringBuilder.AppendLine($"current: Partial<{ComponentDtoName}> | undefined;");
            stringBuilder.AppendLine($"onSubmit: (values: {ComponentDtoName}) => void;");
            stringBuilder.AppendLine("};");

            stringBuilder.AppendLine($"const {ComponentName}: FC<OperationModalProps> = (props) => {{");
            stringBuilder.AppendLine("const { detail, visible, current, onCancel, onSubmit, children } = props;");
            stringBuilder.AppendLine($"const modalFormFinish = async (values: {ComponentCreateInputDtoName}) => {{");
            stringBuilder.AppendLine(@"
    if (current) {
      const updateDto = await defaultService.Update(current.id as string, values);
      if (updateDto) {
        onSubmit(updateDto);
      }
    } else {
      const createDto = await defaultService.Create(values);
      if (createDto) {
        onSubmit(createDto);
      }
    }
  };");

            stringBuilder.AppendLine(@"
/* select-demo
const requestOrganizationUnitOptions = async () => {
    if (organizationUnitOptions.length == 0) {
      const data = await defaultService.GetOptions('');
      const items = data.items as API.OptionDto<string>[];
      setOrganizationUnitOptions(items);
      return items;
    }
    return organizationUnitOptions;
  };
*/");
            stringBuilder.AppendLine(@"
 return (
    <>
");
            stringBuilder.AppendLine($"<ModalForm<{ComponentDtoName}>");
            stringBuilder.AppendLine(@"
        width={378}
        visible={visible}
");
            stringBuilder.AppendLine($"title={{`{DomainDescription}${{current ? '编辑' : '添加'}}`}}");
            stringBuilder.AppendLine(@"
        onFinish ={modalFormFinish}
        initialValues={current}
        trigger={<>{children}</>}
        modalProps={{
          onCancel: () => onCancel(),
          destroyOnClose: true,
        }}
        submitter={!detail ? {} : false}
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