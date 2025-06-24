namespace Api.Domain.Models
{
    public class MunicipioModel : BaseModel
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int _CodIBGE;
        public int CodIBGE
        {
            get { return _CodIBGE; }
            set { _CodIBGE = value; }
        }
        
        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }
        
    }
}