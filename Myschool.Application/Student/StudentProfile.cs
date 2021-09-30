﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Myschool.Application.Student
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDto, Myschool.Domain.Entites.Student>().ReverseMap();
        }
    }
}
