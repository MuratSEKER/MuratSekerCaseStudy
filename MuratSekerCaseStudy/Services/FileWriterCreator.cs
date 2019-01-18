using CaseStudyServices;

namespace MuratSekerCaseStudy.Services
{
    public class FileWriterCreator
    {
        public static IFileWriter GetFileWriter(string type)
        {
            IFileWriter writer = null;
            if (type.ToLower()==".json")
            {
                writer = new WriteJsonFileService();
            }
            else
            {
                writer = new WriteXmlFileService();
            }
            return writer;
        }
    }
}
