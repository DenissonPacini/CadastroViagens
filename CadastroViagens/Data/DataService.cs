using CadastroViagens.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroViagens.Data
{
    public class DataService : IDataService
    {
        private readonly AppDbContext _appDbContext;

        public DataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void InicializaDb()
        {
            //_appDbContext.Database.EnsureCreated();
            _appDbContext.Database.Migrate();
        }
    }
}
