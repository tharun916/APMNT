using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DRAPT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DoctorController(IConfiguration configuration)
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
                SqlCommand cmd = new SqlCommand("SPDOCTORSSELECT", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
