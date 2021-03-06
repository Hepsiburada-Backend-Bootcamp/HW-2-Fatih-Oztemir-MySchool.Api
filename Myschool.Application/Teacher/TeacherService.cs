using AutoMapper;
using Myschool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Myschool.Application.Teacher
{
    public class TeacherService:ITeacherService
    {
        private readonly ILogger<TeacherService> _logger;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository,IMapper mapper,ILogger<TeacherService> logger)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public Task Add(TeacherDto teacher)
        {
            return _teacherRepository.Add(_mapper.Map<Myschool.Domain.Entites.Teacher>(teacher));
        }
        public async Task<List<TeacherDto>> Get(Expression<Func<TeacherDto,bool>> filter)
        {
            //mapper da bir problem var. Hatayı çöz.
            var dtoFilter=_mapper.Map<Expression<Func<Myschool.Domain.Entites.Teacher, bool>>>(filter);
            var result= await _teacherRepository.Get(dtoFilter);
            return _mapper.Map<List<TeacherDto>>(result);
        }
        public Task Delete(TeacherDto teacher)
        {
            return _teacherRepository.Delete(_mapper.Map<Myschool.Domain.Entites.Teacher>(teacher));
        }
        public Task Update(TeacherDto teacher)
        {
            return _teacherRepository.Update(_mapper.Map<Myschool.Domain.Entites.Teacher>(teacher));
        }

        public async Task<List<TeacherDto>> GetAll()
        {
            //var dtoList = _teacherRepository.GetAll();
            var result = await _teacherRepository.GetAll();
            return _mapper.Map<List<TeacherDto>>(result);
        }
        public async Task<TeacherDto> GetByCourse(Guid courseId)
        {
            var result =await _teacherRepository.GetByCourse(courseId);
            return _mapper.Map<TeacherDto>(result);
        }
    }
}
