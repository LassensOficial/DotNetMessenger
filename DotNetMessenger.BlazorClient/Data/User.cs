public class User
{
    public Response CurrentUser { get; set; }

    // public List<int> ChatsId { get; set; } = new List<int>();
    public List<Chat> Chats { get; set; } = new List<Chat>();
}