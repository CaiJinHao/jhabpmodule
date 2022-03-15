namespace Jh.Abp.Application.Contracts
{
    public interface IEntityPropertySetter
    {
        void SetTenantProperties(object targetObject);
    }
}
