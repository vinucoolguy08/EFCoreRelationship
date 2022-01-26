using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EFCoreRelationship.Controllers
{
    [Authorize(Roles = "Player")]
    [Route("api/[controller]")]
    [ApiController] 
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
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
