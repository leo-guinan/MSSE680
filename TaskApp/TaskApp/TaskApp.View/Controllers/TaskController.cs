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

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(TaskModel taskModel)
        {
            taskModel.dateCreated = DateTime.Now;
            if (taskManager.addTask(taskModel.name, taskModel.notes, taskModel.description, taskModel.dateCreated, taskModel.dueDate, taskModel.priority, taskModel.time, taskModel.type))
            {
                return View("AddSuccess");
            }
            else
            {
                return View("AddFailure");
            }
        }

        public ActionResult ListAll(String sortBy)
        {
            IList<Task> tasks;
            tasks = taskManager.getAllTasks(sortBy);
            
            IList<TaskModel> models = new List<TaskModel>();
            foreach (Task task in tasks)
            {
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

        private Task convertTaskModelToTask(TaskModel taskModel)
        {
            Task task = new Task();
            task.name = taskModel.name;
            task.notes = taskModel.notes;
            task.description = taskModel.description;
            task.dueDate = taskModel.dueDate;
            task.priority = taskModel.priority;
            task.dateCreated = taskModel.dateCreated;
            Estimate estimate = new Estimate();
            estimate.time = taskModel.time;
            estimate.type = taskModel.type;
            task.Estimates.Add(estimate);
            return task;
        }


        #endregion


    }
}
