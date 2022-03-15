using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NETCore.Encrypt;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Jh.Abp.Pay.Samples
{
    public class YiLiangTest : PayApplicationTestBase
    {
        private const string AppId = "10037e6f6a4e6da4016a670fd4530012";
        private const string AppKey = "f7a74b6c02ae4e1e94aaba311c04acf2";
        private const string Mid = "898310060514001";//898310148160568,898310060514001
        private const string Tid = "88880001";
        [Fact]
        public async Task TestYiLiangH5()
        {
            var time = DateTime.Now;
            var authorization = "OPEN-FORM-PARAM";
            var timestamp = time.ToString("yyyyMMddHHmmss");
            var nonce = Guid.NewGuid().ToString("n").Substring(0,20);
            var data = new
            {
                requestTimestamp = time.ToString("yyyy-MM-dd HH:mm:ss"),
                merOrderId = Guid.NewGuid().ToString("n").Substring(0, 20),
                mid = Mid,
                tid = Tid,
                instMid = "H5DEFAULT",
                subOrders = new List<dynamic>() {
                    new {
                        mid="988460101800202",
                        totalAmount=10
                        }
                },
                totalAmount = 10,//分
            };
            var content = JsonConvert.SerializeObject(data);//json
            var sha256_hex = EncryptProvider.Sha256(content);
            var hashed = HmacSHA256(AppId + timestamp + nonce + sha256_hex, AppKey);
            var sign2 = Convert.ToBase64String(hashed);
            var query= $"appId={AppId}&timestamp={timestamp}&nonce={nonce}&content={content}&signature={sign2}";
            var wxUrl = "https://test-api-open.chinaums.com/v1/netpay/wxpay/h5-pay?" + WebUtility.UrlEncode(query);
            var aliUrl = "https://test-api-open.chinaums.com/v1/netpay/trade/h5-pay" + WebUtility.UrlEncode(query);
            aliUrl.ShouldNotBeNullOrWhiteSpace();
        }


        public virtual byte[] HmacSHA256(string srcString, string key)
        {
            byte[] secrectKey = Encoding.UTF8.GetBytes(key);
            using (HMACSHA256 hmac = new HMACSHA256(secrectKey))
            {
                hmac.Initialize();

                byte[] bytes_hmac_in = Encoding.UTF8.GetBytes(srcString);
                byte[] bytes_hamc_out = hmac.ComputeHash(bytes_hmac_in);
                return bytes_hamc_out;
            }
        }

        public virtual string SHA256_HEX(string content)
        {
            return "";
        }
    }
}
