using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace FlexibleMVC.Base.Jwt
{
    public class JwtUtil
    {
        /// <summary>
        /// 私钥
        /// </summary>
        public const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        //标准中注册的声明 (建议但不强制使用) 
        public const string iss = "iss"; // jwt签发者
        public const string sub = "sub"; //jwt所面向的用户
        public const string aud = "aud"; //接收jwt的一方
        public const string exp = "exp"; //jwt的过期时间，这个过期时间必须要大于签发时间
        public const string nbf = "nbf"; //定义在什么时间之前，该jwt都是不可用的.
        public const string iat = "iat"; //jwt的签发时间
        public const string jti = "jti"; //jwt的唯一身份标识，主要用来作为一次性token,从而回避重放攻击。

        /// <summary>
        /// jwt的第三部分是一个签证信息，这个签证信息由三部分组成：
        /// 1、header (base64后的)
        /// 2、payload (base64后的)
        /// 3、signature (这个部分需要base64加密后的header和base64加密后的payload使用.连接组成的字符串，然后通过header中声明的加密方式进行加secret组合加密，然后就构成了jwt的第三部分)
        /// 将这三部分用.连接成一个完整的字符串,构成了最终的jwt
        /// </summary>
        /// <param name="payload">载荷, 就是存放有效信息的地方</param>
        /// <param name="expire">过期时间, 单位：秒</param>
        /// <returns></returns>
        public static string Encode(Dictionary<string, object> payload, double expire = 0)
        {
            //var payload = new Dictionary<string, object>
            //{
            //    { "claim1", 0 },
            //    { "claim2", "claim2-value" }
            //};

            if (expire != 0)
            {
                //添加过期时间
                IDateTimeProvider provider = new UtcDateTimeProvider();
                var now = provider.GetNow();

                var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
                var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds) + expire;
                if (payload.ContainsKey(exp))
                    payload[exp] = secondsSinceEpoch;
                else
                    payload.Add(exp, secondsSinceEpoch);
            }


            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new CustomJsonSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }

        public static JwtResult Decode(string token)
        {
            //var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGFpbTEiOjAsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.8pwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-5kM5s";
            JwtResult jwtResult = new JwtResult() { Success = true};
            try
            {
                IJsonSerializer serializer = new CustomJsonSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.DecodeToObject(token, secret, verify: true);
                jwtResult.Result = json;
            }
            catch (TokenExpiredException)
            {
                jwtResult.Success = false;
                jwtResult.ErrInfo = "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                jwtResult.Success = false;
                jwtResult.ErrInfo = "Token has invalid signature";
            }

            return jwtResult;
        }
    }

    public class JwtResult
    {
        public bool Success { get; set; }
        public IDictionary<string, object> Result { get; set; }
        public string ErrInfo { get; set; }
    }

    public class CustomJsonSerializer : IJsonSerializer
    {
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
