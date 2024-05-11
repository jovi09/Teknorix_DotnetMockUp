using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teknorix.DataStore;
using Teknorix.Models.Requests;
using Teknorix.Models.Response;

namespace Teknorix.Service.Manager
{
    public interface IAPIManager
    {
        Task<CreateLocationResponse> CreateLocation(CreateLocationRequest req, HttpRequest httpRequest);
        Task<List<LocationsResponse>> GetLocations();
        Task<int> UpdateLocation(int id, UpdateLocationRequest req);
        Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest req, HttpRequest httpRequest);
        Task<List<DepartmentsResponse>> GetDepartments();
        Task<int> UpdateDepartment(int id, UpdateDepartmentRequest req);
        Task<JobOpeningCreationResponse> CreateJob(JobOpeningCreationRequest req, HttpRequest httpRequest);
        Task<int> UpdateJob(int id, UpdateJobRequest req);
        Task<JobDetails> GetJobDetailsBasedOnId(int id);
        Task<JobListingResponse> SearchJobs(JobListingRequest req);

    }
    public class APIManager : IAPIManager
    {
        private readonly IConfiguration _appSettings;
        public APIManager(IConfiguration configuration)
        {
            _appSettings = configuration;
        }

        #region Locations
        public async Task<CreateLocationResponse> CreateLocation(CreateLocationRequest req, HttpRequest httpRequest)
        {
            DatabaseOperations db = new(_appSettings);
            int insertedId = db.InsertLocations(req);
            // Construct the URL of the endpoint with the inserted Id
            var baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host}";
            string endpointUrl = $"{baseUrl.TrimEnd('/')}/api/location/{insertedId}";


            // Create a response object
            CreateLocationResponse response = new CreateLocationResponse
            {
                OutputURL=endpointUrl
            };

            return response;

        }

        public async Task<int> UpdateLocation(int id, UpdateLocationRequest req)
        {
            DatabaseOperations db = new(_appSettings);
            var updatedRows =await db.UpdateLocation(id,req);

            return updatedRows;

        }

        public async Task<List<LocationsResponse>> GetLocations()
        {
            DatabaseOperations db = new(_appSettings);
            var locations = await db.GetLocations();
            return locations;
        }

        #endregion

        #region Departments
        public async Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest req, HttpRequest httpRequest)
        {
            DatabaseOperations db = new(_appSettings);
            int insertedId = db.InsertDepartment(req);
            // Construct the URL of the endpoint with the inserted Id
            var baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host}";
            string endpointUrl = $"{baseUrl.TrimEnd('/')}/api/department/{insertedId}";


            // Create a response object
            CreateDepartmentResponse response = new CreateDepartmentResponse
            {
                OutputURL = endpointUrl
            };

            return response;

        }

        public async Task<int> UpdateDepartment(int id, UpdateDepartmentRequest req)
        {
            DatabaseOperations db = new(_appSettings);
            var updatedRows = await db.UpdateDepartment(id, req);

            return updatedRows;

        }

        public async Task<List<DepartmentsResponse>> GetDepartments()
        {
            DatabaseOperations db = new(_appSettings);
            var locations = await db.GetDepartments();
            return locations;
        }
        #endregion

        #region Jobs

        public async Task<JobOpeningCreationResponse> CreateJob(JobOpeningCreationRequest req, HttpRequest httpRequest)
        {
            DatabaseOperations db = new(_appSettings);
            int insertedId = db.InsertJob(req);
            // Construct the URL of the endpoint with the inserted Id
            var baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host}";
            string endpointUrl = $"{baseUrl.TrimEnd('/')}/api/job/{insertedId}";


            // Create a response object
            JobOpeningCreationResponse response = new JobOpeningCreationResponse
            {
                OutputURL = endpointUrl
            };

            return response;

        }

        public async Task<int> UpdateJob(int id, UpdateJobRequest req)
        {
            DatabaseOperations db = new(_appSettings);
            var updatedRows = await db.UpdateJob(id, req);

            return updatedRows;

        }

        public async Task<JobDetails> GetJobDetailsBasedOnId(int id)
        {
            DatabaseOperations db = new(_appSettings);
            var jobDetails = await db.GetJobDetailsBasedOnId(id);
            return jobDetails;
        }

        public async Task<JobListingResponse> SearchJobs(JobListingRequest req)
        {
            DatabaseOperations db = new(_appSettings);
            var jobSearchResults = await db.SearchJobs(req);
            return jobSearchResults;
        }

        #endregion
    }
}
