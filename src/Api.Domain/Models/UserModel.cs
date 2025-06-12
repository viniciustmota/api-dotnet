namespace Api.Domain.Models
{
    public class UserModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get => _createAt;
            set => _createAt = value == null ? DateTime.UtcNow : value;
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get => _updateAt;
            set => _updateAt = value;
        }
    }
}