namespace Jh.Abp.Domain
{
    public interface IEntityPropertySetter
    {
        void SetTenantProperties(object targetObject);
    }
}
