using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jh.SourceGenerator.Common.ReactCodeBuilders
{
    public class ReactAntdListCodeBuilder : CodeBuilderBase
    {
        //创建的Dto的所有字段
        //输出的Dto的所有字段
        protected Type DomainType { get; }
        protected string ModuleNamespace { get; }
        protected string ModuleName { get; set; }
        protected GeneratorService GeneratorService { get;  }
        public ReactAntdListCodeBuilder(Type domainType, string filePath, string moduleName)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FilePath = Path.Combine(filePath);
            }
            FileName = "index";
            Suffix = ".tsx";
            DomainType = domainType;
            ModuleName = moduleName;
            ModuleNamespace = $"API.{moduleName}";

            GeneratorService = new GeneratorService();
        }

        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine(@"
import { useState, useRef } from 'react';
import type { ProColumns, ActionType } from '@ant-design/pro-table';
import { PageContainer } from '@ant-design/pro-layout';
import { Button, Switch, message, Modal } from 'antd';
import ProTable from '@ant-design/pro-table';
import { PlusOutlined, DeleteOutlined, ExclamationCircleOutlined } from '@ant-design/icons';
import { getYesOrNo } from '@/services/jhabp/app.enums';
import { useIntl } from 'umi';
");
            var operationModalName = $"OperationModal{DomainType.Name}";//操作ModalName
            stringBuilder.AppendLine($"import * as defaultService from '@/services/jhabp/identity/{DomainType.Name}/{DomainType.Name.ToLower()}.service';");
            stringBuilder.AppendLine($"import {operationModalName} from './components/OperationModal';");


            var ComponentName = $"{DomainType.Name}List";//组件名称
            var ComponentDtoName = $"{ModuleNamespace}.{DomainType.Name}Dto";//组件Dto
            stringBuilder.AppendLine($"const {ComponentName} = () => {{");

            stringBuilder.AppendLine(@"
  const [visibleOperation, setVisibleOperation] = useState<boolean>(false);
  const [detailOperation, setDetailOperation] = useState<boolean>(false);
  const { confirm } = Modal;
  const intl = useIntl();
  const proTableActionRef = useRef<ActionType>();
  const [totalPage, setTotalPage] = useState(0);
  const [selectedRowKeys, setSelectedRowKeys] = useState([]);
  const [yesOrNoOptions, setYesOrNoOptions] = useState([]);
");
            stringBuilder.AppendLine($"  const [currentOperation, setCurrentOperation] = useState<Partial<{ComponentDtoName}> | undefined>(undefined);");

            stringBuilder.AppendLine(@"
const requestYesOrNoOptions = async () => {
    if (yesOrNoOptions.length == 0) {
      const data = await getYesOrNo();
      setYesOrNoOptions(data);
      return data;
    }
    return yesOrNoOptions;
  };

  // columns functions
  const handlerIsDeleted = async (record: any, action: any) => {
    if (record.isDeleted) {
      confirm({
        icon: <ExclamationCircleOutlined />,
        content: (
          <>
            {intl.formatMessage({
              id: 'ProTable.delete.Recover',
              defaultMessage: '确定要恢复吗?',
            })}
          </>
        ),
        onOk: async () => {
          await defaultService.Recover(record.id);
          message.success(
            intl.formatMessage({ id: 'message.success', defaultMessage: '操作成功' }),
          );
          action?.reload();
        },
        onCancel() {},
      });
    } else {
      confirm({
        icon: <ExclamationCircleOutlined />,
        content: (
          <>
            {intl.formatMessage({
              id: 'ProTable.delete.Delete',
              defaultMessage: '确定要删除吗?',
            })}
          </>
        ),
        onOk: async () => {
          await defaultService.DeleteById(record.id);
          message.success(
            intl.formatMessage({ id: 'message.success', defaultMessage: '操作成功' }),
          );
          action?.reload();
        },
        onCancel() {},
      });
    }
  };

  const onCancelOperation = () => {
    setVisibleOperation(false);
  };

  const onSubmitOperation = () => {
    setVisibleOperation(false);
    message.success(intl.formatMessage({ id: 'message.success', defaultMessage: '操作成功' }));
    proTableActionRef.current?.reload();
  };

  const create = () => {
    setDetailOperation(false);
    setVisibleOperation(true);
    setCurrentOperation(undefined);
  };

  const deleteByKeys = async () => {
    if (selectedRowKeys.length > 0) {
      confirm({
        icon: <ExclamationCircleOutlined />,
        content: (
          <>
            {intl.formatMessage({
              id: 'ProTable.delete.BatchDelete',
              defaultMessage: '确定要删除选中项吗?',
            })}
          </>
        ),
        onOk: async () => {
          await defaultService.DeleteByKeys(selectedRowKeys);
          message.success(
            intl.formatMessage({ id: 'message.success', defaultMessage: '操作成功' }),
          );
          proTableActionRef.current?.reload();
        },
        onCancel() {},
      });
    } else {
      message.warning(
        intl.formatMessage({ id: 'message.select.required', defaultMessage: '请选择操作项' }),
      );
    }
  };
");
            stringBuilder.AppendLine($"const edit = (record: {ComponentDtoName}) => {{");
            stringBuilder.AppendLine(@"setDetailOperation(false);
    setVisibleOperation(true);
    setCurrentOperation(record);
  };");
            stringBuilder.AppendLine($"const detail = (record: {ComponentDtoName}) => {{");
            stringBuilder.AppendLine(@"setDetailOperation(true);
    setVisibleOperation(true);
    setCurrentOperation(record);
  };");


            stringBuilder.AppendLine($"const columns: ProColumns<{ComponentDtoName}>[] = [");
            //循环创建所有字段
            foreach (var item in GeneratorService.GetFieldDto(GeneratorService.GetMembers<GeneratorAttributes.CreateOrUpdateInputDtoAttribute>(DomainType)))
            {
                var fieldName = item.Name;
                var fieldDescription = item.Description;
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine($"title: intl.formatMessage({{id: '{ModuleName}:{DomainType.Name}:{fieldName}',defaultMessage: '{fieldDescription}',}}),dataIndex: '{fieldName}',");
                stringBuilder.AppendLine("},");
            }
            
            stringBuilder.AppendLine(@"{
      title: intl.formatMessage({ id: 'JhAbp:IsDeleted', defaultMessage: '是否删除' }),
      dataIndex: 'isDeleted',
      search: false,
      render: (text, record, index, action) => {
        return (
          <Switch checked={record.isDeleted} onChange={() => handlerIsDeleted(record, action)} />
        );
      },
    },
    {
      title: intl.formatMessage({ id: 'JhAbp:CreationTime', defaultMessage: '创建时间' }),
      width: 140,
      dataIndex: 'creationTime',
      valueType: 'date',
      search: false,
      sorter: true,
    },");
            stringBuilder.AppendLine(@"{
      title: intl.formatMessage({ id: 'JhAbp:Operation', defaultMessage: '操作' }),
      width: 180,
      key: 'option',
      valueType: 'option',
      render: (_, record) =>
        !record.isDeleted && [
          <a key=""edit"" onClick={() => edit(record)}>
            { intl.formatMessage({ id: 'Permission:Edit', defaultMessage: '编辑' })}
          </ a >,
          < a key = ""detail"" onClick ={ () => detail(record)}>
            { intl.formatMessage({ id: 'Permission:Detail', defaultMessage: '详情' })}
          </ a >,
        ],
    },
    {
      title: intl.formatMessage({ id: 'JhAbp:IsDeleted', defaultMessage: '是否删除' }),
      dataIndex: 'deleted',
      hideInTable: true,
      valueType: 'select',
      initialValue: 2,
      request: requestYesOrNoOptions,
    },");
            stringBuilder.AppendLine("];");
            stringBuilder.AppendLine(@"
  //table functions
  const getTableDataSource = async (params: any, sorter: any, filter: any) => {
    const sortings = [];
    const _sorter = new Object(sorter);
    for (const key in _sorter) {
      if (_sorter.hasOwnProperty(key)) {
        const val = sorter[key] as string;
        sortings.push(`${key} ${val.replace('end', '')}`);
      }
    }
    const inputParams = { ...params, sorting: sortings.join(',') };
    const responseData = await defaultService.GetList(inputParams);
    setTotalPage(responseData.totalCount);
    return {
      data: responseData.items,
      success: true,
    };
  };
  const rowSelection = {
    selectedRowKeys,
    onChange: (srk: any) => setSelectedRowKeys(srk),
  };
");
            stringBuilder.AppendLine(@"
  return (
    <>
      <PageContainer>");
            stringBuilder.AppendLine($"<ProTable<{ComponentDtoName}>");
            stringBuilder.AppendLine(@"
actionRef={proTableActionRef}
          columns={columns}
          rowSelection={rowSelection}
          request={(params, sorter, filter) => getTableDataSource(params, sorter, filter)}
          rowKey=""id""
          pagination={{
            pageSize: 10,
            total: totalPage,
          }}
          dateFormatter=""string""
          toolBarRender ={() => [
            <Button type=""primary"" key =""create"" shape =""round"" onClick ={create}>
              <PlusOutlined />
              {intl.formatMessage({ id: 'Permission:Create', defaultMessage: '创建' })}
            </Button>,
            <Button
              type=""default""
              key =""delete_keys""
              shape =""round""
              danger ={true}
              onClick={deleteByKeys}
            >
              <DeleteOutlined />
              {intl.formatMessage({ id: 'Permission:BatchDelete', defaultMessage: '批量禁用' })}
            </Button>,
          ]}
          search={{
            labelWidth: 100,
            searchText: intl.formatMessage({
              id: 'ProTable.search.searchText',
              defaultMessage: '查询',
            }),
            resetText: intl.formatMessage({
              id: 'ProTable.search.resetText',
              defaultMessage: '重置',
            }),
          }}
        />
      </PageContainer>");
            stringBuilder.AppendLine(@"
<OperationModalOrganizationUnit
        detail={detailOperation}
        visible={visibleOperation}
        current={currentOperation}
        onCancel={onCancelOperation}
        onSubmit={onSubmitOperation}
      />
    </>
  );
");
            stringBuilder.AppendLine("};");
            stringBuilder.AppendLine($"export default {ComponentName};");
            return stringBuilder.ToString();
        }
    }
}
