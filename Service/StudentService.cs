using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class StudentService
    {
        
        public List<Student> Get()
        {
            
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }

            return students;
        }

        public List<Student> Search(string query)
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(x => x.StudentName.ToLower().Contains(query.ToLower()) 
                                                       || x.StudentLastname.ToLower().Contains(query.ToLower()))
                    .ToList();
            }

            return students;
        }
        
        public Student GetById(int ID)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(ID);
            }

            return student;
        }

        public void Insert(Student student)
        {
            using var context = new SchoolContext();
            student.CreatedAt = DateTime.Now;
            student.isActive = true;
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student, int ID)
        {
            using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(ID);

                studentNew.StudentLastname = string.IsNullOrWhiteSpace(student.StudentLastname) ? studentNew.StudentLastname : student.StudentLastname;
                studentNew.StudentName = string.IsNullOrWhiteSpace(student.StudentName) ? studentNew.StudentName : student.StudentName;
                studentNew.isActive = true;
                studentNew.StudentCode = student.StudentCode;
                studentNew.StudentAddress = string.IsNullOrWhiteSpace(student.StudentAddress) ? studentNew.StudentAddress : student.StudentAddress;
                studentNew.UpdatedAt = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using var context  = new SchoolContext();
            var student = context.Students.Find(ID);
            //context.Students.Remove(student);
            student.isActive = false;
            
            context.SaveChanges();
        }
        
        
    }
}