using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotNetRpg.Dtos.Character;
using dotNetRpg.models;

namespace dotNetRpg.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {

    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    private static List<Character> characters = new List<Character> {
          new Character(),
          new Character { Id = 1, Name = "Sam"}
        };

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character = _mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(character);

      serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      try 
      {

        Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
        character.Name = updatedCharacter.Name;
        character.Class = updatedCharacter.Class;
        character.Defense = updatedCharacter.Defense;
        character.HitPoints = updatedCharacter.HitPoints;
        character.Intelligence = updatedCharacter.Intelligence;
        character.Strenght = updatedCharacter.Strenght;

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
      }
      catch(Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
        return serviceResponse;
      

    }

    // public Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    // {
    //   return "0";
    //   // ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

    //   // Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
    //   // character.Name = updatedCharacter.Name;
    //   // character.Class = updatedCharacter.Class;
    //   // character.Defense = updatedCharacter.Defense;
    //   // character.HitPoints = updatedCharacter.HitPoints;
    //   // character.Intelligence = updatedCharacter.Intelligence;
    //   // character.Strenght = updatedCharacter.Strenght;

    //   // serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
    //   // return serviceResponse;
    // }
  }
}