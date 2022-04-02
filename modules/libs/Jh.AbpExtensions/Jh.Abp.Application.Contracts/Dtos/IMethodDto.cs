namespace Jh.Abp.Application.Contracts
{
    public interface IMethodDto<TEntity>
    {
        /// <summary>
        /// app service method query dto
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        MethodDto<TEntity> MethodInput { get; set; }
    }
}
