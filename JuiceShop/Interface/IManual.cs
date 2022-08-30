

using JuiceShop.Entity;

namespace JuiceShop.Interface
{
    public interface IManual
    {
        Orange GetFruit();
        int NumberOfFruits(int numberOfPeoples);
        object NumberOfFruits();
    }
}
