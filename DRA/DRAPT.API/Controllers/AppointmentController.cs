using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DRAPT.API.Entities;

namespace DRAPT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = new DataTable();
            string sqldataSource = _configuration.GetConnectionString("CONDB");
            using (SqlConnection con = new SqlConnection(sqldataSource))
            {
                SqlCommand cmd = new SqlCommand("SPAPPOINTMENTCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Op","4");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();
                con.Close();
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Appointment appoinment)
        {
            DataTable table = new DataTable();
            string sqldataSource = _configuration.GetConnectionString("CONDB");
            using (SqlConnection con = new SqlConnection(sqldataSource))
            {
                SqlCommand cmd = new SqlCommand("SPAPPOINTMENTCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientName", appoinment.PatientName);
                cmd.Parameters.AddWithValue("@EmailId", appoinment.EmailId);
                cmd.Parameters.AddWithValue("@StartDate", appoinment.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", appoinment.StartDate.AddMinutes(30));
                cmd.Parameters.AddWithValue("@Message", appoinment.Message);
                cmd.Parameters.AddWithValue("@DoctorId", appoinment.DoctorId);
                cmd.Parameters.AddWithValue("@Op","1");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();
                con.Close();
            }
            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(Appointment appoinment)
        {
            DataTable table = new DataTable();
            string sqldataSource = _configuration.GetConnectionString("CONDB");
            using (SqlConnection con = new SqlConnection(sqldataSource))
            {
                SqlCommand cmd = new SqlCommand("SPAPPOINTMENTCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppointmentId", appoinment.AppointmentId);
                cmd.Parameters.AddWithValue("@PatientName", appoinment.PatientName);
                cmd.Parameters.AddWithValue("@EmailId", appoinment.EmailId);
                cmd.Parameters.AddWithValue("@StartDate", appoinment.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", appoinment.StartDate.AddMinutes(30));
                cmd.Parameters.AddWithValue("@Message", appoinment.Message);
                cmd.Parameters.AddWithValue("@DoctorId", appoinment.DoctorId);
                cmd.Parameters.AddWithValue("@Op", "2");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();
                con.Close();
            }
            return new JsonResult(table);
        }

        [HttpDelete]
        public JsonResult Delete(Appointment appoinment)
        {
            DataTable table = new DataTable();
            string sqldataSource = _configuration.GetConnectionString("CONDB");
            using (SqlConnection con = new SqlConnection(sqldataSource))
            {
                SqlCommand cmd = new SqlCommand("SPAPPOINTMENTCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppointmentId", appoinment.AppointmentId);
                cmd.Parameters.AddWithValue("@Op","3");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();
                con.Close();
            }
            return new JsonResult(table);
        }
    }
}
