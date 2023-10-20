using EcomerceApp.Data;
using EconomicApp.Models.DTO;
using EconomicApp.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EconomicApp.Repositories;

namespace EcomerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IGenericRepository<Income> genericRepository;

        public IncomeController(IGenericRepository<Income> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        // get all income items
        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            // get income items from DB
            var incomes = await genericRepository.GetAllAsync();

            // convert Domain To Dto
            var incomeDto = new List<IncomeDto>();
            
            foreach(var income in incomes)
            {
                incomeDto.Add(new IncomeDto
                {
                    Id = income.Id,
                    Name = income.Name,
                    Amount = income.Amount

                });
            }

            // response all income items
            return Ok(incomeDto);
        }

        // get one income items by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetIncomeById([FromRoute] Guid id)
        {
            // get income item by id from DB
            var income = await genericRepository.GetByIdAsync(id);

            // return Not Found if does'nt find
            if (income == null)
            {
                return NotFound();
            }

            // Convert Domain to Dto
            var incomeDto = new IncomeDto
            {
                Id = income.Id,
                Name = income.Name,
                Amount = income.Amount
            };

            // response income by ID
            return Ok(incomeDto);
        }

        // create a new income item
        [HttpPost]
        public async Task<IActionResult> AddIncom([FromBody] AddIncomeDto addIncomeDto )
        {
            ValidaionIncome(addIncomeDto);
            if (ModelState.IsValid)
            {
                // convert Dto To Damain
                var income = new Income
                {
                    Name = addIncomeDto.Name,
                    Amount = addIncomeDto.Amount
                };

                // create Income Iteme to DB
                income = await genericRepository.AddAsync(income);

                //convert Domain to Dto
                var incomeDto = new IncomeDto
                {
                    Id = income.Id,
                    Name = income.Name,
                    Amount = income.Amount
                };

                // response itemes that added to DB
                return Ok(incomeDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateIncome([FromRoute] Guid id, [FromBody] UpdateIncomeDto updateIncomeDto)
        {
            var req = new AddIncomeDto { Amount = updateIncomeDto.Amount, Name = updateIncomeDto.Name };
            ValidaionIncome(req);

            if (ModelState.IsValid)
            {
                // convert Dto to Domain
                var income = new Income
                {
                    Name = updateIncomeDto.Name,
                    Amount = updateIncomeDto.Amount
                };

                //update income
                income = await genericRepository.UpdateAsync(id, income);

                if (income == null)
                {
                    return NotFound();
                }

                //convert Domain to Dto
                var incomeDto = new IncomeDto
                {
                    Id = income.Id,
                    Name = income.Name,
                    Amount = income.Amount
                };

                // response Updated item
                return Ok(incomeDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteIncome([FromRoute] Guid id)
        {
            var income = await genericRepository.DeleteAsync(id);
            if (income == null)
            {
                return NotFound();
            }

            //convert Domain to Dto
            var incomeDto = new IncomeDto
            {
                Id = income.Id,
                Name = income.Name,
                Amount = income.Amount
            };

            // response deleted item
            return Ok(incomeDto);
        }

        [HttpGet]
        [Route("sum")]
        public async Task<IActionResult> GetSumIncome()
        {
            // get incomes
            var sum = 0;
            var incomes = await genericRepository.GetAllAsync();

            // calculate incomes
            foreach(var income in incomes)
            {
                sum += income.Amount;
            }

            // response sum of incomes
            return Ok(sum);
        }

        //validarion income items
        [NonAction]
        public void ValidaionIncome(AddIncomeDto incomeDto)
        {
            if (incomeDto.Amount < 0)
            {
                throw new Exception("Amount must be positive");
            }
            else if (incomeDto.Name.Length < 3)
            {
                throw new Exception("Name must have at least 3 characters");
            }
        }
    }
}
