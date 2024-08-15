using Core;
using Services.Repositorios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositorios.RepositoriosServices
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(DbContext context) : base(context) { }
    }
}
