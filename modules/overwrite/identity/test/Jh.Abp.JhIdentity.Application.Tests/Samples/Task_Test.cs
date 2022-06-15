using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Jh.Abp.JhIdentity.Samples
{
    public class Task_Test
    {
        [Fact]
        public void TestError()
        {
            try
            {
                Error();
            }
            catch (Exception ex)
            {
                ex.ShouldNotBeNull();
            }
        }

        private void Error()
        {
            throw new Exception("错误了");
        }
    }
}
