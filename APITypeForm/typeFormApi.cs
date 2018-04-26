using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace app_lp
{/// <summary>
/// cette classe permet de gérer api
/// </summary>
    class typeFormApi
    {


        public string token { get; set; }


        public typeFormApi(string token)
        {
            this.token = token;
        }



        public FormTypeForm.FormObject getForm(string id_form)
        {

            string url = "https://api.typeform.com/forms/" + id_form;
            string outputJson = getJson(url, token).Result;

            FormTypeForm.FormObject res = JsonConvert.DeserializeObject<FormTypeForm.FormObject>(outputJson);


            return res;
        }
        
        public async static Task<AnswerTypeForm.AnswerObject> getAnswers(string token, string id_form)
        {


            string url = "https://api.typeform.com/forms/" + id_form + "/responses";


            string outputJson = await getJson(url, token);
            AnswerTypeForm.AnswerObject res = JsonConvert.DeserializeObject<AnswerTypeForm.AnswerObject>(outputJson);
            return res;

        }

        public async static Task<string> getJson(string url, string token)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer " + token);

                var response = await client.GetAsync(url);
                Task<string> responseString = response.Content.ReadAsStringAsync();
                string outputJson = await responseString;
                return outputJson;
            }
        }


          
    }
}