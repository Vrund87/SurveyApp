using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MongoDB.Driver;
using SurveyWebApp.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


namespace SurveyWebApp.Services
{
    public class CallAPI : ICallAPI
    {
        private readonly IMongoCollection<SurveyPostRequest> _surveys;

        public CallAPI(ISurveyDBSettings settings, IMongoClient mongoClient)
        {
            var DBName = mongoClient.GetDatabase(settings.DatabaseName);
            _surveys = DBName.GetCollection<SurveyPostRequest>(settings.SurveyCollectionName);
        }

        public SurveyPostRequest PostSurveyDetails(SurveyPostRequest surveyPostRequest)
        {

            _surveys.InsertOne(surveyPostRequest);
            return surveyPostRequest;
        }

        public void PutSurveyDetails(SurveyPostRequest survey)
        {

            var filter = Builders<SurveyPostRequest>.Filter.Eq(s => s.id, survey.id);
            var update = Builders<SurveyPostRequest>.Update
                // ... Include other properties that you want to update ...
                .Set(s => s.sq1, survey.sq1)
                .Set(s => s.sq2, survey.sq2)
                .Set(s => s.sq3, survey.sq3)
                .Set(s => s.sq4a, survey.sq4a)
                .Set(s => s.sq4b, survey.sq4b)
                .Set(s => s.sq4c, survey.sq4c)
                .Set(s => s.sq4d, survey.sq4d)
                .Set(s => s.sq4Other, survey.sq4Other)
                .Set(s => s.sq5, survey.sq5)
                .Set(s => s.sq6, survey.sq6)
                .Set(s => s.sq7, survey.sq7)
                .Set(s => s.sq8, survey.sq8)
                .Set(s => s.sq9, survey.sq9);

            _surveys.UpdateOne(filter, update);
        }

        public List<SurveyPostRequest> GetSurveyDetails()
        {
            return _surveys.Find(survey => true).ToList();

        }


        //private readonly HttpClient httpClient;
        //public HttpResponseMessage httpResponseMessage = new();
        //List<SurveyPostRequest> surveys = new();
        //public string responseContent = "";

        //[Inject]
        //protected IJSRuntime JSRuntime { get; set; }

        //public CallAPI(HttpClient httpClient)
        //{
        //    this.httpClient=httpClient;
        //}
        //public async Task<HttpResponseMessage> PostSurveyDetails(SurveyPostRequest surveyPostRequest)
        //{

        //    return await httpClient.PostAsJsonAsync("api/Surveys",surveyPostRequest);
        //}

        //public async Task<HttpResponseMessage> PutSurveyDetails(SurveyPostRequest surveyPostRequest)
        //{

        //    return await httpClient.PutAsJsonAsync("api/Surveys",surveyPostRequest);
        //}

        //public async Task<HttpResponseMessage> GetSurveyDetails()
        //{
        //    return await httpClient.GetAsync("api/Surveys");

        //}
    }
}
