namespace Assets.ARVR.Common.Scripts.Demo
{
    public class Student
    {
        public static string institute = "DkIT";
    }

    public class FileManager
    {
        private static string filename;
        private static FileManager instance;

        public static FileManager GetInstance(string fname)
        {
            if (instance == null)
            {
                instance = new FileManager(fname);
                return instance;
            }

            return instance;
        }

        private FileManager(string fname)
        {
            filename = fname;
        }

        public void Save(string jsonObject)
        {
        }

        public string Load()
        {
            return null;
        }
    }
}