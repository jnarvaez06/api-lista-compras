using ApiListaCompras.DTOs;
using ApiListaCompras.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiListaCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ICommonService<ItemDTO> _itemService;

        public ItemController(
            [FromKeyedServices("ItemService")]ICommonService<ItemDTO> itemService
        ){
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> Get() => await _itemService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetById(int id)
        {
            var itemDto = await _itemService.GetById(id);

            return (itemDto == null) ? NotFound() : Ok(itemDto);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> Add(ItemDTO itemDTO)
        {
            var ItemDto = await _itemService.Add(itemDTO);

            return Ok(ItemDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDTO>> Update(int id, ItemDTO itemDTO)
        {
            var itemDto = await _itemService.Update(id, itemDTO);

            return (itemDto == null) ? NotFound() : Ok(itemDto); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDTO>> Delete(int id)
        {
            var itemDto = await _itemService.Delete(id);

            return (itemDto==null) ? NotFound() : Ok(itemDto);
        }
    }
}
