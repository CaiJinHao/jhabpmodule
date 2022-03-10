namespace Jh.Abp.Application.Contracts
{
    public interface IMethodDto<TEntity>
    {
        /// <summary>
        /// app service method query dto
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        MethodDto<TEntity> MethodInput { get; set; }
    }
}
