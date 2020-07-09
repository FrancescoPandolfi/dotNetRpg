using Microsoft.AspNetCore.Mvc;
using dotNetRpg.models;
using System.Collections.Generic;
using System.Linq;
using dotNetRpg.Services.CharacterService;
using System.Threading.Tasks;
using dotNetRpg.Dtos.Character;

namespace dotNetRpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {

    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
      _characterService = characterService;

    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
      return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
      return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
    {
      return Ok(await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
      if(response.Data == null) {
        return NotFound(response);
      }
      return Ok(response);
    }

  }
}