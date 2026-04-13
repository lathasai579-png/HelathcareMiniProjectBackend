using Microsoft.AspNetCore.Mvc;
using HealthcareApp.BLL.DTOs;
using HealthcareApp.BLL.Services;
using Microsoft.AspNetCore.Mvc;
namespace HealthcareApp.Web.Controllers
{
        public class PatientController : Controller
        {
            private readonly PatientService _service;

            public PatientController(PatientService service)
            {
                _service = service;
            }

            public async Task<IActionResult> Index(string search)
            {
                try
                {
                    var data = string.IsNullOrEmpty(search)
                        ? await _service.GetAllAsync()
                        : await _service.SearchAsync(search);

                    return View(data);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(PatientDto dto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return View(dto);

                    await _service.AddAsync(dto);

                    TempData["msg"] = "Patient Added Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(dto);
                }
            }



        public async Task<IActionResult> Edit(int id)
            {
                try
                {
                    var data = await _service.GetByIdAsync(id);

                    if (data == null)
                        return NotFound();

                    return View(data);
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.Message;
                    return RedirectToAction("Index");
                }
            }

            [HttpPost]
            public async Task<IActionResult> Edit(PatientDto dto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return View(dto);

                    await _service.UpdateAsync(dto);

                    TempData["msg"] = "Patient Updated Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(dto);
                }
            }

            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    await _service.DeleteAsync(id);

                    TempData["msg"] = "Patient Deleted Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.Message;
                    return RedirectToAction("Index");
                }
            }

            public async Task<IActionResult> Details(int id)
            {
                try
                {
                    var data = await _service.GetByIdAsync(id);

                    if (data == null)
                        return NotFound();

                    return View(data);
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.Message;
                    return RedirectToAction("Index");
                }
            }
        }
    }