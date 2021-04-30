using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.CommanUtilities.Authentication
{
    public class JWT_Provider : IDisposable
    {
        const string _secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        IJwtEncoder _encoder = null;
        IJwtDecoder _decoder = null;


        IJwtAlgorithm _algorithm = null;
        IJsonSerializer _serializer = null;
        IBase64UrlEncoder _urlEncoder = null;
        IDateTimeProvider _provider = null;
        IJwtValidator _validator = null;

        public JWT_Provider()
        {
            _algorithm = new HMACSHA256Algorithm();
            _serializer = new JsonNetSerializer();
            _urlEncoder = new JwtBase64UrlEncoder();
            _encoder = new JwtEncoder(_algorithm, _serializer, _urlEncoder);


            _provider = new UtcDateTimeProvider();
            _validator = new JwtValidator(_serializer, _provider);
            _decoder = new JwtDecoder(_serializer, _validator, _urlEncoder, _algorithm);

        }

        public string Generate_FrontEnd_Token(FrontEnd_JWTInfo payload)
        {

            var token = _encoder.Encode(payload, _secret);

            return token;
        }

        public string Generate_BackEnd_Token(BackEnd_JWTInfo payload)
        {

            var token = _encoder.Encode(payload, _secret);

            return token;
        }

        public bool Verify_Token(string token)
        {

            bool flag = false;

            try
            {
                var json = _decoder.Decode(token, _secret, verify: true);

                Console.WriteLine(json);

                flag = true;
            }
            catch (Exception ex)
            {
                // Log in DB
                Console.WriteLine("Illegal base64 exception");
            }

            return flag;
        }

        public FrontEnd_JWTInfo Decode_FrontEnd_Token(string token)
        {

            FrontEnd_JWTInfo retVal = null;

            try
            {
                retVal = _decoder.DecodeToObject<FrontEnd_JWTInfo>(token, _secret, verify: true);
            }
        
            catch (Exception ex)
            {
                // Log in DB
                Console.WriteLine("Illegal base64 exception");
            }

            return retVal;
        }


        public BackEnd_JWTInfo Decode_BackEnd_JWTInfoToken(string token)
        {

            BackEnd_JWTInfo retVal = null;

            try
            {
                retVal = _decoder.DecodeToObject<BackEnd_JWTInfo>(token, _secret, verify: true);
            }
            catch (Exception ex)
            {
                // Log in DB
                Console.WriteLine("Illegal base64 exception");
            }

            return retVal;
        }

        public void Dispose()
        {
            _encoder = null;
            _decoder = null;

            _algorithm = null;
            _serializer = null;
            _urlEncoder = null;

            _provider = null;
            _validator = null;
        }
    }
}