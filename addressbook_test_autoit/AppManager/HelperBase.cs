﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;


namespace addressbook_test_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected AutoItX3 aux;
        protected  string WINTITLE = "Free Address Book";
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}