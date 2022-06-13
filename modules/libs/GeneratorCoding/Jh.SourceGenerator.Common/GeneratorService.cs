using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Jh.SourceGenerator.Common.GeneratorAttributes;
using Jh.SourceGenerator.Common.GeneratorDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Jh.SourceGenerator.Common.CodeBuilders;
using System.IO;
using Jh.Abp.Common;

namespace Jh.SourceGenerator.Common
{
    public class GeneratorService
    {
        private GeneratorOptions generatorOptions { get; }
        private Assembly LoadAssembly { get; }
        private GneratorType generatorType { get; }
        public GeneratorService(Assembly assembly, GeneratorOptions options, GneratorType _gneratorType = GneratorType.AttributeField)
        {
            LoadAssembly = assembly;
            generatorOptions = options;
            generatorType = _gneratorType;
            GeneratorConsts.DbContext = options.DbContext;
            GeneratorConsts.Namespace = options.Namespace;
            GeneratorConsts.ControllerBase = options.ControllerBase;
        }

        public GeneratorService(GeneratorOptions options, GneratorType _gneratorType = GneratorType.AttributeField)
        { 
            generatorOptions = options;
            generatorType = _gneratorType;
        }

        public GeneratorService(GneratorType _gneratorType)
        {
            generatorType = _gneratorType;
        }
        public GeneratorService()
        {
        }

        public virtual IEnumerable<Type> GetLoadableTypes()
        {
            return LoadAssembly.DefinedTypes.Select((TypeInfo t) => t.AsType());
        }

        /// <summary>
        /// 根据GeneratorClass特性来插座要生成得表
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Type> GetTableClassByGeneratorClass()
        {
            var classCollection = GetLoadableTypes().Where(cla => cla.IsClass);
            var tableClass = classCollection.Where(tab => tab.CustomAttributes.Any(a => a.AttributeType.Equals(typeof(GeneratorClassAttribute))));
            return tableClass;
        }

        public virtual IEnumerable<Type> GetTableClassByGeneratorClass(Type AssignableTo)
        {
            return GetLoadableTypes().Where(cla => cla.IsClass && AssignableTo.IsAssignableFrom(cla)).ToArray();
        }

        public virtual IEnumerable<TableDto> GetTablesDto(IEnumerable<Type> classTypes)
        {
            foreach (var classType in classTypes)
            {
                yield return new TableDto(GeneratorConsts.DbContext, GeneratorConsts.Namespace, GeneratorConsts.ControllerBase)
                {
                    Name = GetTableName(classType),
                    KeyType = GetKeyType(classType),
                    InheritClass = GetTableInheritClass(classType),
                    Comment = GetTableDescription(classType),
                    FieldsCreateOrUpdateInput = GetFieldDto(GetMembers<CreateOrUpdateInputDtoAttribute>(classType)).ToList(),
                    FieldsRetrieve = GetFieldDto(GetMembers<RetrieveDtoAttribute>(classType)).ToList(),
                    FieldsIgnore = GetFieldDto(GetMembers<ProfileIgnoreAttribute>(classType)).ToList(),
                };
            }
        }

        public virtual TableDto GetTableDto(Type classType)
        {
            return new TableDto(GeneratorConsts.DbContext, GeneratorConsts.Namespace, GeneratorConsts.ControllerBase)
            {
                Name = GetTableName(classType),
                KeyType = GetKeyType(classType),
                InheritClass = GetTableInheritClass(classType),
                Comment = GetTableDescription(classType),
                FieldsCreateOrUpdateInput = GetFieldDto(GetMembers<CreateOrUpdateInputDtoAttribute>(classType)).ToList(),
                FieldsRetrieve = GetFieldDto(GetMembers<RetrieveDtoAttribute>(classType)).ToList(),
                FieldsIgnore = GetFieldDto(GetMembers<ProfileIgnoreAttribute>(classType)).ToList(),
            };
        }

        public virtual string GetTableName(Type classType)
        {
            return classType.Name;
        }

        public virtual string GetKeyType(Type classType)
        {
            var baseType = classType.BaseType;
            var genericTypeArgs = baseType.GenericTypeArguments;
            return genericTypeArgs.FirstOrDefault()?.ToString();
        }

