namespace Api.Domain.Models
{
    public class UserModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }
}