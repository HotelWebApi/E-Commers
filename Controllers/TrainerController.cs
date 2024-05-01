using DataAccessLayer.DTOs;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Trainers.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainerController(ITrainerService trainerservice) : ControllerBase
{
    private readonly ITrainerService _trainerservice = trainerservice;
    [HttpGet("Get-All")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var trainers = await _trainerservice.GetAllAsync();
            return Ok(trainers);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("By-Id")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var trainer = await _trainerservice.GetByIdAsync(id);
            return Ok(trainer);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("filter/color")]
    public async Task<IActionResult> FilterColor(string color)
    {
        try
        {
            var filter = await _trainerservice.FilterByColorAsync(color);
            return Ok(filter);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("filter/brand")]
    public async Task<IActionResult> FilterBrand(string brand)
    {
        try
        {
            var filter = await _trainerservice.FilterByBrandAsync(brand);
            return Ok(filter);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("filter/price")]
    public async Task<IActionResult> FilterPrice(decimal minPrice, decimal maxPrice)
    {
        try
        {
            var filter = await _trainerservice.FilterByPriceAsync(minPrice, maxPrice);
            return Ok(filter);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AddTrainerDto addTrainer)
    {
        try
        {
            await _trainerservice.AddAsync(addTrainer);
            return Ok("Added");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Edit")]
    public async Task<IActionResult> Update(TrainerDto trainersDto)
    {
        try
        {
            await _trainerservice.UpdateAsync(trainersDto);
            return Ok("Updated");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _trainerservice.DeleteAsync(id);
            return Ok("Deleted");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}