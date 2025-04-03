using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdatedItemDto updatedItemDto)
        {
            var existingItem = items.Where(item => item.Id == id).SingleOrDefault();

            var updateItem = existingItem with
            {
                Name = updatedItemDto.Name,
                Description = updatedItemDto.Description,
                Price = updatedItemDto.Price,
            };

            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items[index] = updateItem;

            return NoContent();
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            var existingItem = items.Where(item => item.Id == id).SingleOrDefault();
            var index = items.FindIndex(existingItem => existingItem.Id == id);

            items.RemoveAt(index);

            return NoContent();

        }

    }

}
