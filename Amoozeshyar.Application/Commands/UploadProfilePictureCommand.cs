namespace Amoozeshyar.Application.Commands
{
    public class UploadProfilePictureCommand
	{
        public Guid UserId { get; set; }

        public Stream FileStream { get; set; }

        public string FileName { get; set; }
    }
}

