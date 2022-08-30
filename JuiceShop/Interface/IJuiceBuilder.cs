

using JuiceShop.Entity;

namespace JuiceShop.Interface
{
    public interface IJuiceBuilder
    {
        Juice GetJuice();
        void CreateNewJuice(Order order);
    }
}
