using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            int N = 1;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData removedGroup = new GroupData();

            app.Groups.RemoveGroup(N , removedGroup);//удаляемая группа по порядку начиная с нуля

            List<GroupData> newGroups = app.Groups.GetGroupList();


            
            oldGroups.Remove(removedGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
        }
        
    }
   
}
