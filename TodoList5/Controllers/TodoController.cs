using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoList5.Models;

namespace TodoList5.Controllers
{
    public class TodoController : Controller
    {
        TodoDataAccessLayer todoDataAccessLayer = null;
        public TodoController()
        {
            todoDataAccessLayer = new TodoDataAccessLayer();
        }

        // GET: Todo
        public ActionResult Index()
        {
            IEnumerable<Todo> todos = todoDataAccessLayer.GetAllTask();
            return View(todos);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            Todo todo = todoDataAccessLayer.GetTaskData(id);
            return View(todo);

        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]

        public ActionResult Create(Todo todo)
        {
            try
            {
                // TODO: Add insert logic here
                todoDataAccessLayer.AddTask(todo);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            Todo todo = todoDataAccessLayer.GetTaskData(id);
            return View(todo);
        }

        // POST: Todo/Edit/5
        [HttpPost]
      
        public ActionResult Edit(Todo todo)
        {
            try
            {
                // TODO: Add update logic here
                todoDataAccessLayer.UpdateTask(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            Todo todo = todoDataAccessLayer.GetTaskData(id);
            return View(todo);
        }

        // POST: Todo/Delete/5
        [HttpPost]
       
        public ActionResult Delete(Todo todo)
        {
            try
            {
                // TODO: Add delete logic here
                todoDataAccessLayer.DeleteTask(todo.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}