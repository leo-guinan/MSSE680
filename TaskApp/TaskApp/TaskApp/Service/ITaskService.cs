using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskApp.Service
{
    public interface ITaskService
    {
        Boolean addTask(Task task);
        Boolean modifyTask(Task task);
        Task getTaskById(int id);
        IList<Task> getAllTasks();
        Boolean removeTask(Task task);

    }
}