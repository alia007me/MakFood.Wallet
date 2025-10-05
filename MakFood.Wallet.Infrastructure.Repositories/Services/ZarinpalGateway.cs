using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.ServiceContracts;
using MakFood.Wallet.Infrastructure.Repositories.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Services
{
    public class ZarinpalGateway : IZarinpalGateway
    {

        private readonly IHttpClientFactory _clientfactory;
        private readonly string _merchent_id = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
        private readonly MakFoodWalletDbContext _context;


        public ZarinpalGateway(IHttpClientFactory clientfactory, MakFoodWalletDbContext makFoodWalletDb)
        {
            _clientfactory = clientfactory;
            _context = makFoodWalletDb;
        }

        public async Task<ZarinpalRequestResponse> PayRequest(decimal Amount, string Email, string Description)
        {
            var client = _clientfactory.CreateClient();
            var request = new ZarinpalRequest()
            {
                merchant_id = _merchent_id,
                amount = Convert.ToInt32(Amount),
                callback_url = "http://localhost:5000/api/zarinpal/verify",
                description = Description,
                metadata = new { email = $"{Email}" }
            };

            var PostRequestContent = await client.PostAsJsonAsync("https://sandbox.zarinpal.com/pg/v4/payment/request.json", request);
            var result = await ReadResponseAsync<ZarinpalRequestResponse>(PostRequestContent);




            return result;
        }

        public static async Task<T?> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

            return await response.Content.ReadFromJsonAsync<T>();
        }
        public async Task<ZarinpalVerifyResponse> VerifyTransactionFromZarinpal(string authority,decimal amount)
        {
            var client = _clientfactory.CreateClient();

            var verifyRequest = new ZarinpalVerify
            {
                merchant_id = _merchent_id,
                authority = authority,
                amount = Convert.ToInt32(amount)
            };

            var response = await client.PostAsJsonAsync("https://sandbox.zarinpal.com/pg/v4/payment/verify.json", verifyRequest);
            var result = await ReadResponseAsync<ZarinpalVerifyResponse>(response);


            return result;
        }
    }
}

