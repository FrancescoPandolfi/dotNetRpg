using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetRpg.Dtos.Character;
using dotNetRpg.models;

namespace dotNetRpg.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        //  Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}