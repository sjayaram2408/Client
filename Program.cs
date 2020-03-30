using DealerSocket.Crm.Integrations.FacebookAudience.Models;
using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        private static async Task Main()
        {
            //var client = new HttpClient();

            //// request token
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //{
            //    Address = "https://sso.local.dealersocket.com/connect/token",
            //    ClientId = "crm_campaign_api"
            //});

            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //    return;
            //}

            //Console.WriteLine(tokenResponse.Json);
            //Console.WriteLine("\n\n");
            AudienceManager facebookAudienceManager = new AudienceManager
            {
                Account = new Account
                {
                    Id = "exampleAdAccountId",
                    AccessToken = "exampleAccessToken",
                    CustomAudienceId = "exampleCustomAudienceId"
                },
                AddressId = 1,
                Description = "exampleDescription",
                Name = "exampleName",
                SiteId = 3,
                UseMock = true
            };
            
            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjVFMDJSYnBLZHhEZ0tWczlMSVhRN3lQcXFhOCIsImtpZCI6IjVFMDJSYnBLZHhEZ0tWczlMSVhRN3lQcXFhOCJ9.eyJpc3MiOiJodHRwczovL2xvY2FsLmRlYWxlcnNvY2tldC5jb20iLCJhdWQiOiJodHRwczovL2xvY2FsLmRlYWxlcnNvY2tldC5jb20vcmVzb3VyY2VzIiwiZXhwIjoxNTg1NTgwNzczLCJuYmYiOjE1ODU1NzM1NzMsImNsaWVudF9pZCI6ImNybV9ibGFja2JpcmQiLCJzY29wZSI6WyJvcGVuaWQiLCJwcm9maWxlIiwiZW1haWwiLCJibGFja2JpcmQiLCJzZWFyY2giLCJhcGkiXSwic3ViIjoiMTAwMDk3IiwiYXV0aF90aW1lIjoxNTg1NTY2MzgyLCJpZHAiOiJpZHNydiIsImNybV9yb2xlIjoiYWRtaW4iLCJhZG1pbl9yb2xlIjoic3NvIiwiY3JtX3VzZXJuYW1lIjoiZnNhZmFpciIsImNybV9zdWIiOiJmc2FmYWlyIiwicHJvZHVjdCI6ImNybSIsImFtciI6WyJwYXNzd29yZCJdfQ.LWSvQNn7E2Bk37xJmLhq7-OrAznK12t3WAopnsQjpdHB2hbFiwI5qzftuXQPlCQ1BzDz6Z7y2lGs5c7Bv7D_SjdP8dIJmkOISbrJjAtbDQafvGuKXf0d-hBZAHCnckUD42OTL4piNo5JF4Hz-Y7brE9B3_axVHwmogundH20ZqTaRIvQg60f4y0KRBj3ZT8GGpBg7D95kTf1rJ0d7DBAk64nNwgJz1G--xrG2E8uky9-HeGIDrN7twnrEDNAJeQpmixr6xfb8uTNFI11PFN51GKERM9A1priINVeOOzcuGeXOq9em3g6PMpJ4NU9UEmFMNw12GstZqn-Npak5SguHQ");
            var stringContent = new StringContent(JsonConvert.SerializeObject(facebookAudienceManager), Encoding.UTF8, "application/json");
            var response = await apiClient.PostAsync("https://localhost:5001/Facebook", stringContent);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
