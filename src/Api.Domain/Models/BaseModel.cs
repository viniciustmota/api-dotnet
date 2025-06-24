namespace Api.Domain.Models
{
    public class BaseModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
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