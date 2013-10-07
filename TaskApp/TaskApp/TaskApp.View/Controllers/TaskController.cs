using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp.Business;
using TaskApp.Domain;
using TaskApp.View.Models;

namespace TaskApp.View.Controllers
{
    public class TaskController : Controller
    {

        [Inject]
        public ITaskManager taskManager { get; set; }

        //
        // GET: /Task/

        public ActionResult Index()
        {
            return View();
        
        
        }

        public ActionResult Add(TaskModel taskModel)
        {

            return View();
        }

        public ActionResult ListAll()
        {
            IList<Task> tasks = taskManager.getAllTasks();
            IList<TaskModel> models = new List<TaskModel>();
            foreach(Task task in tasks) {
                models.Add(convertTaskToTaskModel(task));    
            }
            return View(models);
        }

        #region Helpers

        private TaskModel convertTaskToTaskModel(Task task)
        {
            TaskModel model = new TaskModel();
            model.name = task.name;
            model.notes = task.notes;
            model.priority = task.priority;
            model.description = task.description;
            model.dateCreated = task.dateCreated;
            model.dueDate = task.dueDate;
            if (task.Estimates.Count > 0)
            {
                model.time = task.Estimates.ElementAt(0).time;
                model.type = task.Estimates.ElementAt(0).type;
            }
            return model;
        }

        #endregion


    }
}
