using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_test_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        
    
        [SetUp] //Выполняется один раз перед всеми тестовыми запусками
        public void InitApplication()
        {
            app = new ApplicationManager();
        }


        [TearDown]
        public void StopApplication()
        {
            app.Stop();
        }


    }
}
