using CadastroViagens.Interfaces;

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
            _appDbContext.Database.EnsureCreated();
        }
    }
}
