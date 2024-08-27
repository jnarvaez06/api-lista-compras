using ApiListaCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiListaCompras.Repository
{
    public class ItemRepository: IRepository<Item>
    {
        private ListaComprasDbContext _dbContext;

        public ItemRepository(ListaComprasDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        //CONSULTA LA TABLA "Items" POR ENTITY FRAMEWORK
        public async Task<IEnumerable<Item>> Get() => await _dbContext.Items.ToListAsync();

        // INSERTA POR ENTITY FRAMEWORK HACIA LA TABLA "Items"
        public async Task Add(Item entity) => await _dbContext.Items.AddAsync(entity);


        public async Task Save() => await _dbContext.SaveChangesAsync();

        public async Task<Item> GetById(int id) => await _dbContext.Items.FindAsync(id);

        public void Update(Item entity)
        {
            _dbContext.Items.Attach(entity);
            _dbContext.Items.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Item item) => _dbContext.Items.Remove(item);

    }
}