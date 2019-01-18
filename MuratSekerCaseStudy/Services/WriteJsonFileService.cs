using MuratSekerCaseStudy.Data.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using CaseStudyServices;

namespace MuratSekerCaseStudy.Services
{
    public class WriteJsonFileService : EntityFileWriter
    {
        public override void WriteFile(object content, string target)
        {
            using (StreamWriter file = File.CreateText(target))
            {
                var list = (IList<Hotel>)content;
                var jsonContent = JsonConvert.SerializeObject(list);
                file.Write(jsonContent);
            }
        }
    }
}           ;
            
            