using CadastroViagens.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroViagens.Models.Base
{
    public class BaseRepositorio<T> where T: class
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> classe;

        public BaseRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            classe = _appDbContext.Set<T>();
        }
    }
}
