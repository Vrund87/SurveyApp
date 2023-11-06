using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SurveyWebApp.Models;
using SurveyWebApp.Services;
using System.ComponentModel.DataAnnotations;

namespace SurveyWebApp.Pages
{
    public partial class Video
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        public SurveyQuestions formData = new();
        public bool ty = false;
        [Parameter]
        public SurveyPostRequest surveyPostRequest { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                // Execute initVideo only when the video element is present
                await JSRuntime.InvokeVoidAsync("initVideo");
            }
            
        }

        [Inject]
        public ICallAPI CallAPI { get; set; }

        

        //public HttpResponseMessage httpResponseMessage { get; set; } = new();

        public async Task SubmitDetails()
        {   
            if(surveyPostRequest==null)
            {
                Console.WriteLine("survey object null");
            }
            if(formData==null)
            {
                Console.WriteLine("form data null");
            }
            surveyPostRequest.sq1 = formData.sq1;
            surveyPostRequest.sq2 = formData.sq2;
            surveyPostRequest.sq3 = formData.sq3;
            surveyPostRequest.sq4a = formData.sq4a;
            surveyPostRequest.sq4b = formData.sq4b; 
            surveyPostRequest.sq4c = formData.sq4c;
            surveyPostRequest.sq4d = formData.sq4d;
            surveyPostRequest.sq4Other = formData.sq4Other;
            surveyPostRequest.sq5 = formData.sq5;   
            surveyPostRequest.sq6 = formData.sq6;
            surveyPostRequest.sq7 = formData.sq7;
            surveyPostRequest.sq8 = formData.sq8;
            surveyPostRequest.sq9 = formData.sq9;

            CallAPI.PutSurveyDetails(surveyPostRequest);
            ty = true;
            //if(httpResponseMessage.IsSuccessStatusCode)
            //{
            //    ty = true;
            //}
            
        }

        

        public string y = "Yes",n="No";
        public string op1 = "Very likely",op2= "Somewhat likely",op3= "Unlikely",op4= "Not at all";
       
    }
}
