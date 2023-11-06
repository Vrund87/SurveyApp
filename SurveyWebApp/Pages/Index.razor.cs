using Microsoft.AspNetCore.Components;
using SurveyWebApp.Models;
using SurveyWebApp.Services;

namespace SurveyWebApp.Pages
{
    public partial class Index
    {
        PersonalDetails formData = new();
        public int flag = 1;

        [Inject]
        public ICallAPI CallAPI { get; set; }

        public string exp1 = "Less than 2 years";
        public string exp2 = "Between 2 to 5 years";
        public string exp3 = "Between 6 to 10 years";
        public string exp4 = "More than 10 years";

        public string role1 = "Developer";
        public string role2 = "Tester";
        public string role3 = "Architect";
        public string role4 = "Project Manager";
        public string role5 = "Other";

        //public HttpResponseMessage httpResponseMessage { get; set; } = new();


        public void GoNext()
        {
            surveyPostRequest.name = formData.name;
            surveyPostRequest.yearsOfExperience = formData.yearsOfExperience;
            surveyPostRequest.email = formData.email;
            surveyPostRequest.currentRole = formData.currentRole;
            surveyPostRequest.otherRole = formData.otherRole;
            surveyPostRequest.phone = formData.phone;
            surveyPostRequest.linkedIn = formData.linkedIn;
            surveyPostRequest.canContact = formData.canContact;

            surveyPostRequest = CallAPI.PostSurveyDetails(surveyPostRequest);

            //httpResponseMessage = await CallAPI.PostSurveyDetails(surveyPostRequest);


            //surveyPostRequest = await httpResponseMessage.Content.ReadFromJsonAsync<SurveyPostRequest>();

            

            flag = 2;
            StateHasChanged();

        }

        public void GoBack()
        {
            flag = 1;
        }

        public SurveyPostRequest surveyPostRequest = new SurveyPostRequest();



    }
}
