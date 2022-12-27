//using Microsoft.JSInterop;
//using ObjCRuntime;
using System.Data;
//using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BikeSC.Data
{
    internal class StudentService
    {     
       private static void SaveAll(List<StudentModel> students)
        {
           string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string GetAppStudentsFilePath = Utils.GetAppStudentsFilePath();
            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }
            // string path = "D:\\AD\\BikeSC\\student1.json";
            var json = JsonSerializer.Serialize(students);
            File.WriteAllText(GetAppStudentsFilePath, json);
        }   
        public static List<StudentModel>WriteData(string name, string address, string phone, string email)
        {
      
             //List<StudentModel> students = new List<StudentModel>();
            List<StudentModel> students = ReadData();
            students.Add(
                new StudentModel
                {
                    Name = name,
                    Address = address,
                    Phone = phone,
                    Email = email
                }
            );
            SaveAll(students);
            return students;
        }
        public static List<StudentModel>ReadData()
        {
            // string _filePath = "D:\\AD\\BikeSC\\student1.json";
             string appStudentsFilePath = Utils.GetAppStudentsFilePath();
            
            if (!File.Exists(appStudentsFilePath))
            {
                return new List<StudentModel>();
            }
            var json = File.ReadAllText(appStudentsFilePath);
            //if (json == "")
            //{
            //    return new List<StudentModel>();
            //}
            return JsonSerializer.Deserialize<List<StudentModel>>(json);              
        }
        public static List<StudentModel> Update(Guid id, string name, string address, string phone, string email)
        {
            List<StudentModel> students = ReadData();
            StudentModel studentToUpdate = students.FirstOrDefault(x => x.Id == id);

            if (studentToUpdate == null)
            {
                throw new Exception("Todo not found.");
            }

            studentToUpdate.Name = name;
            studentToUpdate.Address = address;
            studentToUpdate.Phone = phone;
            studentToUpdate.Email = email;
            SaveAll(students);
            return students;
        }
        //public static User GetById(Guid id)
        //{
        //    List<StudentModel> students = ReadData();
        //    return students.FirstOrDefault(x => x.Id == id);
        //}
        public static void DeleteByUserId(Guid userId)
        {
            string _filePath = "D:\\AD\\BikeSC\\student1.json";
            //string todosFilePath = Utils.GetTodosFilePath(userId);
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
        public static List<StudentModel> Delete(Guid id)
        {
            List<StudentModel> students = ReadData();
            StudentModel student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            //DeleteByUserId(id);
            students.Remove(student);
            SaveAll(students);
            return students;
        }
    }
}
