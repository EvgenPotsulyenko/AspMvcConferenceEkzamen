using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMvcConferenceEkzamen.Models
{
    public class Conference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; } // организаторы
        public string Sponsors { get; set; }  //спонсоры
        public string Scenario { get; set; } // сценарий
        public string Speakers { get; set; } // докладчики
        public virtual List<User> Users { get; set; }
    }
}
