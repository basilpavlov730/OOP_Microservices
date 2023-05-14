using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOP_DatabaseMicroserice.DataBase
{
    [Table("tblUsers")]
    public class User
    {
        // Свойства класса будут трасформированы в столбцы в таблице

        // Атрибут указывающий что данное свойство является первичным ключом в таблице
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

    }
}
