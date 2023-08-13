using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey("ReceptionID")]
        public int ReceptionID { get; set; }
        public Reception? Reception { get; set; }
    }
    public class Reception 
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReceptionDate { get; set; }
        [ForeignKey("OperationType")]
        public int OperationTypeID { get; set; }
        public OperationType? OperationType { get; set; }

        public List<string>? OperationsTeeths { get; set; }
        public string? OperationNotices { get; set; }
    }
    public class OperationType
    {
        [Key]
        public int ID { get; set; }
        public string? OperationTypeName { get; set; }
    }

    public class BodyRequest 
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OperationTypeName { get; set; }
        public List<string> OperationsTooth { get; set; }
        public string? OperationNotices { get; set; }
        public DateTime ReceptionDate { get; set; }
    }
}