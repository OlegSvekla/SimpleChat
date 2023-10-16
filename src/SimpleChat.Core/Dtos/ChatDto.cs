namespace SimpleChat.Core.Dtos
{
    public class ChatDto : BaseEntityDto
    {
        public string ChatName { get; set; }

        public UserDto UserCreator { get; set; }
    }
}
