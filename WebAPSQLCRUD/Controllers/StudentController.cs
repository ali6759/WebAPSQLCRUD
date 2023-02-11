using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPSQLCRUD.Models;


namespace WebAPSQLCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;  //  receive and request the connection 

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // to read the data from the server student table
        [HttpGet]
        [Route("GetAllStudents")]

        public Response GetAllStudents()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("studentCon").ToString());
            Response response = new Response();
            Applications apl = new Applications();
            response = apl.GetAllStudents(con);

            return response;
        }

        // to insert data in my Student table
        [HttpPost]
        [Route("AddStudent")]
        public Response AddStudent(Student student)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("studentCon").ToString());
            Response response = new Response();
            Applications apl = new Applications();
            response = apl.AddStudent(con , student);

            return response;
        }

    }

}
