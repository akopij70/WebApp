using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApp.Models
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public float voltage { get; set; }
        public float volume { get; set; }
        public float price { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; }
    }
}