using System;
using System.Collections;
using System.Collections.Generic;
using CaseStudyCore.Enumerations;
using CaseStudyCore.Helpers;
using CaseStudyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MuratSekerCaseStudy.Models;
using MuratSekerCaseStudy.Services;
using System.IO;
using System.Threading.Tasks;
using MuratSekerCaseStudy.Data.Entities;
using MuratSekerCaseStudy.Helpers;

namespace MuratSekerCaseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadFileService _reader;

        public HomeController(IReadFileService reader)
        {

            _reader = reader;

        }
        public IActionResult Index()
        {
            //var a=  Enum.GetValues(typeof(FileStorageType)).Cast<FileStorageType>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HotelFile model)
        {
            if (ModelState.IsValid)
            {
                if (model == null ||
                    model.FileToUpload == null || model.FileToUpload.Length == 0)
                    return Content("file not selected");

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/uploadedfiles",
                    model.FileToUpload.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.FileToUpload.CopyToAsync(stream);
                }

                var hotelList = _reader.ReadFile(path);

                var description = EnumerationHelper.GetDescription((FileStorageType)model.SelectedFileStorageType);
                var sortingOption = EnumerationHelper.GetDescription((TransactionOptionType)model.SelectedSortGroup);

                var orderedHotelList = FileHelper.ToOrderedList(hotelList as IList<Hotel>, sortingOption);

                var writer = FileWriterCreator.GetFileWriter(description);
                var newFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploadedfiles", $"{description.TrimStart('.')}File{description}");

                writer.WriteFile(hotelList, newFilePath);
            }
            else
            {
                if (model == null ||
                    model.FileToUpload == null || model.FileToUpload.Length == 0)
                    return Content("file not selected");
            }
            return View();
        }

        public ViewResult List()
        {
            IList list = null;
            try
            {
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/uploadedfiles/jsonFile.csv");
                list = _reader.ReadFile(path);
            }
            catch (Exception e)
            {

            }

            return View("Index", list);
        }
    }
}