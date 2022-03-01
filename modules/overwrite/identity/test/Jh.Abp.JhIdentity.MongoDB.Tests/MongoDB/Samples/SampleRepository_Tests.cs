using Jh.Abp.JhIdentity.Samples;
using Xunit;

namespace Jh.Abp.JhIdentity.MongoDB.Samples;

[Collection(MongoTestCollection.Name)]
public class SampleRepository_Tests : SampleRepository_Tests<JhIdentityMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
}
