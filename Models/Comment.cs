using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Text { get; set; }
    }
}
