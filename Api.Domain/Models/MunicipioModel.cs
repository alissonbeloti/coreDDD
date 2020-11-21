using System;

namespace Domain.Models
{
    public class MunicipioModel: BaseModel
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int _codIbge;

        public int CodIbge
        {
            get { return _codIbge; }
            set { _codIbge = value; }
        }
        private Guid guid;

        public Guid UfId
        {
            get { return guid; }
            set { guid = value; }
        }

    }
}
