using EcomerceApp.Data;
using EconomicApp.Models.Domain;
using EconomicApp.Models.DTO;
using EconomicApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EconomicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : ControllerBase
    {
        private readonly IGenericRepository<Cost> genericRepository;

        public CostController(IGenericRepository<Cost> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        // get all cost items
        [HttpGet]
        public async Task<IActionResult> GetAllCost()
        {
            // get const from DB
            var costs = await genericRepository.GetAllAsync();

            // convert Domain To Dto
            var costDtoes = new List<CostDto>();

            foreach (var cost in costs)
            {
                costDtoes.Add(new CostDto
                {
                    Id = cost.Id,
                    Name = cost.Name,
                    Amount = cost.Amount,
                    Type = cost.Type,
                    CostFile = cost.CostFile,
                });
            }

            // response all cost
            return Ok(costDtoes);
        }

        // get one cost by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCostById([FromRoute] Guid id)
        {
            // get cost by id from DB
            var cost = await genericRepository.GetByIdAsync(id);

            // return Not Found if does'nt find
            if (cost == null)
            {
                return NotFound();
            }

            // Convert Domain to Dto
            var costDto = new CostDto
            {
                Id = cost.Id,
                Name = cost.Name,
                Amount = cost.Amount,
                Type = cost.Type,
                CostFile = cost.CostFile
            };

            // response cost by ID
            return Ok(costDto);
        }

        // create a new cost
        [HttpPost]
        public async Task<IActionResult> AddCost([FromBody] AddCostDto addCostDto)
        {
            ValidaionCost(addCostDto);

            if (ModelState.IsValid)
            {
                // convert Dto To Damain
                var cost = new Cost
                {
                    Name = addCostDto.Name,
                    Amount = addCostDto.Amount,
                    TypeId = addCostDto.TypeId,
                    CostFileId = addCostDto.CostFileId,  
                };

                // create cost Iteme to DB
                cost = await genericRepository.AddAsync(cost);

                //convert Domain to Dto
                var costDto = new CostDto
                {
                    Id = cost.Id,
                    Name = cost.Name,
                    Amount = cost.Amount,
                    Type = cost.Type,
                    CostFile = cost.CostFile
                };

                // response itemes that added to DB
                return Ok(costDto);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // update cost
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCost([FromRoute] Guid id, [FromBody] UpdateCostDto updateCostDto)
        {
            var req = new AddCostDto { Amount = updateCostDto.Amount, Name = updateCostDto.Name, TypeId = updateCostDto.TypeId }; 
            ValidaionCost(req);

            if (ModelState.IsValid)
            {
                // convert Dto to Domain
                var cost = new Cost
                {
                    Name = updateCostDto.Name,
                    Amount = updateCostDto.Amount,
                    TypeId = updateCostDto.TypeId,
                    CostFileId = updateCostDto.CostFileId
                };

                cost = await genericRepository.UpdateAsync(id, cost);

                //check that is exist in DB
                if (cost == null)
                {
                    return NotFound();
                }

                //convert Domain to Dto
                var costDto = new CostDto
                {
                    Id = cost.Id,
                    Name = cost.Name,
                    Amount = cost.Amount,
                    Type = cost.Type,
                    CostFile = cost.CostFile
                };

                // response Updated item
                return Ok(costDto);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // delete cost from DB
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCost([FromRoute] Guid id)
        {
            var cost = await genericRepository.DeleteAsync(id);

            // check that is exist
            if (cost == null)
            {
                return NotFound();
            }

            //convert Domain to Dto
            var costDto = new CostDto
            {
                Id = cost.Id,
                Name = cost.Name,
                Amount = cost.Amount,
                Type = cost.Type,
                CostFile = cost.CostFile
            };

            // response deleted item
            return Ok(costDto);
        }

        [HttpGet]
        [Route("sum")]
        public async Task<IActionResult> GetSumCost()
        {
            // get costs
            var sum = 0;
            var costs = await genericRepository.GetAllAsync();

            // calculate costs
            foreach (var cost in costs)
            {
                sum += cost.Amount;
            }

            // response sum of costs
            return Ok(sum);
        }

        //validarion income items
        [NonAction]
        public void ValidaionCost(AddCostDto costDto)
        {
            if (costDto.Amount < 0)
            {
                throw new Exception("Amount must be positive");
            }
            else if (costDto.Name.Length < 3)
            {
                throw new Exception("Name must have at least 3 characters");
            }
        }
    }
}
