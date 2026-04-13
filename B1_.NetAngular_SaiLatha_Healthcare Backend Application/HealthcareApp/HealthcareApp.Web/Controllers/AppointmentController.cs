using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HealthcareApp.BLL.Services;
using HealthcareApp.DAL;
using HealthcareApp.Entities;
using HealthcareApp.Web.ViewModels;
using System;
using System.Linq;

public class AppointmentController : Controller
{
    private readonly AppointmentService _service;
    private readonly AppDbContext _context;

    public AppointmentController(AppointmentService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _service.GetAll();

        var vmList = data.Select(a => new AppointmentViewModel
        {
            AppointmentId = a.AppointmentId,
            PatientName = a.Patient.Name,
            DoctorName = a.Doctor.Name,
            Date = a.Date,
            TimeSlot = a.TimeSlot,
            Status = a.Status.ToString()
        }).ToList();

        return View(vmList); // ✅ now matches View
    }

    private void LoadDropdowns()
    {
        ViewBag.Patients = new SelectList(_context.Patients, "PatientId", "Name");
        ViewBag.Doctors = new SelectList(_context.Doctors, "DoctorId", "Name");
    }

    private List<string> GetTimeSlots()
    {
        return new List<string>
        {
            "09:00 AM","10:00 AM","11:00 AM",
            "12:00 PM","01:00 PM","02:00 PM",
            "03:00 PM","04:00 PM","05:00 PM","06:00 PM"
        };
    }

    private List<string> GetStatusList()
    {
        return new List<string> { "Booked", "Completed", "Cancelled" };
    }

    // CREATE
    public IActionResult Create()
    {
        LoadDropdowns();
        ViewBag.TimeSlots = GetTimeSlots();
        return View();
    }

    [HttpPost]
    public IActionResult Create(AppointmentViewModel vm)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var obj = new Appointment
                {
                    PatientId = vm.PatientId,
                    DoctorId = vm.DoctorId,
                    Date = vm.Date,
                    TimeSlot = vm.TimeSlot,
                    Status = AppointmentStatus.Booked
                };

                _service.Create(obj);
                TempData["success"] = "Appointment created!";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        LoadDropdowns();
        ViewBag.TimeSlots = GetTimeSlots();
        return View(vm);
    }

    // EDIT
    public IActionResult Edit(int id)
    {
        var data = _service.GetById(id);

        var vm = new AppointmentViewModel
        {
            AppointmentId = data.AppointmentId,
            PatientId = data.PatientId,
            DoctorId = data.DoctorId,
            Date = data.Date,
            TimeSlot = data.TimeSlot,
            Status = data.Status.ToString()
        };

        LoadDropdowns();
        ViewBag.TimeSlots = GetTimeSlots();
        ViewBag.StatusList = GetStatusList();

        return View(vm);
    }

    [HttpPost]
    public IActionResult Edit(AppointmentViewModel vm)
    {
        try
        {
            var data = _service.GetById(vm.AppointmentId);

            data.PatientId = vm.PatientId;
            data.DoctorId = vm.DoctorId;
            data.Date = vm.Date;
            data.TimeSlot = vm.TimeSlot;
            data.Status = Enum.Parse<AppointmentStatus>(vm.Status);

            _service.Update(data);

            TempData["success"] = "Updated successfully!";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        LoadDropdowns();
        ViewBag.TimeSlots = GetTimeSlots();
        ViewBag.StatusList = GetStatusList();

        return View(vm);
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        TempData["success"] = "Deleted successfully!";
        return RedirectToAction("Index");
    }
}

