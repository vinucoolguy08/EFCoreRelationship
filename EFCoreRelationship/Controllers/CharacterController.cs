using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFCoreRelationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddCharacterDto character)
        {    
            return Ok(await _characterService.AddCharacter(character));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateCharacterDto character)
        {
            var resposne = await _characterService.UpdateCharacter(character);
            if(resposne.Data == null)
            {
                return NotFound(resposne);
            }
            return Ok(resposne);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resposne = await _characterService.DeleteCharacterById(id);
            if (resposne.Data == null)
            {
                return NotFound(resposne);
            }
            return Ok(resposne);

        }
    }
}
