using MyDogamDesktop.Data;
using MyDogamDesktop.Models;

namespace MyDogamDesktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //using (var db = new AppDbContext())
            //{
            //    db.Collections.Add(new Collection
            //    {
            //        Name = "테스트 컬렉션",
            //        FileName = "test.json",
            //        TotalItems = 0,
            //        CreatedAt = DateTime.Now
            //    });
            //    db.SaveChanges();
            //    MessageBox.Show("저장 성공! 개수: " + db.Collections.Count());
            //}

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}