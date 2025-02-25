﻿using Backend.DataObjects;
using Backend.Interfaces;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Vrátí záznamy všech zaměstnanců
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return Ok(employees);
        }

        /// <summary>
        /// Vrátí záznam zaměstnance na základě zadaného ID
        /// </summary>

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee.EmployeeToBO());
        }

        /// <summary>
        /// Uloží nový záznam na základě přiloženého JSON
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = await _employeeRepository.CreateAsync(employee);

            if (employeeModel == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeModel.Id }, employeeModel);
        }

        /// <summary>
        /// Upravý údaje zaměstnance na základě zadaného ID a json údajů zaměstnance v těle požadavku
        /// </summary>

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeCO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = await _employeeRepository.UpdateAsync(id, employee);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel);
        }

        /// <summary>
        /// Odstraní záznam zaměstnance z databáze na základě zadaného ID
        /// </summary>

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = await _employeeRepository.DeleteAsync(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
