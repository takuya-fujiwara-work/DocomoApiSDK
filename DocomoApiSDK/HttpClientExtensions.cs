using DocomoApiSDK.Dialogue;
using DocomoApiSDK.KnowledgeQA;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DocomoApiSDK
{
    public static class HttpClientExtensions
    {
        private const string DOCOMO_API_HOST = "https://api.apigw.smt.docomo.ne.jp/";
        private const string DOCOMO_API_DIALOGUE_PATH = "dialogue/v1/dialogue";
        private const string DOCOMO_API_KNOWLEDGEQA_PATH = "knowledgeQA/v1/ask";
        private const string API_KEY = "APIKEY";
        private const string Q = "q";

        public async static Task<DialogueResponse> PostDialogueRequestAsync(this HttpClient client, string apiKey, DialogueRequest request)
        {
            var response = new DialogueResponse();

            var queryString = new NameValueCollection();
            queryString[API_KEY] = apiKey;

            var path = DOCOMO_API_DIALOGUE_PATH + ToQueryString(queryString);

            client.BaseAddress = new Uri(DOCOMO_API_HOST);
            client.DefaultRequestHeaders
                .Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var serReq = new DataContractJsonSerializer(typeof(DialogueRequest));

            using (var ms = new MemoryStream())
            {
                serReq.WriteObject(ms, request);
                ms.Position = 0;

                using (var sr = new StreamReader(ms))
                {
                    var content = new StringContent(sr.ReadToEnd(), System.Text.Encoding.UTF8, "application/json");

                    var r = await client.PostAsync(path, content).ConfigureAwait(false);

                    var serRes = new DataContractJsonSerializer(typeof(DialogueResponse));
                    response = serRes.ReadObject(await r.Content.ReadAsStreamAsync()) as DialogueResponse;
                    response.StatusCode = r.StatusCode;
                }
            }

            return response;
        }

        public async static Task<KnowledgeQAResponse> GetKnowledgeQAAsync(this HttpClient client, string apiKey, string q)
        {
            NameValueCollection queryString = new NameValueCollection();
            queryString[Q] = q;
            queryString[API_KEY] = apiKey;

            string path = DOCOMO_API_KNOWLEDGEQA_PATH + ToQueryString(queryString);

            client.BaseAddress = new Uri(DOCOMO_API_HOST);
            var r = await client.GetAsync(path).ConfigureAwait(false);

            var serializer = new DataContractJsonSerializer(typeof(KnowledgeQAResponse));
            var response = serializer.ReadObject(await r.Content.ReadAsStreamAsync()) as KnowledgeQAResponse;
            response.StatusCode = r.StatusCode;

            return response;
        }

        private static string ToQueryString(NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(nvc[key]))));
        }
    }
}
