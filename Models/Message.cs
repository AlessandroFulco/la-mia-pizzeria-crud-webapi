namespace la_mia_pizzeria_static.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Message(string id, string email, string name, string title, string text)
        {
            Id = id;
            Email = email;
            Name = name;
            Title = title;
            Text = text;
        }
    }
}
