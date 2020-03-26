using IdentityModel.Client;
using System;
using System.Net.Http;
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

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjVFMDJSYnBLZHhEZ0tWczlMSVhRN3lQcXFhOCIsImtpZCI6IjVFMDJSYnBLZHhEZ0tWczlMSVhRN3lQcXFhOCJ9.eyJpc3MiOiJodHRwczovL2xvY2FsLmRlYWxlcnNvY2tldC5jb20iLCJhdWQiOiJodHRwczovL2xvY2FsLmRlYWxlcnNvY2tldC5jb20vcmVzb3VyY2VzIiwiZXhwIjoxNTg1MjEwODI1LCJuYmYiOjE1ODUyMDM2MjUsImNsaWVudF9pZCI6ImNybV9ibGFja2JpcmQiLCJzY29wZSI6WyJvcGVuaWQiLCJwcm9maWxlIiwiZW1haWwiLCJibGFja2JpcmQiLCJzZWFyY2giLCJhcGkiXSwic3ViIjoiMTAwMDk3IiwiYXV0aF90aW1lIjoxNTg1MjAzNjIzLCJpZHAiOiJpZHNydiIsImNybV9yb2xlIjoiYWRtaW4iLCJhZG1pbl9yb2xlIjoic3NvIiwiY3JtX3VzZXJuYW1lIjoiZnNhZmFpciIsImNybV9zdWIiOiJmc2FmYWlyIiwicHJvZHVjdCI6ImNybSIsImFtciI6WyJwYXNzd29yZCJdfQ.ntV8KhWFPCgoXLNprID5cJXqcig00h1z-H3O16zBtzYedk3BUV2qoSoHOs4L_bw4bosTGxtz1V2BiXxIChJOhU1dOCfSQm_5ca-BbsBBKdFXjAXP2JUzX80d-078MIsbJtnq8ZK-hWjRRid0bzmMMsskWKBBSDY54MVHWLl73VTs3Sff_jAs2WrGmsLXyXviPK64nrCvLxjBQkVHj48RY8FOcYXvcmvVmn6kth1BoBkNgHQ1_zBTc05DfVnv0RZ3J2yZJALaf6CW07u90Psb3-J2H0-WiuSk3CAzfVttbm11xWTx2DXyaVrnRzp92T3aV_Z3TgjheZeOpnWcNA1-Mw");

            var response = await apiClient.GetAsync("https://localhost:5001/Identity");
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
