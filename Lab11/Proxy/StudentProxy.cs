using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab11.Models;
using Newtonsoft.Json;

namespace Lab11.Proxy
{
    public class StudentProxy
    {
        const string urlBase = "http://localhost:5002";
        public async Task<ResponseProxy<StudentModel>> GetStudentsAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/student");
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = true,
                    Codigo = (int) HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = students
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }

        public async Task<ResponseProxy<StudentModel>> GetStudentByIdAsync(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase,"/api", "/student", "/", id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<StudentModel>(result);
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int) HttpStatusCode.OK,
                    Exitoso = true,
                    Mensaje = "Exito",
                    objeto = student
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }

        public async Task<ResponseProxy<StudentModel>> SearchStudentsAsync(string query)
        {
            var client = new HttpClient();
            
            client.BaseAddress = new Uri(urlBase);
            var request = JsonConvert.ToString(query);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var url = string.Concat(urlBase, "/api", "/student","/search");
            var response = client.PostAsync(url, content).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = true,
                    Codigo = (int) HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = students
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }

        public async Task<ResponseProxy<StudentModel>> InsertAsync(StudentModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api", "/student");
            var response = client.PostAsync(url, content).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }

        public async Task<ResponseProxy<StudentModel>> UpdateStudentAsync(StudentModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api", "/student");
            var response = client.PutAsync(url, content).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "error"
                };
            }
        }

        public async Task<ResponseProxy<StudentModel>> DeleteStudentAsync(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api", "/student","/",id);
            var response = client.DeleteAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<StudentModel>(result);
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int) HttpStatusCode.OK,
                    Exitoso = true,
                    Mensaje = "Exito",
                    objeto = student
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }
    }
}