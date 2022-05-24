using ECommerceApp.Entities;

namespace ECommerceApp.DataAccess.Abstract
{
    public interface ICartDal : IRepository<Cart>
    {
        Cart GetByUserId(string userId);
    }
}
