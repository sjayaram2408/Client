using Client.Models;
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
                    Id = "2312694348987835",
                    AccessToken = "exampleAccessToken",
                    CustomAudienceId = "exampleCustomAudienceId"
                },
                AddressId = 1,
                Description = "Testing to get custom response fields",
                Name = "Test_fields",
                SiteId = 3,
                UseMock = false
            };
            
            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjVFMDJSYnBLZHhEZ0tWczlMSVhRN3lQcXFhOCIsImtpZCI6IjVFMDJSYnBLZHhEZ0tWczlMSVhRN3lQcXFhOCJ9.eyJpc3MiOiJodHRwczovL2xvY2FsLmRlYWxlcnNvY2tldC5jb20iLCJhdWQiOiJodHRwczovL2xvY2FsLmRlYWxlcnNvY2tldC5jb20vcmVzb3VyY2VzIiwiZXhwIjoxNTg1NjQ4MjYyLCJuYmYiOjE1ODU2NDEwNjIsImNsaWVudF9pZCI6ImNybV9ibGFja2JpcmQiLCJzY29wZSI6WyJvcGVuaWQiLCJwcm9maWxlIiwiZW1haWwiLCJibGFja2JpcmQiLCJzZWFyY2giLCJhcGkiXSwic3ViIjoiMTAwMDk3IiwiYXV0aF90aW1lIjoxNTg1NjQxMDU5LCJpZHAiOiJpZHNydiIsImNybV9yb2xlIjoiYWRtaW4iLCJhZG1pbl9yb2xlIjoic3NvIiwiY3JtX3VzZXJuYW1lIjoiZnNhZmFpciIsImNybV9zdWIiOiJmc2FmYWlyIiwicHJvZHVjdCI6ImNybSIsImFtciI6WyJwYXNzd29yZCJdfQ.Qmmu_GVov0y5vdGnXd_f0kPM6OoY7zsR1POULJJC8iBGIh9_BtpwGwx_c1YxdgXqjZlBcEkdCL1Io3EzeQDn_S7he8YyuNLJm5VADyKP3MsGAftHjAgujlFTqh_jByBzjizQ1wUAkwsUWrwElnbtiWDOOHpyXeCys7HLRehFqHWxTdVM2Roj7cSflJZuZYiTrKniPXUiJf9hAokFBq6a3NMhzB1a6fRh4dGdwx4umaIWZIQprXtKJQecFmyYNiYHidCW5E9vDLRVuh-qqlYCuZssJ4p7ScEndwaQMzaHsPg2Yx1u43396yF8olp9BlLXYND7uhfejTy0PSAgehTKHQ");
            var stringContent = new StringContent(JsonConvert.SerializeObject(facebookAudienceManager), Encoding.UTF8, "application/json");
            var response = await apiClient.PostAsync("https://localhost:5001/Facebook", stringContent);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }
    }
}
