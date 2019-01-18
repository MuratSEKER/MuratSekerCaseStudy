using CaseStudyServices;
using MuratSekerCaseStudy.Data.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MuratSekerCaseStudy.Services
{
    public class WriteXmlFileService : EntityFileWriter
    {
        public override void WriteFile(object content, string target)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                var list = (IList<Hotel>)content;
               
                var xHotel = new XElement("Hotels",
                    from h in list
                    select new XElement("Hotel",
                        new XElement("Name", h.Name),
                        new XElement("Address", h.Address),
                        new XElement("Stars", h.Stars),
                        new XElement("Contact", h.Contact),
                        new XElement("Phone", h.Phone),
                        new XElement("Url", h.Url)
                    ));
          
                xHotel.Save(target);
            }
        }
    }
}
