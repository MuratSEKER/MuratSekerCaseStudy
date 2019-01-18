using CaseStudyServices;
using MuratSekerCaseStudy.Data.Entities;
using MuratSekerCaseStudy.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MuratSekerCaseStudy.Services
{
    public class ReadCsvFileService : IReadFileService
    {
        public IList ReadFile(string path, bool hasHeaders = true)
        {
            var list = new List<Hotel>();
            foreach (var line in File.ReadLines(path).Skip(hasHeaders ? 1 : 0))
            {
                var hotel = FileHelper.HotelFromLine(line);
                if(hotel != null)
                    list.Add(hotel);
            }
            return list;
        }

    }
}
