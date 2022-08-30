using JuiceShop.Entity;
using JuiceShop.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JuiceShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuiceController : ControllerBase
    {
        private readonly ILogger<JuiceController> _logger;
        private readonly IJuiceBuilder _juiceBuilder;

        public JuiceController(ILogger<JuiceController> logger, IJuiceBuilder juiceBuilder)
        {
            _logger = logger;
            _juiceBuilder = juiceBuilder;
        }

        [HttpGet]
        public Juice Get(int NumberOfPeople, int NumberOfPeopleNotInterest)
        {
            var order = new Order { NumberOfPeople = NumberOfPeople, NumberOfPeopleNotInterest = NumberOfPeopleNotInterest };
            _juiceBuilder.CreateNewJuice(order);
            return _juiceBuilder.GetJuice();
        }
    }
}
