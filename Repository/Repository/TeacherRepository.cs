﻿using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Teacher;
using DTO.Response.Teacher;
using Repository.IRepository;

namespace Repository.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        TeacherDAO teacherDAO;
        IMapper _mapper;

        public TeacherRepository(FAPDbContext context, IMapper mapper)
        {
            teacherDAO = new TeacherDAO(context);
            _mapper = mapper;
        }

        public bool AddTeacher(TeacherAddDTO teacher)
        {
            Teacher t = _mapper.Map<Teacher>(teacher);
            t.Account = null;
            return teacherDAO.AddTeacher(_mapper.Map<Teacher>(teacher));
        }

        public bool DeleteTeacher(int id)
        {
            return teacherDAO.DeleteTeacher(id);
        }

        public TeacherResponseDTO? GetTeacherById(int id)
        {
            return _mapper.Map<TeacherResponseDTO>(teacherDAO.GetTeacherById(id));
        }

        public string GetTeacherCode(string namecut)
        {
            return teacherDAO.GetTeacherCode(namecut);
        }

        public List<TeacherResponseDTO> GetTeachers()
        {
            return _mapper.Map<List<TeacherResponseDTO>>(teacherDAO.GetTeachers());
        }

        public bool UpdateTeacher(TeacherUpdateDTO teacher)
        {
            return teacherDAO.UpdateTeacher(_mapper.Map<Teacher>(teacher));
        }
    }
}
