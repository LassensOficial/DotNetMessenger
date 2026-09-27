public class User
{
    public Response user { get; set; }
    public List<Chat> chats { get; set; } = new List<Chat>();
}