using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Teknorix.Models.Requests;
using Teknorix.Models.Response;

namespace Teknorix.DataStore
{
    public interface IDatabaseOperations
    {
        int InsertLocations(CreateLocationRequest req);
        Task<List<LocationsResponse>> GetLocations();
        Task<int> UpdateLocation(int id, UpdateLocationRequest req);
        int InsertDepartment(CreateDepartmentRequest req);
        Task<List<DepartmentsResponse>> GetDepartments();
        Task<int> UpdateDepartment(int id, UpdateDepartmentRequest req);
        int InsertJob(JobOpeningCreationRequest req);
        Task<int> UpdateJob(int id, UpdateJobRequest req);
        Task<JobDetails> GetJobDetailsBasedOnId(int id);
        Task<JobListingResponse> SearchJobs(JobListingRequest req);
    }
    public class DatabaseOperations : IDatabaseOperations
    {
        private IConfiguration _configuration { get; set; }
        private string _connectionString = string.Empty;
        public DatabaseOperations(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings"];
        }

        public int InsertLocations(CreateLocationRequest req)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlcmd = new SqlCommand("SPI_InsertLocation", sqlcon))
                    {
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        sqlcmd.Parameters.AddWithValue("@Title", req.Title);
                        sqlcmd.Parameters.AddWithValue("@City", req.City);
                        sqlcmd.Parameters.AddWithValue("@State", req.State);
                        sqlcmd.Parameters.AddWithValue("@Country", req.Country);
                        sqlcmd.Parameters.AddWithValue("@Zip", req.Zip);

                        // Add OUTPUT parameter to capture the inserted Id
                        SqlParameter insertedIdParam = new SqlParameter("@InsertedId", System.Data.SqlDbType.Int);
                        insertedIdParam.Direction = System.Data.ParameterDirection.Output;
                        sqlcmd.Parameters.Add(insertedIdParam);

                        sqlcon.Open();
                        sqlcmd.ExecuteNonQuery();

                        // Get the value of the OUTPUT parameter after the execution
                        int insertedId = Convert.ToInt32(sqlcmd.Parameters["@InsertedId"].Value);

                        sqlcon.Close();

                        return insertedId;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LocationsResponse>> GetLocations()
        {
            List<LocationsResponse> locations = new List<LocationsResponse>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SPS_GetLocations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                // Map reader data to your Location model
                                LocationsResponse location = new LocationsResponse
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = reader["Title"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Zip = reader["Zip"].ToString(),
                                };

                                locations.Add(location);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return locations;
        }

        public async Task<int> UpdateLocation(int id, UpdateLocationRequest req)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SPU_UpdateLocation", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", !string.IsNullOrEmpty(req.Title) ? req.Title : DBNull.Value);
                    command.Parameters.AddWithValue("@City", !string.IsNullOrEmpty(req.City) ? req.City : DBNull.Value);
                    command.Parameters.AddWithValue("@State", !string.IsNullOrEmpty(req.State) ? req.State : DBNull.Value);
                    command.Parameters.AddWithValue("@Country", !string.IsNullOrEmpty(req.Country) ? req.Country : DBNull.Value);
                    command.Parameters.AddWithValue("@Zip", !string.IsNullOrEmpty(req.Zip) ? req.Zip : DBNull.Value);
                    SqlParameter rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int);
                    rowsAffectedParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(rowsAffectedParam);
                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        int rowsAffected = Convert.ToInt32(rowsAffectedParam.Value);

                        return rowsAffected;
                    }
                    catch (Exception)
                    {
                        return -1; 
                    }

                }
            }
        }


        public int InsertDepartment(CreateDepartmentRequest req)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlcmd = new SqlCommand("SPI_InsertDepartment", sqlcon))
                    {
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        sqlcmd.Parameters.AddWithValue("@Title", req.Title);

                        // Add OUTPUT parameter to capture the inserted Id
                        SqlParameter insertedIdParam = new SqlParameter("@InsertedId", System.Data.SqlDbType.Int);
                        insertedIdParam.Direction = System.Data.ParameterDirection.Output;
                        sqlcmd.Parameters.Add(insertedIdParam);

                        sqlcon.Open();
                        sqlcmd.ExecuteNonQuery();

                        // Get the value of the OUTPUT parameter after the execution
                        int insertedId = Convert.ToInt32(sqlcmd.Parameters["@InsertedId"].Value);

                        sqlcon.Close();

                        return insertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DepartmentsResponse>> GetDepartments()
        {
            List<DepartmentsResponse> depts = new List<DepartmentsResponse>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SPS_GetDepartments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                // Map reader data to your Location model
                                DepartmentsResponse dept = new DepartmentsResponse
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = reader["Title"].ToString()
                                };

                                depts.Add(dept);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return depts;
        }

        public async Task<int> UpdateDepartment(int id, UpdateDepartmentRequest req)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SPU_UpdateDepartment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", !string.IsNullOrEmpty(req.Title) ? req.Title : DBNull.Value);
                    // Add an output parameter to capture the rows affected
                    SqlParameter rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int);
                    rowsAffectedParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(rowsAffectedParam);
                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        int rowsAffected = Convert.ToInt32(rowsAffectedParam.Value);

                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }

                }
            }
        }

        public int InsertJob(JobOpeningCreationRequest req)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlcmd = new SqlCommand("SPI_InsertJob", sqlcon))
                    {
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        sqlcmd.Parameters.AddWithValue("@Title", req.Title);
                        sqlcmd.Parameters.AddWithValue("@DepartmentId", req.DepartmentId);
                        sqlcmd.Parameters.AddWithValue("@LocationId", req.LocationId);
                        sqlcmd.Parameters.AddWithValue("@ClosingDate", req.ClosingDate);
                        sqlcmd.Parameters.AddWithValue("@Description", req.Description);

                        // Add OUTPUT parameter to capture the inserted Id
                        SqlParameter insertedIdParam = new SqlParameter("@InsertedId", System.Data.SqlDbType.Int);
                        insertedIdParam.Direction = System.Data.ParameterDirection.Output;
                        sqlcmd.Parameters.Add(insertedIdParam);

                        sqlcon.Open();
                        sqlcmd.ExecuteNonQuery();

                        // Get the value of the OUTPUT parameter after the execution
                        int insertedId = Convert.ToInt32(sqlcmd.Parameters["@InsertedId"].Value);

                        sqlcon.Close();

                        return insertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateJob(int id, UpdateJobRequest req)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SPU_UpdateJob", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Title", !string.IsNullOrEmpty(req.Title) ? req.Title : DBNull.Value);
                        command.Parameters.AddWithValue("@DepartmentId", !string.IsNullOrEmpty(req.DepartmentId) ? req.DepartmentId : DBNull.Value);
                        command.Parameters.AddWithValue("@LocationId", !string.IsNullOrEmpty(req.LocationId) ? req.LocationId : DBNull.Value);
                        command.Parameters.AddWithValue("@ClosingDate", req.ClosingDate.HasValue ? req.ClosingDate.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(req.Description) ? req.Description : DBNull.Value);
                        SqlParameter rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int);
                        rowsAffectedParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(rowsAffectedParam);
                        try
                        {
                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();

                            int rowsAffected = Convert.ToInt32(rowsAffectedParam.Value);

                            return rowsAffected;
                        }
                        catch (Exception)
                        {
                            return -1;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<JobDetails> GetJobDetailsBasedOnId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SPS_GetJobDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@JobId", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                JobDetails jobdetail = null;

                if (reader.Read())
                {
                    jobdetail = new JobDetails
                    {
                        Id = Convert.ToInt32(reader["JobId"]),
                        Code = reader["JobCode"] != DBNull.Value ? reader["JobCode"].ToString() : string.Empty,
                        Title = reader["JobTitle"] != DBNull.Value ? reader["JobTitle"].ToString() : string.Empty,
                        Description = reader["JobDescription"] != DBNull.Value ? reader["JobDescription"].ToString() : string.Empty,
                        PostedDate = reader["PostedDate"] != DBNull.Value ? Convert.ToDateTime(reader["PostedDate"]).ToString("MM/dd/yyyy") : string.Empty,
                        ClosingDate = reader["ClosingDate"] != DBNull.Value ? Convert.ToDateTime(reader["ClosingDate"]).ToString("MM/dd/yyyy") : string.Empty,
                        Location = new Location
                        {
                            Id = Convert.ToInt32(reader["LocationId"]),
                            Title = reader["LocationTitle"] != DBNull.Value ? reader["LocationTitle"].ToString() : string.Empty,
                            City = reader["LocationCity"] != DBNull.Value ? reader["LocationCity"].ToString() : string.Empty,
                            State = reader["LocationState"] != DBNull.Value ? reader["LocationState"].ToString() : string.Empty,
                            Country = reader["LocationCountry"] != DBNull.Value ? reader["LocationCountry"].ToString() : string.Empty,
                            Zip = reader["LocationZip"] != DBNull.Value ? Convert.ToInt32(reader["LocationZip"]) : 0
                        },
                        Department = new Department
                        {
                            Id = Convert.ToInt32(reader["DepartmentId"]),
                            Title = reader["DepartmentTitle"] != DBNull.Value ? reader["DepartmentTitle"].ToString() : string.Empty
                        }
                    };
                }

                return jobdetail;
            }
        }

        public async Task<JobListingResponse> SearchJobs(JobListingRequest request)
        {
            JobListingResponse resp = new JobListingResponse();
            List<Data> data = new List<Data>();
            var Totals = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SPS_SearchJobs", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SearchText", request.q);
                command.Parameters.AddWithValue("@LocationId", request.LocationId > 0 ? request.LocationId : DBNull.Value);
                command.Parameters.AddWithValue("@DepartmentId", request.DepartmentId > 0? request.DepartmentId : DBNull.Value);
                command.Parameters.AddWithValue("@PageNumber", request.PageNo);
                command.Parameters.AddWithValue("@PageSize", request.PageSize);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    Data datum = new Data
                    {
                        Id = reader["JobId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["JobId"]),
                        Code = reader["JobCode"] == DBNull.Value ? string.Empty : reader["JobCode"].ToString(),
                        Title = reader["JobTitle"] == DBNull.Value ? string.Empty : reader["JobTitle"].ToString(),
                        Location = reader["LocationTitle"] == DBNull.Value ? string.Empty : reader["LocationTitle"].ToString(),
                        Department = reader["DepartmentTitle"] == DBNull.Value ? string.Empty : reader["DepartmentTitle"].ToString(),
                        PostedDate = reader["PostedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PostedDate"]),
                        ClosingDate = reader["ClosingDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ClosingDate"]),
                        
                    };
                    Totals = reader["TotalRows"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalRows"]);

                    data.Add(datum);
                }
                connection.Close();
            }
            resp.Data = data;
            resp.Totals = Totals;

            return resp;
        }

    }
}
