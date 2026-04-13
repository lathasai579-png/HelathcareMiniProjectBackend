using HealthcareApp.BLL.DTOs;
using HealthcareApp.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApp.Web.Controllers
{
   
        public class DoctorController : Controller
        {
            private readonly DoctorService _service;

            public DoctorController(DoctorService service)
            {
                _service = service;
            }

            // GET: /Doctor/Index
            public async Task<IActionResult> Index()
            {
                try
                {
                    var data = await _service.GetAllAsync();
                    return View(data);
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return View(new List<DoctorDto>());
                }
            }

            // GET: /Doctor/Create  ⭐ FIX FOR 405 ERROR
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            // POST: /Doctor/Create
        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(dto);   // IMPORTANT

                await _service.AddAsync(dto);

                TempData["Success"] = "Doctor Added Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(dto);
            }
        }

        // GET: /Doctor/Edit/5
        [HttpGet]
            public async Task<IActionResult> Edit(int id)
            {
                try
                {
                    var data = await _service.GetByIdAsync(id);
                    if (data == null)
                        return RedirectToAction("Index");

                    return View(data);
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return RedirectToAction("Index");
                }
            }

            // POST: /Doctor/Edit
            [HttpPost]
            public async Task<IActionResult> Edit(DoctorDto dto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return View(dto);

                    await _service.UpdateAsync(dto);

                    TempData["Success"] = "Doctor Updated Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return View(dto);
                }
            }

            // GET: /Doctor/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    await _service.DeleteAsync(id);
                    TempData["Success"] = "Doctor Deleted Successfully";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }

                return RedirectToAction("Index");
            }
        }
    }