        public virtual string GetTableInheritClass(Type classType)
        {
            return classType.BaseType.Name.Replace("`1", "");
        }

        public virtual string GetTableDescription(Type classType)
        {
            var attr = classType.CustomAttributes.Where(a => a.AttributeType.Equals(typeof(DescriptionAttribute))).FirstOrDefault();
            if (attr != null)
            {
                var args = attr.ConstructorArguments.FirstOrDefault();
                if (args != null)
                {
                    return args.Value?.ToString();
                }
            }
            return default;
        }


        public virtual IEnumerable<PropertyInfo> GetMembers<TAttribute>(Type classType)
        {
            switch (generatorType)
            {
                case GneratorType.AllField:
                    {

                        return classType.GetProperties().Where(property =>
                         property.DeclaringType == classType
                         && !(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition().Equals(typeof(ICollection<>)))
                        );
                    }
                case GneratorType.AttributeField:
                default:
                    return classType.GetProperties().Where(property => property.CustomAttributes.Any(a => a.AttributeType.Equals(typeof(TAttribute))));
            }
            //已改写为lamda
            //foreach (var property in classType.GetProperties())
            //{
            //    var attrName = typeof(TAttribute).Name;
            //    if (property.CustomAttributes.Any(a => a.AttributeType.Equals(typeof(TAttribute))))
            //    {
            //        yield return property;
            //    }
            //}
        }

        public virtual IEnumerable<FieldDto> GetFieldDto(IEnumerable<PropertyInfo> properties)
        {
            return properties.Select(property =>
            {
                var descriptionAttr = GetAttrArgs<DescriptionAttribute>(property)?.FirstOrDefault();
                var description = string.Empty;
                if (descriptionAttr != null)
                {
                    description = descriptionAttr?.Value?.ToString();
                }
                var required = GetAttr<RequiredAttribute>(property);
                var theType = property.PropertyType;
                var fieldDto = new FieldDto()
                {
                    Name = GetFiledName(property),
                    Description = description,
                    Type = theType.Name,
                    FieldType = theType.GetObjectType(),
                    IsRequired = required != null
                };
                if (theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    fieldDto.IsNullable = true;
                    fieldDto.Type = theType.GetGenericArguments().FirstOrDefault().Name;
                    fieldDto.IsRequired = false;
                }
                fieldDto.IsNullable = fieldDto.GetIsNullable();
                return fieldDto;
            });
        }

        /// <summary>
        /// 获取指定特性
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public virtual CustomAttributeData GetAttr<TAttribute>(PropertyInfo property)
        {
            return property.CustomAttributes
                .Where(a => a.AttributeType.Equals(typeof(TAttribute))).FirstOrDefault();
        }

        public virtual IEnumerable<CustomAttributeTypedArgument> GetAttrArgs<TAttribute>(PropertyInfo property)
        {
            var attr = property.CustomAttributes
                .Where(a => a.AttributeType.Equals(typeof(TAttribute))).FirstOrDefault();
            if (attr == null)
            {
                return default;
            }
            return attr.ConstructorArguments.AsEnumerable();
        }

        public virtual string GetFiledName(PropertyInfo property)
        {
            return property.Name;
        }

