
using JuiceShop.Entity;
using JuiceShop.Interface;

namespace JuiceShop.Services
{
    public class JuiceBuilder : IJuiceBuilder
    {
        private IManual _manual;
        protected Juice juice;
        public JuiceBuilder(IManual manual)
        {
            this._manual = manual;
        }
        public void CreateNewJuice(Order order)
        {
            juice = new Juice();
            int totalNumberOfPeople = this.GetNumberOfPeople(order);
            juice.NumberOfFruit = this._manual.NumberOfFruits(totalNumberOfPeople);
        }

        public Juice GetJuice()
        {
            return juice;
        }

        private int GetNumberOfPeople(Order order)
        {
            return order.NumberOfPeople - order.NumberOfPeopleNotInterest;
        }
    }
}
