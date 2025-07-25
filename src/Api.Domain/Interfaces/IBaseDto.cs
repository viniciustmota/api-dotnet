namespace Api.Domain.Interfaces
{
    public interface IBaseDto<TId>
    {
        public TId Id { get; set; }
    }
}