        public virtual bool GeneratorCode(IEnumerable<Type> tableClass)
        {
            if (!tableClass.Any())
            {
                throw new Exception("The identity GeneratorClass was not found");
            }
            var tables = GetTablesDto(tableClass);
            CreateFile(new PermissionsCodeBuilder(tables, generatorOptions.CreateContractsPermissionsPath));
            CreateFile(new PermissionsDefinitionProviderCodeBuilder(tables, generatorOptions.CreateContractsPermissionsPath));
            foreach (var tableDto in tables)
            {
                //contracts
                CreateFile(new CreateInputDtoCodeBuilder(tableDto, generatorOptions.CreateContractsPath));
                CreateFile(new RetrieveInputDtoCodeBuilder(tableDto, generatorOptions.CreateContractsPath));
                CreateFile(new DeleteInputDtoCodeBuilder(tableDto, generatorOptions.CreateContractsPath));
                CreateFile(new UpdateInputDtoCodeBuilder(tableDto, generatorOptions.CreateContractsPath));
                CreateFile(new DomainDtoCodeBuilder(tableDto, generatorOptions.CreateContractsPath));
                CreateFile(new IAppServiceCodeBuilder(tableDto, generatorOptions.CreateContractsPath));

                //Domain
                CreateFile(new IDapperRepositoryCodeBuilder(tableDto, generatorOptions.CreateDomainPath));
                CreateFile(new IRepositoryCodeBuilder(tableDto, generatorOptions.CreateDomainPath));
                CreateFile(new DomainManager(tableDto, generatorOptions.CreateDomainPath));
                CreateFile(new DataSeedContributor(tableDto, generatorOptions.CreateDomainPath));

                //EfCore
                //CreateFile(new DapperRepositoryCodeBuilder(tableDto, generatorOptions.CreateEfCorePath));//使用频率不高，不再自动生成，需要手动
                CreateFile(new RepositoryCodeBuilder(tableDto, generatorOptions.CreateEfCorePath));

                //Application
                CreateFile(new AppServiceCodeBuilder(tableDto, generatorOptions.CreateApplicationPath));
                CreateFile(new ProfileCodeBuilder(tableDto, generatorOptions.CreateApplicationPath));

                //HttpApi
                CreateFile(new ControllerCodeBuilder(tableDto, generatorOptions.CreateHttpApiPath));

                //Html
                //获取去模板列表
                if (!string.IsNullOrEmpty(generatorOptions.CreateHtmlTemplatePath))
                {
                    foreach (var file in new DirectoryInfo(generatorOptions.CreateHtmlTemplatePath).GetFiles())
                    {
                        if (file.Extension.Equals(".cshtml"))
                        {
                            var _filePath = Path.Combine(generatorOptions.CreateHtmlTemplatePath, file.FullName);
                            CreateFile(new HtmlTemplateCodeBuilder(_filePath, tableDto, generatorOptions.CreateHtmlPath));
                        }
                    }
                }
            }
            return true;
        }

        public virtual bool CreateFile(CodeBuilderBase codeBuilder)
        {
            if (!string.IsNullOrEmpty(codeBuilder.FilePath))
            {
                new DirectoryInfo(codeBuilder.FilePath).CreateDirectoryInfo();
                var filePath = Path.Combine(codeBuilder.FilePath, codeBuilder.FileName + codeBuilder.Suffix);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, codeBuilder.ToString());
            }
            return true;
        }

        protected virtual bool CreateFile(string moduleNamespace, Dictionary<string,ProxyServiceModelCodeBuilder> codeBuilders,string FilePath,string FileName, string Suffix)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                new DirectoryInfo(FilePath).CreateDirectoryInfo();
                var filePath = Path.Combine(FilePath, FileName + Suffix);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var content = new StringBuilder();
                content.AppendLine($"declare namespace {moduleNamespace} {{");
                foreach (var item in codeBuilders)
                {
                    content.AppendLine(item.Value.ToString());
                }
                content.AppendLine("}");

                File.WriteAllText(filePath, content.ToString());
            }
            return true;
        }

        #region antd前端生成

        /// <summary>
        /// api版本注意从上往下，取最后一个
        /// </summary>
        public virtual void GeneratorCodeByAppService(string moduleNamespace, string globalNamespace, string proxyName, IEnumerable<Type> controllerTypes)
        {
            foreach (var item in controllerTypes)
            {
                GeneratorHelper.InitialProxyServceModelCodeBuilders();
                var service = new ProxyServiceCodeBuilder(item, generatorOptions.CreateProxyServicePath, moduleNamespace, globalNamespace, proxyName);
                CreateFile(service);
                //创建service中所有的dto对象及参数对象
                CreateFile(moduleNamespace, GeneratorHelper.GetProxyServiceModelCodeBuilders(), service.FilePath, $"model.{service.FileName}", ".d.ts");
            }
        }

        public virtual void GeneratorCodeByTsx(string moduleNamespace, IEnumerable<Type> domainTypes,string jhModuleName)
        {
            foreach (var item in domainTypes)
            {
                CreateFile(new ReactAntdListCodeBuilder(item, generatorOptions.CreateProxyServicePath, moduleNamespace, jhModuleName, generatorType));
                CreateFile(new ReactAntdEditCodeBuilder(item, generatorOptions.CreateProxyServicePath, moduleNamespace, GetTableDescription(item), generatorType));
            }
        }

        #endregion
    }
}
