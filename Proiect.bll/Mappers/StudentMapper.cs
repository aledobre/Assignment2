using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Mappers
{
    public class StudentMapper : IStudentMapper
    {
        public StudentModel Map(StudentDTO studentDTO)
        {
            if (studentDTO == null)
            {
                return null;
            }

            return new StudentModel
            {
                Id = studentDTO.Id,
                Token = studentDTO.Token,
                Username = studentDTO.Username,
                EncPassword = studentDTO.EncPassword,
                Name = studentDTO.Name,
                Email = studentDTO.Email,
                GroupNo = studentDTO.GroupNo,
                Hobby = studentDTO.Hobby
            };
        }

        public StudentDTO Map(StudentModel studentModel)
        {
            if (studentModel == null)
            {
                return null;
            }
            return new StudentDTO
            {
                Id = studentModel.Id,
                Token = studentModel.Token,
                Username = studentModel.Username,
                EncPassword = studentModel.EncPassword,
                Name = studentModel.Name,
                Email = studentModel.Email,
                GroupNo = studentModel.GroupNo,
                Hobby = studentModel.Hobby
            };
        }
    }
}
