using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jh.SourceGenerator.Common
{
    public class ReactAntdListCodeBuilder : CodeBuilderBase
    {
        //创建的Dto的所有字段
        //输出的Dto的所有字段
        protected Type DomainType { get; }
        protected string ModuleNamespace { get; }
        protected string JhModuleName { get; set; }
        protected GeneratorService GeneratorService { get;  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainType">Domain类</param>
        /// <param name="filePath">生成的临时文件夹</param>
        /// <param name="moduleNamespace">Dto命名空间</param>
        /// <param name="jhModuleName">后台模块名称，一般问数据库连接名,给本地化使用</param>
        /// <param name="generatorType">如何生成属性</param>
        public ReactAntdListCodeBuilder(Type domainType, string filePath, string moduleNamespace,string jhModuleName, GneratorType generatorType)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FilePath = Path.Combine(filePath, $"pages/{domainType.Name}");//以表名称为上级文件名创建路径
            }
            FileName = "index";
            Suffix = ".tsx";
            DomainType = domainType;
            JhModuleName = jhModuleName;
            ModuleNamespace = moduleNamespace;

            GeneratorService = new GeneratorService(generatorType);
        }

        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine(@"
import { useState, useRef, useEffect, useMemo } from 'react';
import type { ProColumns, ActionType } from '@ant-design/pro-table';
import { PageContainer } from '@ant-design/pro-layout';
import { Button, Switch, message, Modal } from 'antd';
import ProTable from '@ant-design/pro-table';
import { PlusOutlined, DeleteOutlined, ExclamationCircleOutlined } from '@ant-design/icons';
import { getYesOrNo, ViewOperator } from '@/services/jhabp/app.enums';
import { useAccess, useIntl } from 'umi';
");
            var operationModalName = $"OperationModal{DomainType.Name}";//操作ModalName
            stringBuilder.AppendLine($"import * as defaultService from '@/services/jhabp/{JhModuleName}/{DomainType.Name}/{DomainType.Name.ToLower()}.service';");
            stringBuilder.AppendLine($"import {operationModalName} from './components/OperationModal';");

            var permissionName = $"{JhModuleName}.{DomainType.Name}s";
            var ComponentName = $"{DomainType.Name}List";//组件名称
            var ComponentDtoName = $"{ModuleNamespace}.{DomainType.Name}Dto";//组件Dto
            stringBuilder.AppendLine($"const {ComponentName} = () => {{");

            stringBuilder.AppendLine(@"
  const access = useAccess();
  const [visibleOperation, setVisibleOperation] = useState<boolean>(false);
  const [detailOperation, setDetailOperation] = useState<ViewOperator>(ViewOperator.Detail);
  const { confirm } = Modal;
  const intl = useIntl();
  const proTableActionRef = useRef<ActionType>();
  const [totalPage, setTotalPage] = useState(0);
  const [selectedRowKeys, setSelectedRowKeys] = useState([]);
  const [yesOrNoOptions, setYesOrNoOptions] = useState([]);
");
            stringBuilder.AppendLine($"  const [currentOperation, setCurrentOperation] = useState<{ComponentDtoName} | undefined>(undefined);");
            stringBuilder.AppendLine(@"  const reloadProTable = () => {
    proTableActionRef.current?.reload();
  };");
            stringBuilder.AppendLine(@"
  const requestYesOrNoOptions = async () => {
    if (yesOrNoOptions.length == 0) {
      const data = await getYesOrNo();
      setYesOrNoOptions(data);
      return data;
    }
    return yesOrNoOptions;
  };
");
            stringBuilder.AppendLine($"const handlerIsDeleted = async (record: {ComponentDtoName}, action: any) => {{");
                stringBuilder.AppendLine(@"if (record.isDeleted) {
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
          reloadProTable();
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
          reloadProTable();
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
    reloadProTable();
  };

  const create = () => {
    setDetailOperation(ViewOperator.Add);
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
          reloadProTable();
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
            stringBuilder.AppendLine($"const loadDetail = async (record: {ComponentDtoName}) => {{");
            stringBuilder.AppendLine(@"setVisibleOperation(true);
    const detailDto = await defaultService.Get(record.id);//如果有额外得字段才会需要重新获取,否则可以直接使用record传递
    setCurrentOperation(detailDto);
  };");
            stringBuilder.AppendLine($"const edit = async (record: {ComponentDtoName}) => {{");
            stringBuilder.AppendLine(@"setDetailOperation(ViewOperator.Edit);
    await loadDetail(record);
  };");
            stringBuilder.AppendLine($"const detail = async (record: {ComponentDtoName}) => {{");
            stringBuilder.AppendLine(@"setDetailOperation(ViewOperator.Detail);
    await loadDetail(record);
  };");
            stringBuilder.AppendLine(@"
  useEffect(() => {
    setCurrentOperation(undefined);
  }, [visibleOperation]);
");
            var displayName = new StringBuilder();
            stringBuilder.AppendLine($"const columns: ProColumns<{ComponentDtoName}>[] = [");
            //循环创建所有字段
            foreach (var item in GeneratorService.GetFieldDto(GeneratorService.GetMembers<GeneratorAttributes.CreateOrUpdateInputDtoAttribute>(DomainType)))
            {
                var fieldName = item.Name;
                var fieldDescription = item.Description;
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine($"title: intl.formatMessage({{id: 'DisplayName:{DomainType.Name}:{fieldName}',defaultMessage: '{fieldDescription}',}}),dataIndex: '{fieldName.ToCamelCase(CamelCaseType.LowerCamelCase)}',");
                stringBuilder.AppendLine("},");
                displayName.AppendLine($"\"DisplayName:{DomainType.Name}:{fieldName}\": \"{fieldDescription}\",");
            }

            stringBuilder.AppendLine(@"{
      title: intl.formatMessage({ id: 'JhAbp:IsDeleted', defaultMessage: '是否删除' }),
      dataIndex: 'isDeleted',
      search: false,
      render: (text, record, index, action) => {
        return (
            <Switch disabled={");
          stringBuilder.AppendLine($"!(access['{permissionName}.Recover'] &&access['{permissionName}.Delete'])");
            stringBuilder.AppendLine(@");
} checked={record.isDeleted} onChange={() => handlerIsDeleted(record, action)} />
      },
    },
    {
      title: intl.formatMessage({ id: 'JhAbp:CreationTime', defaultMessage: '创建时间' }),
      dataIndex: 'creationTime',
      valueType: 'dateTime',
      search: false,
      sorter: true,
    },");
            stringBuilder.AppendLine(@"{
      title: intl.formatMessage({ id: 'JhAbp:Operation', defaultMessage: '操作' }),
      key: 'option',
      valueType: 'option',
      render: (_, record) =>
        !record.isDeleted && [");
            stringBuilder.AppendLine(@$"access['{permissionName}.Update'] && (");
            stringBuilder.AppendLine(@"<a key=""edit"" onClick={() => edit(record)}>
            { intl.formatMessage({ id: 'Permission:Edit', defaultMessage: '编辑' })}
          </a>),
          <a key = ""detail"" onClick ={ () => detail(record)}>
            { intl.formatMessage({ id: 'Permission:Detail', defaultMessage: '详情' })}
          </a>,
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
  const getTableDataSource = async (params: any, sorter: any) => {
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

            stringBuilder.AppendLine(@"  const toolBarRender = useMemo(() => {
    return [");
            stringBuilder.AppendLine(@$"access['{permissionName}.Create'] && ( ");
            stringBuilder.AppendLine(@"<Button type=""primary"" key =""create"" shape =""round"" onClick ={create}>
              <PlusOutlined />
              {intl.formatMessage({ id: 'Permission:Create', defaultMessage: '创建' })}
            </Button>),");
            stringBuilder.AppendLine(@$"access['{permissionName}.BatchDelete'] && ( ");
            stringBuilder.AppendLine(@"<Button type=""default"" key =""delete_keys"" shape =""round"" danger ={true} onClick={deleteByKeys}>
          <DeleteOutlined />
          {intl.formatMessage({
            id: 'Permission:BatchDelete',
            defaultMessage: '批量删除',
          })}
        </Button>
      ),");
            stringBuilder.AppendLine(@"];
  }, [access, intl]);

    const tableSearch = useMemo(() => {
    return {
      labelWidth: 100,
      searchText: intl.formatMessage({
        id: 'proTable.search.searchText',
        defaultMessage: '查询',
      }),
      resetText: intl.formatMessage({
        id: 'proTable.search.resetText',
        defaultMessage: '重置',
      }),
    };
  }, [intl]);");


            stringBuilder.AppendLine(@"
  return (
    <>
      <PageContainer>");
            stringBuilder.AppendLine($"<ProTable<{ComponentDtoName}>");
            stringBuilder.AppendLine(@"actionRef={proTableActionRef}
          columns={columns}
          rowSelection={rowSelection}
          request={(params, sorter) => getTableDataSource(params, sorter)}
          rowKey=""id""
          pagination={{
            pageSize: 10,
            total: totalPage,
          }}
          dateFormatter=""string""
          toolBarRender={() => toolBarRender}
          search={tableSearch}
        />
      </PageContainer>");

            stringBuilder.AppendLine($"<OperationModal{DomainType.Name}");
            stringBuilder.AppendLine(@"operator={detailOperation}
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

            stringBuilder.AppendLine("/* 后台本地化显示配置");
            stringBuilder.AppendLine(displayName.ToString());
            stringBuilder.AppendLine("*/");
            return stringBuilder.ToString();
        }
    }
}
