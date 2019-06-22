﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace addressbook_test_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE,"", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");

            for (int i=0; i<int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, "");

                
                list.Add(new GroupData()
                {
                    Name = item
                });

            }

            ClosGroupsDialogue();
            return list;
        }

        internal GroupData RemoveGroup(int v, GroupData group)
        {
            OpenGroupsDialogue();

            aux.ControlTreeView(GROUPWINTITLE,"", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + v, "");//Select Group to Remove
            group.Name = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + v, "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");//Click to DELETE
            aux.WinWait("Delete group");//Wait for open window

            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d51");//Click to "Delete the selected Group"
                        
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");//Click to "OK"

            ClosGroupsDialogue();
            return group;
        }
       
        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");

            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            ClosGroupsDialogue();

        }

        private void ClosGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}