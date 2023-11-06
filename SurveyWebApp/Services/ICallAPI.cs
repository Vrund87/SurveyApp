using SurveyWebApp.Models;

namespace SurveyWebApp.Services
{
    public interface ICallAPI
    {
        //Task<HttpResponseMessage> PostSurveyDetails(SurveyPostRequest surveyPostRequest);
        //Task<HttpResponseMessage> PutSurveyDetails(SurveyPostRequest surveyPostRequest);
        //Task<HttpResponseMessage> GetSurveyDetails();

        public SurveyPostRequest PostSurveyDetails(SurveyPostRequest surveyPostRequest);
        public void PutSurveyDetails(SurveyPostRequest surveyPostRequest);
        public List<SurveyPostRequest> GetSurveyDetails();

    }
}
