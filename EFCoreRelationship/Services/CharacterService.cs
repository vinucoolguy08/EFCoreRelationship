using AutoMapper;
using EFCoreRelationship.Data;
using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.Models;
using EFCoreRelationship.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EFCoreRelationship.Services
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character() { Id =1, Name = "Cool" }
        };
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character newCharacters = _mapper.Map<Character>(character);
                newCharacters.User = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == GetUserId);
                await _dataContext.Characters.AddAsync(newCharacters);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = _dataContext.Characters.Where(x => x.User.Id == GetUserId).Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var characters = await _dataContext.Characters.Where(x => x.User.Id == GetUserId).ToListAsync();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _dataContext.Characters.FirstOrDefaultAsync(x => x.Id == id && x.User.Id == GetUserId);
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character characterDetail = characters.Find(x => x.Id == character.Id);
                characterDetail.Name = character.Name;
                characterDetail.HitPoint = character.HitPoint;
                characterDetail.Strength = character.Strength;
                characterDetail.Intelligence = character.Intelligence;
                characterDetail.Defence = character.Defence;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(characterDetail);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await _dataContext.Characters.FirstOrDefaultAsync(x => x.Id == id && x.User.Id == GetUserId);
                if(character != null)
                {
                    _dataContext.Characters.Remove(character);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = _dataContext.Characters.Where(x => x.User.Id == id).Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
                }
  
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
