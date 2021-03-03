namespace Api.Domain.Models
{
    public class UfModel : BaseModel
    {
        private string _uf;
        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}