using Contract.Context;

namespace Import
{
    public class PersistProducts
    {
        public PersistProducts(ImportDataDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public static void PersistProduct()
        {

        }

        public ImportDataDbContext DbContext { get; }
    }
}
