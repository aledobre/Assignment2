using Proiect.bll.Models;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class StudentAPIMapper : IStudentAPIMapper
    {
        public StudentModel Map(StudentAPIModel studentAPIModel)
        {
            if (studentAPIModel == null)
            {
                return null;
            }

            return new StudentModel
            {
                Token = studentAPIModel.Token,
                Username = studentAPIModel.Username,
                EncPassword = studentAPIModel.EncPassword,
                Name = studentAPIModel.Name,
                Email = studentAPIModel.Email,
                GroupNo = studentAPIModel.GroupNo,
                Hobby = studentAPIModel.Hobby
            };
        }

        public StudentAPIModel Map(StudentModel studentModel)
        {
            if (studentModel == null)
            {
                return null;
            }
            return new StudentAPIModel
            {
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