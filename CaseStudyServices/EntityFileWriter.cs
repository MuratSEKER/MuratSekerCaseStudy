namespace CaseStudyServices
{
    public abstract class EntityFileWriter : IFileWriter
    {
        public abstract void WriteFile(object content, string target);
    }
}
