using AutoMapper;
using dotNetRpg.Dtos.Character;
using dotNetRpg.models;

namespace dotNetRpg
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
          CreateMap<Character, GetCharacterDto>();
          CreateMap<AddCharacterDto, Character>();
        }
    }
}