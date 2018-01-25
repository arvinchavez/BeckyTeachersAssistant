using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeckyTeachersAssistant.Models;

[assembly: Xamarin.Forms.Dependency(typeof(BeckyTeachersAssistant.Services.MockDataStore))]
namespace BeckyTeachersAssistant.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Jeffry Lopez", OverallGrade= "95", LastGrade = "90"},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Matthew Lopez", OverallGrade= "92", LastGrade = "85"},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Jonathan Duenas", OverallGrade= "92", LastGrade = "85"},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Arvin Chavez", OverallGrade= "99", LastGrade = "97"}
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}