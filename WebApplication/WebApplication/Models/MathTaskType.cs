using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class MathTaskType : BaseModel
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public virtual string Name { get; set; }
    }
}