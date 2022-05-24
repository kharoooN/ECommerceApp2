using ECommerceApp.Entities;

namespace ECommerceApp.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByIdWithProducts(int id);
    }
}
