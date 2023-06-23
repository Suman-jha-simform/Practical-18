using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical_18.Models;
using Practical_18.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Practical_18.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentViewModelsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public StudentViewModelsController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/StudentViewModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetStudentViewModel()
        {

            var students =   await _context.Students.ToListAsync();
            return _mapper.Map<List<Student>, List<StudentViewModel>>(students);
        }

        // GET: api/StudentViewModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> GetStudentViewModel(int id)
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return _mapper.Map<Student, StudentViewModel>(student);
        }

        // PUT: api/StudentViewModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentViewModel([FromBody]StudentViewModel studentViewModel)
        {
            var std = _context.Students.Find(studentViewModel.Id);
            if (std.Id != studentViewModel.Id)
            {
                return BadRequest();
            }

            _mapper.Map<StudentViewModel, Student>(studentViewModel);
          
            std.Name = studentViewModel.Name;
            std.Department = studentViewModel.Department;
            std.Grades = studentViewModel.Grades;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentViewModelExists(std.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentViewModels
        [HttpPost]
        public async Task<ActionResult<StudentViewModel>> CreateStudentViewModel([FromBody]StudentViewModel studentViewModel)
        {
          if (_context.StudentViewModel == null)
          {
              return Problem("Entity set 'ApplicationContext.StudentViewModel'  is null.");
          }
            var student =  _mapper.Map<StudentViewModel,Student>(studentViewModel);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(studentViewModel);
        }

        // DELETE: api/StudentViewModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentViewModel(int id)
        {
            if (_context.StudentViewModel == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentViewModelExists(int id)
        {
            return (_context.StudentViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
