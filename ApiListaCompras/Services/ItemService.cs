using ApiListaCompras.DTOs;
using ApiListaCompras.Models;
using ApiListaCompras.Repository;
using AutoMapper;

namespace ApiListaCompras.Services
{
    public class ItemService : ICommonService<ItemDTO>
    {
        private IRepository<Item> _itemRepository;
        private IMapper _mapper;

        public ItemService(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDTO> Add(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);

            await _itemRepository.Add(item);
            await _itemRepository.Save();

            var itemDto = _mapper.Map<ItemDTO>(item);

            return itemDto;
        }

        public async Task<IEnumerable<ItemDTO>> Get()
        {
            var items = await _itemRepository.Get();

            return items.Select(i => _mapper.Map<ItemDTO>(i));
        }

        public async Task<ItemDTO> GetById(int id)
        {
            var item = await _itemRepository.GetById(id);

            if (item != null)
            {
                var itemDto = _mapper.Map<ItemDTO>(item);

                return itemDto;
            }

            return null;
        }

        public async Task<ItemDTO> Update(int id, ItemDTO itemDTO)
        {
            var item = await _itemRepository.GetById(id);

            if(item != null)
            {
                item = _mapper.Map<ItemDTO, Item>(itemDTO, item);

                _itemRepository.Update(item);
                await _itemRepository.Save();

                var itemDto = _mapper.Map<ItemDTO>(item);

                return itemDto;
            }

            return null;
        }
        public async Task<ItemDTO> Delete(int id)
        {
            var item = await _itemRepository.GetById(id);

            if (item != null)
            {
                var itemDto = _mapper.Map<ItemDTO>(item);

                _itemRepository.Delete(item);
                await _itemRepository.Save();

                return itemDto;
            }

            return null;
        }
    }
}
