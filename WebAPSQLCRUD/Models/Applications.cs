using System.Data;
using System.Data.SqlClient;

namespace WebAPSQLCRUD.Models
{
    public class Applications
    {
        public Response GetAllStudents(SqlConnection con)
        {
            Response response = new Response();
            string Query = "Select * from Student";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Student> lsStdnt = new List<Student>();

            if (dt.Rows.Count > 0)
            {
                for(int i= 0; i < dt.Rows.Count; i++)
                {
                    Student student = new Student(); //creating the class object
                    student.Id = (int)dt.Rows[i]["ID"];
                    student.Name = (string)dt.Rows[i]["Name"];
                    student.Email = (string)dt.Rows[i]["Email"];
                    student.Age = float.Parse(dt.Rows[i]["Age"].ToString());

                    lsStdnt.Add(student);

                }
            }
            if (lsStdnt.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Student Retrieved Perfectly";
                response.listStudent = lsStdnt;
            }
            else // only works if your data table is empty or your connection fails
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Found Any Student";
                response.listStudent = null;
            }

            return response;
        }

        public Response AddStudent(SqlConnection con , Student student)
        {
            Response response = new Response();
            string Quary = "Insert into student(Id, Name, Email, Age)Values(@ID, @Name , @Email , @Age)";

            SqlCommand cmd = new SqlCommand(Quary, con);

            cmd.Parameters.AddWithValue("@ID" , student.Id);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "No Data properly";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data inserted";
            }
            return response;
        }
    }
}
