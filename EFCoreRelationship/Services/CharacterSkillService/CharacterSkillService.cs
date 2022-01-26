using AutoMapper;
using EFCoreRelationship.Data;
using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.DTO.CharacterSkill;
using EFCoreRelationship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EFCoreRelationship.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CharacterSkillService(DataContext dataContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        private int GetUserId => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _dataContext.Characters
                    .Include(x => x.Weapon)
                    .Include(x => x.CharacterSkill).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(x => x.Id == newCharacterSkill.CharacterId && x.User.Id == GetUserId);

                if(character is null)
                {
                    response.Success = false;
                    response.Message = "Character not found";
                    return response;
                }

                Skill skill = await _dataContext.Skills.FirstOrDefaultAsync(x => x.Id == newCharacterSkill.SkillId);
                
                if (skill is null)
                {
                    response.Success = false;
                    response.Message = "Skill not found";
                    return response;
                }

                CharacterSkill characterSkill = new CharacterSkill
                {
                    Character = character,
                    Skill = skill
                };

               await _dataContext.AddAsync(characterSkill);
               await _dataContext.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
