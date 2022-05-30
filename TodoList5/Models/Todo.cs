using System.ComponentModel.DataAnnotations;

namespace TodoList5.Models
{
    public class Todo
    {
        public int Id { set; get; }
        [Required]
        public string TaskName { set; get; }

        public string  Priority{ set; get; }

        public string Date { set; get; }

    }
}
