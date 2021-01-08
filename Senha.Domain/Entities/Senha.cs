using System.Linq;
using System.Text.RegularExpressions;

namespace Senha.Domain.Entities
{
    public class Senha : Entity
    {
        private readonly string _senha;

        public Senha(string senha)
        {
            this._senha = senha;
        }
        public static implicit operator Senha(string senha)
        {
            return new Senha(senha);
        }

        public static implicit operator string(Senha senha)
        {
            return senha._senha;
        }

        public override bool IsValid()
        {
            return ValidarCaracteres()
                   && !ValidarDuplicaidade()
                   && !ValidarEspaco();
        }

        protected bool ValidarCaracteres()
        {
            return Regex.IsMatch(_senha, @"^(?=(.*\d){1})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$");
        }

        protected bool ValidarDuplicaidade()
        {
            return _senha.GroupBy(x => x).Any(g => g.Count() > 1);
        }

        protected bool ValidarEspaco()
        {
            return Regex.IsMatch(_senha, @" ");
        }
    }
}
