using FluToDo.Models.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluToDo.Models.Entities;
using System.Linq;

namespace FluToDo.Models.Services.Mocks
{
    public class MockNetService : INetService
    {
        #region Fields
        private int port;
        private string serverAddress;
        private string apiRoute;

        private List<TodoItem> list = new List<TodoItem>() { new TodoItem() {Key="0",Name="Task 0",IsComplete=true}, new TodoItem() { Key = "1", Name = "Task 1", IsComplete = false } , new TodoItem() { Key = "2", Name = "Task 2", IsComplete = true } , new TodoItem() { Key = "3", Name = "Task 3", IsComplete = false } };
        private int itemKey = 3;
        #endregion Fields

        #region Properties

        public string ServerAddress { get { return serverAddress; } set { serverAddress = value; } }
        public int Port { get { return port; } set { port = value; } }
        public string ApiRoute { get { return apiRoute; } set { apiRoute = value; } }
        public string RestServiceUrl { get { return $"{ServerAddress}:{Port}/{ApiRoute}"; } }

        #endregion Properties

        public async Task<TodoItem> Create(TodoItem item)
        {
            itemKey += 1;
            item.Key = itemKey.ToString();
            await Task.Delay(500);
            list.Add(item);
            return item;
        }

        public async Task<bool> Delete(TodoItem item)
        {
            await Task.Delay(500);
            list.Remove(list.Single(i => i.Key == item.Key));
            return true;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            await Task.Delay(500);
            return list;
        }

        public Task<TodoItem> GetById(string id)
        {
            return Task.FromResult(list.Single(i => i.Key == id));
        }

        public async Task<bool> Update(TodoItem item, string id = null)
        {
            await Task.Delay(500);
            TodoItem baseItem;
            if (id == null)
            {
                baseItem = list.Single(i => i.Key == id);
            }
            else
            {
                baseItem = list.Single(i => i.Key == item.Key);
            }
            baseItem.Name = item.Name;
            baseItem.IsComplete = item.IsComplete;
            return true;
        }
    }
}
