using Microsoft.AspNetCore.Components;
using SurveyWebApp.Models;
using SurveyWebApp.Services;
using System.Text.Json;

namespace SurveyWebApp.Pages
{
    public partial class DisplaySurveys
    {
        List<SurveyPostRequest> surveys = new();
        public HttpResponseMessage httpResponseMessage = new();

        [Inject]
        public ICallAPI callAPI { get; set; }
        public string response = "";
        public bool disp = false;

        protected override void OnInitialized()
        {
            surveys = callAPI.GetSurveyDetails();
            //response = await httpResponseMessage.Content.ReadAsStringAsync();
            disp = true;
        }

        public string func(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return "Not Provided";
            }
            else
            {
                return s;
            }
        }

        public string func1(bool s)
        {
            if (s)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

    }
}
