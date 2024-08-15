using Core;
using InfraEstrutura;
using Services.Repositorios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositorios.RepositoriosServices
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(GestaoDbContext context) : base(context) { }
    }
}
