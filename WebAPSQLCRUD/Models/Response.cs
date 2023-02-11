using System.Security.Cryptography.X509Certificates;

namespace WebAPSQLCRUD.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public  Student Student { get; set; }
        public List<Student> listStudent { get; set; }
    }
}
