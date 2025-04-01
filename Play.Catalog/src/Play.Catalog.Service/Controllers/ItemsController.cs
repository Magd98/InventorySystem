using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
          new ItemDto(Guid.NewGuid(),"Potion","Restores a samll amount of Hp",5,DateTimeOffset.UtcNow),
          new ItemDto(Guid.NewGuid(),"Antidote","Removes Poison effects",10,DateTimeOffset.UtcNow),
          new ItemDto(Guid.NewGuid(),"Red Stone","+15 ATK Dmg",20,DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        [HttpGet("{id}")]
        public ItemDto? GetById(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }
    }

}
