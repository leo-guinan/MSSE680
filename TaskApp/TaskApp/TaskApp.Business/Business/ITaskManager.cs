using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Business
{
    public interface ITaskManager
    {
        Boolean login(String username, String password);
        Boolean addTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType);
        Boolean modifyTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType, int taskId);



    }
}
