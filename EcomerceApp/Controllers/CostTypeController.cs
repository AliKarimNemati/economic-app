using EcomerceApp.Data;
using EconomicApp.Models.DTO;
using EconomicApp.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EconomicApp.Repositories;

namespace EconomicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostTypeController : ControllerBase
    {
        private readonly IGenericRepository<CostType> genericRepository;

        public CostTypeController(IGenericRepository<CostType> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        // get all cost types
        [HttpGet]
        public async Task<IActionResult> GetAllCostType()
        {
            // get constType from DB
            var costTypes = await genericRepository.GetAllAsync();

            // convert Domain To Dto
            var costTypeDtoes = new List<CostTypeDto>();

            foreach (var costType in costTypes)
            {
                costTypeDtoes.Add(new CostTypeDto
                {
                    Id = costType.Id,
                    Name = costType.Name
                });
            }

            // response all costType
            return Ok(costTypeDtoes);
        }

        // get one costType by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCostTypeById([FromRoute] Guid id)
        {
            // get costType by id from DB
            var costType = await genericRepository.GetByIdAsync(id);

            // return Not Found if does'nt find
            if (costType == null)
            {
                return NotFound();
            }

            // Convert Domain to Dto
            var costTypeDto = new CostTypeDto
            {
                Id = costType.Id,
                Name = costType.Name
            };

            // response costType by ID
            return Ok(costTypeDto);
        }

        // create a new costType
        [HttpPost]
        public async Task<IActionResult> AddCostType([FromBody] AddCostTypeDto addCostTypeDto)
        {
            if (ModelState.IsValid)
            {
                // convert Dto To Damain
                var costType = new CostType
                {
                    Name = addCostTypeDto.Name
                };

                // create costType Iteme to DB
                costType = await genericRepository.AddAsync(costType);

                //convert Domain to Dto
                var costTypeDto = new CostTypeDto
                {
                    Id = costType.Id,
                    Name = costType.Name,
                };

                // response itemes that added to DB
                return Ok(costTypeDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // update costType
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCostType([FromRoute] Guid id, [FromBody] UpdateCostTypeDto updateCostTypeDto)
        {
            if (ModelState.IsValid)
            {
                // convert Dto to Domain
                var costType = new CostType { Name = updateCostTypeDto.Name };

                costType = await genericRepository.UpdateAsync(id, costType);

                if (costType == null)
                {
                    return NotFound();
                }

                //convert Domain to Dto
                var costTypeDto = new CostTypeDto
                {
                    Id = costType.Id,
                    Name = costType.Name,
                };

                // response Updated item
                return Ok(costTypeDto);

            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // delete costType from DB
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCostType([FromRoute] Guid id)
        {
            // delete item from DB
            var costType = await genericRepository.DeleteAsync(id);

            if (costType == null)
            {
                return NotFound();
            }

            //convert Domain to Dto
            var costTypeDto = new CostTypeDto
            {
                Id = costType.Id,
                Name = costType.Name,
            };

            // response deleted item
            return Ok(costTypeDto);
        }
    }
}
