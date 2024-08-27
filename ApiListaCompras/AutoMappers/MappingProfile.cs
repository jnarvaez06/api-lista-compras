using ApiListaCompras.DTOs;
using ApiListaCompras.Models;
using AutoMapper;

namespace ApiListaCompras.AutoMappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // MAPPER PARA ENTIDAD USUARIO
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
        }
    }
}
