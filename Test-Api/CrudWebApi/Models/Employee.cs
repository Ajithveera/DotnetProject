using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Models
{
    public class Employee
    {
        [Key]
        public Guid id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }


    }
}
