using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Jh.Abp.JhIdentity.Samples;

public class SampleManager_Tests : JhIdentityDomainTestBase
{
    //private readonly SampleManager _sampleManager;

    public SampleManager_Tests()
    {
        //_sampleManager = GetRequiredService<SampleManager>();
    }

    [Fact]
    public async Task Method1Async()
    {
        var _repository = GetRequiredService<IIdentityUserRepository>();
        var data= await _repository.FindAsync(new Guid("3a02751d-396f-d768-9f76-ab89edf150d4"),true);
        data.ShouldNotBeNull();
    }
}
