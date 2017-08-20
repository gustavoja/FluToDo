﻿using FluToDo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Models.ServiceContracts
{
    public interface INetService
    {
        string ServerAddress { get; set; }
        int Port { get; set; }
        string ApiRoute { get; set; }
        string RestServiceUrl { get; }

        Task<List<TodoItem>> GetAll();
        Task<TodoItem> GetById(string id);
        Task<TodoItem> Create(TodoItem item);
        Task<bool> Update(TodoItem item, string id = null);
        Task<bool> Delete(TodoItem item);

    }
}
