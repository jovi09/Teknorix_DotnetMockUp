using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using Teknorix.Models.Requests;
using Teknorix.Models.Response;
using Teknorix.Service.Manager;

namespace Teknorix_DotnetMockUp.Controllers
{
   
    [ApiController]
    [Route("API")]
    public class APIController : ControllerBase
    {
       
        private readonly ILogger<APIController> _logger;
        private readonly IAPIManager _manager;
        public APIController(ILogger<APIController> logger,IAPIManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        #region Jobs
        [Authorize]
        [HttpPost]
        [Route("/v1/Jobs")]
        public async Task<JobOpeningCreationResponse> CreateJob(JobOpeningCreationRequest req)
        {
            try
            {
                var response = await _manager.CreateJob(req, HttpContext.Request);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [Authorize]
        [HttpPut]
        [Route("/v1/jobs/{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobRequest req)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Input was not supplied");
                }

                var response = await _manager.UpdateJob(id, req);

                if (response > 0)
                {
                    string responseMsg = $"Updated {response} row(s) successfully";
                    return Ok(responseMsg);
                }
                else
                {
                    return StatusCode(500, "Could not Update");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]//[AllowAnonymous]
        [HttpGet]
        [Route("/v1/jobs/{id}")]
        public async Task<IActionResult> GetJobDetailsBasedOnId(int id)
        {
            try
            {
                var jobs = await _manager.GetJobDetailsBasedOnId(id);

                if (jobs != null)
                {
                    return Ok(jobs);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/v1/Jobs/List")]
        public async Task<JobListingResponse> SearchJobs(JobListingRequest req)
        {
            try
            {
                var response = await _manager.SearchJobs(req);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Locations
        [Authorize]
        [HttpPost]
        [Route("/v1/locations")]
        public async Task<CreateLocationResponse> CreateLocation (CreateLocationRequest req)
        {
            try
            {
                var response = await _manager.CreateLocation(req, HttpContext.Request);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [Authorize]
        [HttpPut]
        [Route("/v1/locations/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, UpdateLocationRequest req)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Input was not supplied");
                }

                var response = await _manager.UpdateLocation(id, req);

                if (response > 0)
                {
                    string responseMsg = $"Updated {response} row(s) successfully";
                    return Ok(responseMsg);
                }
                else
                {
                    return StatusCode(500, "Could not Update");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/v1/locations")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _manager.GetLocations();

                // Check if any locations were found
                if (locations != null && locations.Any())
                {
                    return Ok(locations);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Departments
        [Authorize]
        [HttpPost]
        [Route("/v1/Department")]
        public async Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest req)
        {
            try
            {
                var response = await _manager.CreateDepartment(req, HttpContext.Request);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [Authorize]
        [HttpPut]
        [Route("/v1/Department/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentRequest req)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Input was not supplied");
                }

                var response = await _manager.UpdateDepartment(id, req);

                if (response > 0)
                {
                    string responseMsg = $"Updated {response} row(s) successfully";
                    return Ok(responseMsg);
                }
                else
                {
                    return StatusCode(500, "Could not Update");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/v1/Departments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await _manager.GetDepartments();

                // Check if any locations were found
                if (departments != null && departments.Any())
                {
                    return Ok(departments);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

    }
}
