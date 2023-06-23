using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practical_18.Models;
using Practical_18.ViewModels;
using System.Text;

namespace Practical_18.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Details()
        {
            
            List<StudentViewModel> studentList = new List<StudentViewModel>();
           
            using (var response = await _httpClient.GetAsync("https://localhost:44344/api/StudentViewModels"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                studentList = JsonConvert.DeserializeObject<List<StudentViewModel>>(apiResponse);
            }
            
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            var json = new StringContent(JsonConvert.SerializeObject(studentViewModel), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PostAsync("https://localhost:44344/api/StudentViewModels", json))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Student");
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            using (var response = await _httpClient.GetAsync($"https://localhost:44344/api/StudentViewModels/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
                return View(student);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel studentViewModel)
        {
            var json = new StringContent(JsonConvert.SerializeObject(studentViewModel), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PutAsync($"https://localhost:44344/api/StudentViewModels/{studentViewModel.Id}", json))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Student");
                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.DeleteAsync("https://localhost:44344/api/StudentViewModels/"+id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Student");
                }
            }
            return View();
        }
    }
}
