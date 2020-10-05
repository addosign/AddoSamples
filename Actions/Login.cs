using System;
using System.Security.Cryptography;
using System.Text;
using AddoSamples.DomainModel;
using AddoSamples.Http;
using AddoSamples.RequestModels;
using Newtonsoft.Json;

namespace AddoSamples.Actions
{
    public class Login
    {
        readonly Context _context;

        public Login(Context context)
        {
            _context = context;
        }

        public void Execute(string email, string password)
        {
            var model = new LoginModel
            {
                email = email,
                password = HashedPassword(password),
            };

            var url = $"{_context.BaseUrl}/Login";
            var body = JsonConvert.SerializeObject(model);
            var result = new Post().Execute(url, body).Result;
            var token = JsonConvert.DeserializeObject<string>(Encoding.UTF8.GetString(result));
            if (token == Guid.Empty.ToString())
            {
                throw new Exception("Invalid email / password");
            }

            _context.Token = token;
        }

        string HashedPassword(string password)
        {
            using (var sha512 = new SHA512Managed())
            {
                var pwdBytes = Encoding.UTF8.GetBytes(password);
                var hash = sha512.ComputeHash(pwdBytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}